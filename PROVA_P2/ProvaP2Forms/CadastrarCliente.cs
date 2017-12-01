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
    public partial class CadastrarCliente : Form
    {
        HttpClient client;
        Uri clienteUri;

        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txtNome.Text) || String.IsNullOrEmpty(txtEndereco.Text) || String.IsNullOrEmpty(txtEmail.Text)))
            {
                Cliente cliente = new Cliente();
                cliente.nome = txtNome.Text;
                cliente.endereco = txtEndereco.Text;
                cliente.email = txtEmail.Text;
                inserirCliente(cliente);
                limparCampos();
                MessageBox.Show("Cadastrado com sucesso!", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor! Preencha os campos necessários!");
            }
        }

        private void inserirCliente(Cliente cliente)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            var clientes = new Cliente() { nome = cliente.nome, endereco = cliente.endereco, email = cliente.email };
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Clientes").Result;
            response = client.PostAsJsonAsync("api/Clientes", clientes).Result;

            if (response.IsSuccessStatusCode)
                clienteUri = response.Headers.Location;
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtEmail.Text = "";
            txtNome.Focus();
        }
    }
}
