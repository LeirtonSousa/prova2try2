using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProvaP2API.Models;

namespace ProvaP2Forms
{
    public partial class ControleDeDespesa : Form
    {


        HttpClient client;
        Uri despesaUri;

        public ControleDeDespesa()
        {
            InitializeComponent();
        }

        private void ControleDeDespesa_Load(object sender, EventArgs e)
        {
            getAllDespesas();
        }


        /// <summary>
        /// Busca todos os materiais cadastrados por meio do Web Service
        /// </summary>
        private void getAllDespesas()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Despesas").Result;
            if (response.IsSuccessStatusCode)
            {
                despesaUri = response.Headers.Location;
                var materiais = response.Content.ReadAsAsync<IEnumerable<Despesa>>().Result;
                grdDespesa.DataSource = materiais;
            }
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
        }

        /// <summary>
        /// Metodo que seleciona o dado a ser excluido no GridView e
        /// chama o método responsável por tal ação.
        /// </summary>
        /// <param name="sender">Parametro do sistema</param>
        /// <param name="e">Parametro do sistema</param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = grdDespesa.CurrentRow.Index;
            deleteDespesa(int.Parse(grdDespesa.Rows[indice].Cells["id"].Value.ToString()));
            getAllDespesas();
            MessageBox.Show("A Despesa selecionada foi excluida!");
        }

        /// <summary>
        /// Método que recebe um Id e deleta os dados respectivos no banco de dados
        /// utilizando o Web Service.
        /// </summary>
        /// <param name="Id">Id da Despesa</param>
        private void deleteDespesa(int Id)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Despesas/" + Id).Result;
            response = client.DeleteAsync("api/Despesas/" + Id).Result;

            if (response.IsSuccessStatusCode)
                despesaUri = response.Headers.Location;
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
        }


        /// <summary>
        /// Método responsável por carregar os dados selecionados no GridView
        /// em suas respectivas posições para a efetuação do Update.
        /// </summary>
        /// <param name="sender">Parametro do sistema</param>
        /// <param name="e">Parametro do sistema</param>
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int indice = grdDespesa.CurrentRow.Index;

            txtValor.Text = grdDespesa.Rows[indice].Cells["valor"].Value.ToString();
            txtDescricao.Text = grdDespesa.Rows[indice].Cells["descricao"].Value.ToString();
        }

        /// <summary>
        /// Método que gerencia a atualização dos dados presentes no banco de dados e 
        /// que chama o método responsável por efetuar essa atualização.
        /// </summary>
        /// <param name="sender">Parametro do sistema</param>
        /// <param name="e">Parametro do sistema</param>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txtValor.Text) || String.IsNullOrEmpty(txtDescricao.Text)))
            {
                int indice = grdDespesa.CurrentRow.Index;
                updateDespesa(int.Parse(grdDespesa.Rows[indice].Cells["id"].Value.ToString()), float.Parse(txtValor.Text), txtDescricao.Text);
                getAllDespesas();
                MessageBox.Show("Despesa atualizada!");
            }
            else
            {
                MessageBox.Show("É necessário preencher todos os campos para completar a atualização!");
            }
        }


        /// <summary>
        /// Método que realiza a atualização dos dados contidos no banco de dados
        /// por meio do web service.
        /// </summary>
        /// <param name="_id">Id da despesa</param>
        /// <param name="_valor">valor da Despesa</param>
        /// <param name="_descricao">descrição da Despesa</param>
        private void updateDespesa(int _id, double _valor, string _descricao)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            var despesas = new Despesa() { id = _id, valor = _valor, descricao = _descricao };
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Despesas/").Result;
            response = client.PutAsJsonAsync("api/Despesas/" + _id, despesas).Result;

            if (response.IsSuccessStatusCode)
                despesaUri = response.Headers.Location;
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


