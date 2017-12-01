using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProvaP2API.Models;
using System.Net.Http;


namespace ProvaP2Forms
{
    public partial class FormLogin : Form
    {

        HttpClient client;
        Uri funcionarioUri;

        public FormLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botao que executa a ação de solicitar um login no sistema, fazendo a verficação
        /// no banco de dados se os dados se confirmam.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = getFuncionarioByLogin(txtNomeUsuario.Text);


            if (funcionario != null)
            {
                if (funcionario.senha.Equals(txtSenha.Text))
                {
                    FormPrincipal frm = new FormPrincipal();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Senha Incorreta.");
                }
            }
            else
            {
                MessageBox.Show("Funcionário não encontrado.");
            }
        }

        /// <summary>
        /// Metodo que busca verifica a existencia do funcionario no banco de dados
        /// utilizando o Web Service
        /// </summary>
        /// <param name="login">Login do funcionario a ser pesquisado</param>
        /// <returns></returns>
        private Funcionario getFuncionarioByLogin(string login)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            System.Net.Http.HttpResponseMessage response = client.GetAsync("Funcionario/ByLogin/" + login).Result;
            if (response.IsSuccessStatusCode)
            {
                funcionarioUri = response.Headers.Location;
                var funcionario = response.Content.ReadAsAsync<IEnumerable<Funcionario>>().Result;
                Funcionario _funcionario = new Funcionario();
                foreach (var item in funcionario)
                {
                    _funcionario.id = item.id;
                    _funcionario.login = item.login;
                    _funcionario.nome = item.nome;
                    _funcionario.senha = item.senha;
                    _funcionario.salario = item.salario;
                }
                return _funcionario;
            }
            else
            {
                return null;
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
