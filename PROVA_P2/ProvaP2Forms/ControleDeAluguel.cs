using ProvaP2API.Models;
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

namespace ProvaP2Forms
{
    public partial class ControleDeAluguel : Form
    {

        HttpClient client;
        Uri aluguelUri;

        public ControleDeAluguel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que busca todos os alugueis registrados no sistema ao 
        /// executar o forms de controle
        /// </summary>
        /// <param name="sender"> parametro do sistema</param>
        /// <param name="e">parametro do sistema</param>
        private void ControleDeAluguel_Load(object sender, EventArgs e)
        {
            getAllAlugueis();
        }

        /// <summary>
        /// Busca todos os alugueis cadastrados por meio do Web Service
        /// </summary>
        private void getAllAlugueis()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Alugueis").Result;
            if (response.IsSuccessStatusCode)
            {
                aluguelUri = response.Headers.Location;
                var alugueis = response.Content.ReadAsAsync<IEnumerable<Aluguel>>().Result;
                grdAlugueis.DataSource = alugueis;
            }
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
        }

        /// <summary>
        /// Botão para voltar à pagina principal do sistema
        /// </summary>
        /// <param name="sender">Parametro do sistema</param>
        /// <param name="e">Parametro do sistema</param>
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo que seleciona o dado a ser excluido no GridView e
        /// chama o método responsável por tal ação.
        /// </summary>
        /// <param name="sender">Parametro do sistema</param>
        /// <param name="e">Parametro do sistema</param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = grdAlugueis.CurrentRow.Index;
            deleteAluguel(int.Parse(grdAlugueis.Rows[indice].Cells["id"].Value.ToString()));
            getAllAlugueis();
            MessageBox.Show("O aluguel selecionado foi excluido!");
        }

        /// <summary>
        /// Método que recebe um Id e deleta os dados respectivos no banco de dados
        /// utilizando o Web Service.
        /// </summary>
        /// <param name="Id">Id do Aluguel</param>
        private void deleteAluguel(int Id)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Alugueis/" + Id).Result;
            response = client.DeleteAsync("api/Alugueis/" + Id).Result;

            if (response.IsSuccessStatusCode)
                aluguelUri = response.Headers.Location;
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
            int indice = grdAlugueis.CurrentRow.Index;

            txtIdCliente.Text = grdAlugueis.Rows[indice].Cells["idCliente"].Value.ToString();
            txtIdMaterial.Text = grdAlugueis.Rows[indice].Cells["idMaterial"].Value.ToString();
            txtIdFuncionario.Text = grdAlugueis.Rows[indice].Cells["idFuncionario"].Value.ToString();
            txtValor.Text = grdAlugueis.Rows[indice].Cells["valor"].Value.ToString();
            txtDtEntrega.Text = grdAlugueis.Rows[indice].Cells["dataEntrega"].Value.ToString();
            txtDtDevolucao.Text = grdAlugueis.Rows[indice].Cells["dataDevolucao"].Value.ToString();
            cmbFormaPgmt.Text = grdAlugueis.Rows[indice].Cells["formaPgmt"].Value.ToString();

        }

        /// <summary>
        /// Método que gerencia a atualização dos dados presentes no banco de dados e 
        /// que chama o método responsável por efetuar essa atualização.
        /// 
        /// </summary>
        /// <param name="sender">Parametro do sistema</param>
        /// <param name="e">Parametro do sistema</param>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txtIdCliente.Text) || 
                String.IsNullOrEmpty(txtIdMaterial.Text) || 
                String.IsNullOrEmpty(txtIdFuncionario.Text) || 
                String.IsNullOrEmpty(txtValor.Text) ||
                String.IsNullOrEmpty(txtDtEntrega.Text) ||
                String.IsNullOrEmpty(txtDtDevolucao.Text) ||
                String.IsNullOrEmpty(cmbFormaPgmt.Text)))
            {
                int indice = grdAlugueis.CurrentRow.Index;
                updateAluguel(int.Parse(grdAlugueis.Rows[indice].Cells["id"].Value.ToString()), int.Parse(txtIdCliente.Text),
                                                                                                int.Parse(txtIdMaterial.Text),
                                                                                                int.Parse(txtIdFuncionario.Text),
                                                                                                float.Parse(txtValor.Text),
                                                                                                txtDtEntrega.Text,
                                                                                                txtDtDevolucao.Text,
                                                                                                cmbFormaPgmt.Text);
                getAllAlugueis();
                MessageBox.Show("Aluguel atualizado!");
            }
            else
            {
                MessageBox.Show("É necessário preencher todos os campos para completar a atualização!");
            }
        }

        /// <summary>
        /// Método que realiza a atualização dos dados presentes no banco de dados
        /// por meio do Web Service.
        /// </summary>
        /// <param name="_id"> Id do Aluguel</param>
        /// <param name="_idCliente"> Id do cliente</param>
        /// <param name="_idMaterial"> Id do material</param>
        /// <param name="_idFuncionario"> Id do Funcionario</param>
        /// <param name="_valor"> Valor do aluguel</param>
        /// <param name="_dataEntrega"> Data de Entrega</param>
        /// <param name="_dataDevolucao"> Data de devolução</param>
        /// <param name="_formaPgmt"> Forma de pagamento</param>
        private void updateAluguel(int _id, int _idCliente, int _idMaterial, int _idFuncionario, float _valor, string _dataEntrega, string _dataDevolucao, string _formaPgmt)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            var alugueis = new Aluguel() { id = _id, idCliente = _idCliente, idMaterial = _idMaterial, idFuncionario = _idFuncionario, valor = _valor, dataEntrega = _dataEntrega, dataDevolucao = _dataDevolucao , formaPgmt = _formaPgmt };
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Alugueis/").Result;
            response = client.PutAsJsonAsync("api/Alugueis/" + _id, alugueis).Result;

            if (response.IsSuccessStatusCode)
                aluguelUri = response.Headers.Location;
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
        }
    }
}
