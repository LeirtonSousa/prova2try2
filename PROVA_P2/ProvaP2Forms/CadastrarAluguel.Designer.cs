namespace ProvaP2Forms
{
    partial class CadastrarAluguel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIdCliente = new System.Windows.Forms.Label();
            this.lblIdMaterial = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblDtEntrega = new System.Windows.Forms.Label();
            this.lblDtDevolucao = new System.Windows.Forms.Label();
            this.lblfrmPagmt = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtIdMaterial = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtDtEntrega = new System.Windows.Forms.TextBox();
            this.txtDtDevolucao = new System.Windows.Forms.TextBox();
            this.cmbFrmPagmt = new System.Windows.Forms.ComboBox();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdFunc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblIdCliente
            // 
            this.lblIdCliente.AutoSize = true;
            this.lblIdCliente.Location = new System.Drawing.Point(37, 43);
            this.lblIdCliente.Name = "lblIdCliente";
            this.lblIdCliente.Size = new System.Drawing.Size(56, 13);
            this.lblIdCliente.TabIndex = 0;
            this.lblIdCliente.Text = "ID Cliente:";
            // 
            // lblIdMaterial
            // 
            this.lblIdMaterial.AutoSize = true;
            this.lblIdMaterial.Location = new System.Drawing.Point(37, 79);
            this.lblIdMaterial.Name = "lblIdMaterial";
            this.lblIdMaterial.Size = new System.Drawing.Size(61, 13);
            this.lblIdMaterial.TabIndex = 1;
            this.lblIdMaterial.Text = "ID Material:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(37, 115);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor:";
            // 
            // lblDtEntrega
            // 
            this.lblDtEntrega.AutoSize = true;
            this.lblDtEntrega.Location = new System.Drawing.Point(37, 150);
            this.lblDtEntrega.Name = "lblDtEntrega";
            this.lblDtEntrega.Size = new System.Drawing.Size(73, 13);
            this.lblDtEntrega.TabIndex = 3;
            this.lblDtEntrega.Text = "Data Entrega:";
            // 
            // lblDtDevolucao
            // 
            this.lblDtDevolucao.AutoSize = true;
            this.lblDtDevolucao.Location = new System.Drawing.Point(37, 184);
            this.lblDtDevolucao.Name = "lblDtDevolucao";
            this.lblDtDevolucao.Size = new System.Drawing.Size(88, 13);
            this.lblDtDevolucao.TabIndex = 4;
            this.lblDtDevolucao.Text = "Data Devolução:";
            // 
            // lblfrmPagmt
            // 
            this.lblfrmPagmt.AutoSize = true;
            this.lblfrmPagmt.Location = new System.Drawing.Point(37, 219);
            this.lblfrmPagmt.Name = "lblfrmPagmt";
            this.lblfrmPagmt.Size = new System.Drawing.Size(111, 13);
            this.lblfrmPagmt.TabIndex = 5;
            this.lblfrmPagmt.Text = "Forma de Pagamento:";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(147, 40);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(72, 20);
            this.txtIdCliente.TabIndex = 7;
            // 
            // txtIdMaterial
            // 
            this.txtIdMaterial.Location = new System.Drawing.Point(147, 76);
            this.txtIdMaterial.Name = "txtIdMaterial";
            this.txtIdMaterial.Size = new System.Drawing.Size(72, 20);
            this.txtIdMaterial.TabIndex = 8;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(147, 112);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(72, 20);
            this.txtValor.TabIndex = 9;
            // 
            // txtDtEntrega
            // 
            this.txtDtEntrega.Location = new System.Drawing.Point(147, 147);
            this.txtDtEntrega.Name = "txtDtEntrega";
            this.txtDtEntrega.Size = new System.Drawing.Size(129, 20);
            this.txtDtEntrega.TabIndex = 10;
            // 
            // txtDtDevolucao
            // 
            this.txtDtDevolucao.Location = new System.Drawing.Point(147, 181);
            this.txtDtDevolucao.Name = "txtDtDevolucao";
            this.txtDtDevolucao.Size = new System.Drawing.Size(129, 20);
            this.txtDtDevolucao.TabIndex = 11;
            // 
            // cmbFrmPagmt
            // 
            this.cmbFrmPagmt.FormattingEnabled = true;
            this.cmbFrmPagmt.Items.AddRange(new object[] {
            "Dinheiro",
            "Débito",
            "Crédito"});
            this.cmbFrmPagmt.Location = new System.Drawing.Point(155, 219);
            this.cmbFrmPagmt.Name = "cmbFrmPagmt";
            this.cmbFrmPagmt.Size = new System.Drawing.Size(121, 21);
            this.cmbFrmPagmt.TabIndex = 12;
            // 
            // btnCancela
            // 
            this.btnCancela.Location = new System.Drawing.Point(40, 288);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(108, 35);
            this.btnCancela.TabIndex = 13;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnConfirma
            // 
            this.btnConfirma.Location = new System.Drawing.Point(168, 288);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(108, 35);
            this.btnConfirma.TabIndex = 14;
            this.btnConfirma.Text = "Confirmar";
            this.btnConfirma.UseVisualStyleBackColor = true;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "ID Funcionario:";
            // 
            // txtIdFunc
            // 
            this.txtIdFunc.Location = new System.Drawing.Point(147, 1);
            this.txtIdFunc.Name = "txtIdFunc";
            this.txtIdFunc.Size = new System.Drawing.Size(72, 20);
            this.txtIdFunc.TabIndex = 16;
            // 
            // CadastrarAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 365);
            this.Controls.Add(this.txtIdFunc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.cmbFrmPagmt);
            this.Controls.Add(this.txtDtDevolucao);
            this.Controls.Add(this.txtDtEntrega);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtIdMaterial);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.lblfrmPagmt);
            this.Controls.Add(this.lblDtDevolucao);
            this.Controls.Add(this.lblDtEntrega);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblIdMaterial);
            this.Controls.Add(this.lblIdCliente);
            this.Name = "CadastrarAluguel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Aluguel";
            this.Load += new System.EventHandler(this.CadastrarAluguel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdCliente;
        private System.Windows.Forms.Label lblIdMaterial;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblDtEntrega;
        private System.Windows.Forms.Label lblDtDevolucao;
        private System.Windows.Forms.Label lblfrmPagmt;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtIdMaterial;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtDtEntrega;
        private System.Windows.Forms.TextBox txtDtDevolucao;
        private System.Windows.Forms.ComboBox cmbFrmPagmt;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdFunc;
    }
}