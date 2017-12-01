using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using ProvaP2API.Models;

namespace ProvaP2Forms
{
    public partial class CadastrarAluguel : Form
    {

        HttpClient client;
        Uri aluguelUri;

        public CadastrarAluguel()
        {
            InitializeComponent();
        }

        private void CadastrarAluguel_Load(object sender, EventArgs e)
        {

        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = new Aluguel();
            //Funcionario _func = (Funcionario)Session["funcionario"];

            aluguel.idMaterial = Convert.ToInt32(txtIdMaterial.Text);
            aluguel.idCliente = Convert.ToInt32(txtIdCliente.Text);
            aluguel.idFuncionario = Convert.ToInt32(txtIdFunc.Text);
            aluguel.valor = Convert.ToDouble(txtValor.Text);
            aluguel.dataEntrega = txtDtEntrega.Text;
            aluguel.dataDevolucao = txtDtDevolucao.Text;
            aluguel.formaPgmt = cmbFrmPagmt.Text;
            //aluguel.idFuncionario = _func.id;

            if (getMaterialById(aluguel.idMaterial))
            {
                if (getClienteById(aluguel.idCliente))
                {
                    inserirAluguel(aluguel);
                    MessageBox.Show("Cadastrado com sucesso!", "Aluguel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpaCampos();
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado no sistema!");
                }
            }
            else
            {
                MessageBox.Show("Material não encontrado no sistema!");
            }
        }


        private Boolean getClienteById(int id)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Clientes/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }


        private Boolean getMaterialById(int id)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Materiais/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }


        private void inserirAluguel(Aluguel aluguel)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            var alugueis = new Aluguel() {idFuncionario = aluguel.idFuncionario, idMaterial = aluguel.idMaterial, idCliente = aluguel.idCliente, valor = aluguel.valor , dataEntrega = aluguel.dataEntrega, dataDevolucao = aluguel.dataDevolucao, formaPgmt = aluguel.formaPgmt};
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Alugueis").Result;
            response = client.PostAsJsonAsync("api/Alugueis", alugueis).Result;

            if (response.IsSuccessStatusCode)
                aluguelUri = response.Headers.Location;
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
        }


        private void limpaCampos()
        {
            txtIdFunc.Text = "";
            txtIdCliente.Text = "";
            txtIdMaterial.Text = "";
            txtValor.Text = "";
            txtDtEntrega.Text = "";
            txtDtDevolucao.Text = "";
            cmbFrmPagmt.Text = "";
            txtIdFunc.Focus();
        }
    }
}
