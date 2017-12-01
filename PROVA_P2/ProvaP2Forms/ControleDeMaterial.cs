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
    public partial class ControleDeMaterial : Form
    {

        HttpClient client;
        Uri materialUri;

        public ControleDeMaterial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botão responsável por encerrar a janela de controle
        /// </summary>
        /// <param name="sender">Parametro do sistema</param>
        /// <param name="e">Parametro do sistema</param>
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ControleDeMaterial_Load(object sender, EventArgs e)
        {
            getAllMateriais();
        }

        /// <summary>
        /// Busca todos os materiais cadastrados por meio do Web Service
        /// </summary>
        private void getAllMateriais()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Materiais").Result;
            if (response.IsSuccessStatusCode)
            {
                materialUri = response.Headers.Location;
                var materiais = response.Content.ReadAsAsync<IEnumerable<Material>>().Result;
                grdMaterial.DataSource = materiais;
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
            int indice = grdMaterial.CurrentRow.Index;
            deleteMaterial(int.Parse(grdMaterial.Rows[indice].Cells["id"].Value.ToString()));
            getAllMateriais();
            MessageBox.Show("O Material selecionado foi excluido!");
        }


        /// <summary>
        /// Método que recebe um Id e deleta os dados respectivos no banco de dados
        /// utilizando o Web Service.
        /// </summary>
        /// <param name="Id">Id do Material</param>
        private void deleteMaterial(int Id)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Materiais/" + Id).Result;
            response = client.DeleteAsync("api/Materiais/" + Id).Result;

            if (response.IsSuccessStatusCode)
                materialUri = response.Headers.Location;
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
            int indice = grdMaterial.CurrentRow.Index;

            cmbNome.Text = grdMaterial.Rows[indice].Cells["nome"].Value.ToString();
            txtValor.Text = grdMaterial.Rows[indice].Cells["valor"].Value.ToString();
            cmbStatus.Text = grdMaterial.Rows[indice].Cells["status"].Value.ToString();
        }

        /// <summary>
        /// Método que gerencia a atualização dos dados presentes no banco de dados e 
        /// que chama o método responsável por efetuar essa atualização.
        /// </summary>
        /// <param name="sender">Parametro do sistema</param>
        /// <param name="e">Parametro do sistema</param>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(cmbNome.Text) || String.IsNullOrEmpty(txtValor.Text) || String.IsNullOrEmpty(cmbStatus.Text)))
            {
                int indice = grdMaterial.CurrentRow.Index;
                updateMaterial(int.Parse(grdMaterial.Rows[indice].Cells["id"].Value.ToString()), cmbNome.Text, txtValor.Text, int.Parse(cmbStatus.Text));
                getAllMateriais();
                MessageBox.Show("Material atualizado!");
            }
            else
            {
                MessageBox.Show("É necessário preencher todos os campos para completar a atualização!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id">Id do material</param>
        /// <param name="_nome">Nome do material</param>
        /// <param name="_valor">Valor do material</param>
        /// <param name="_status">Status do material</param>
        private void updateMaterial(int _id, string _nome, string _valor, int _status)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            var materiais = new Material() { id = _id, nome = _nome, valor = _valor, status = _status };
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Materiais/").Result;
            response = client.PutAsJsonAsync("api/Materiais/" + _id, materiais).Result;

            if (response.IsSuccessStatusCode)
                materialUri = response.Headers.Location;
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
        }
    }
}
