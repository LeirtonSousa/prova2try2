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
    public partial class CadastrarDespesa : Form
    {
        HttpClient client;
        Uri despesaUri;

        public CadastrarDespesa()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txtValor.Text) || String.IsNullOrEmpty(txtDescricao.Text)))
            {
                Despesa desp = new Despesa();
                desp.valor = float.Parse(txtValor.Text);
                desp.descricao = txtDescricao.Text;
                inserirDespesa(desp);
                limparCampos();
                MessageBox.Show("Registrado com sucesso!", "Despesa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor! Preencha os campos necessários!");
            }
        }

        private void inserirDespesa(Despesa despesa)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            var despesas = new Despesa() { valor = despesa.valor, descricao = despesa.descricao };
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Despesas").Result;
            response = client.PostAsJsonAsync("api/Despesas", despesas).Result;

            if (response.IsSuccessStatusCode)
                despesaUri = response.Headers.Location;
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
        }

        private void limparCampos()
        {
            txtValor.Text = "";
            txtDescricao.Text = "";
            txtValor.Focus();
        }
    }
}
