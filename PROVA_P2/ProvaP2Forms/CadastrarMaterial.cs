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
    public partial class CadastrarMaterial : Form
    {
        HttpClient client;
        Uri materialUri;

        public CadastrarMaterial()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(cmbNome.Text) || String.IsNullOrEmpty(txtValor.Text) || String.IsNullOrEmpty(cmbStatus.Text)))
            {
                int _var;
                Material mat = new Material();
                mat.nome = cmbNome.Text;
                mat.valor = txtValor.Text;
                if (cmbStatus.Text.Equals("Disponível"))
                {
                    _var = 1;
                }
                else
                {
                    _var = 0;
                }
                mat.status = _var;
                inserirMaterial(mat);
                limparCampos();
                MessageBox.Show("Cadastrado com sucesso!", "Material", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor! Preencha os campos necessários!");
            }
        }

        private void inserirMaterial(Material material)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52037");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            var materiais = new Material() { nome = material.nome, valor = material.valor, status = material.status };
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Materiais").Result;
            response = client.PostAsJsonAsync("api/Materiais", materiais).Result;

            if (response.IsSuccessStatusCode)
                materialUri = response.Headers.Location;
            else
                MessageBox.Show(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
        }

        private void limparCampos()
        {
            cmbNome.Text = "";
            txtValor.Text = "";
            cmbStatus.Text = "";
            cmbNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
