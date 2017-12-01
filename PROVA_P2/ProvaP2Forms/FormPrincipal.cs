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

namespace ProvaP2Forms
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarFuncionario frmFunc = new CadastrarFuncionario();
            frmFunc.MdiParent = this;
            frmFunc.Show();
        }

        private void dispesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarDespesa frmDesp = new CadastrarDespesa();
            frmDesp.MdiParent = this;
            frmDesp.Show();
        }

        private void materialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarMaterial frmMat = new CadastrarMaterial();
            frmMat.MdiParent = this;
            frmMat.Show();
        }

        private void aluguelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarAluguel frmAlgl = new CadastrarAluguel();
            frmAlgl.MdiParent = this;
            frmAlgl.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarCliente frmClt = new CadastrarCliente();
            frmClt.MdiParent = this;
            frmClt.Show();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void alugueisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleDeAluguel frm = new ControleDeAluguel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void materiaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleDeMaterial frm = new ControleDeMaterial();
            frm.MdiParent = this;
            frm.Show();
        }

        private void custosEDespesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleDeDespesa frm = new ControleDeDespesa();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
