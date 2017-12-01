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
using System.Net;
using ProvaP2API.Models;
using ProvaP2API.Controllers;

namespace ProvaP2Forms
{
    public partial class CadastrarFuncionario : Form
    {
        HttpClient client;
        Uri funcionarioUri;

        public CadastrarFuncionario()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txtLogin.Text) || String.IsNullOrEmpty(txtNome.Text) || String.IsNullOrEmpty(txtSenha.Text) || String.IsNullOrEmpty(txtSalario.Text)))
            {
                Funcionario func = new Funcionario();
                func.nome = txtNome.Text;
                func.login = txtLogin.Text;
                func.senha = txtSenha.Text;
                func.salario = float.Parse(txtSalario.Text);
                inserirFuncionario(func);
                limparCampos();
                MessageBox.Show("Cadastrado com sucesso!", "Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor! Preencha os campos necessários!");
            }
        }

        private void inserirFuncionario(Funcionario funcionario)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            var funcionarios = new Funcionario() { login = funcionario.login, senha = funcionario.senha, nome = funcionario.nome, salario = funcionario.salario };
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Funcionarios").Result;
            response = client.PostAsJsonAsync("api/Funcionarios", funcionarios).Result;
            
            if (response.IsSuccessStatusCode)
                funcionarioUri = response.Headers.Location;
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
        }

        private void limparCampos()
        {
            txtSenha.Text = "";
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSalario.Text = "";
            txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
