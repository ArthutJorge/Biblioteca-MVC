namespace apBiblioteca.UI
{
    partial class FrmEmprestimos
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
            this.btnCriarEmprestimo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdLeitor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDataEmprestimo = new System.Windows.Forms.DateTimePicker();
            this.txtIdLivro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDataDevolucaoPrevista = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCadastro = new System.Windows.Forms.TabPage();
            this.tpLista = new System.Windows.Forms.TabPage();
            this.dgvEmpréstimos = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tpCadastro.SuspendLayout();
            this.tpLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpréstimos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCriarEmprestimo
            // 
            this.btnCriarEmprestimo.Location = new System.Drawing.Point(422, 211);
            this.btnCriarEmprestimo.Name = "btnCriarEmprestimo";
            this.btnCriarEmprestimo.Size = new System.Drawing.Size(100, 32);
            this.btnCriarEmprestimo.TabIndex = 0;
            this.btnCriarEmprestimo.Text = "Criar empréstimo";
            this.btnCriarEmprestimo.UseVisualStyleBackColor = true;
            this.btnCriarEmprestimo.Click += new System.EventHandler(this.btnCriarEmprestimo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "idLivro";
            // 
            // txtIdLeitor
            // 
            this.txtIdLeitor.Location = new System.Drawing.Point(16, 38);
            this.txtIdLeitor.Name = "txtIdLeitor";
            this.txtIdLeitor.Size = new System.Drawing.Size(100, 20);
            this.txtIdLeitor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "idLeitor";
            // 
            // dtpDataEmprestimo
            // 
            this.dtpDataEmprestimo.Location = new System.Drawing.Point(156, 76);
            this.dtpDataEmprestimo.Name = "dtpDataEmprestimo";
            this.dtpDataEmprestimo.Size = new System.Drawing.Size(243, 20);
            this.dtpDataEmprestimo.TabIndex = 5;
            // 
            // txtIdLivro
            // 
            this.txtIdLivro.Location = new System.Drawing.Point(167, 38);
            this.txtIdLivro.Name = "txtIdLivro";
            this.txtIdLivro.Size = new System.Drawing.Size(100, 20);
            this.txtIdLivro.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data empréstimo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data devolução prevista:";
            // 
            // dtpDataDevolucaoPrevista
            // 
            this.dtpDataDevolucaoPrevista.Location = new System.Drawing.Point(156, 112);
            this.dtpDataDevolucaoPrevista.Name = "dtpDataDevolucaoPrevista";
            this.dtpDataDevolucaoPrevista.Size = new System.Drawing.Size(243, 20);
            this.dtpDataDevolucaoPrevista.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCadastro);
            this.tabControl1.Controls.Add(this.tpLista);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(545, 284);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.Enter += new System.EventHandler(this.tabControl1_Enter);
            // 
            // tpCadastro
            // 
            this.tpCadastro.Controls.Add(this.btnCriarEmprestimo);
            this.tpCadastro.Controls.Add(this.dtpDataDevolucaoPrevista);
            this.tpCadastro.Controls.Add(this.label1);
            this.tpCadastro.Controls.Add(this.txtIdLeitor);
            this.tpCadastro.Controls.Add(this.label5);
            this.tpCadastro.Controls.Add(this.label2);
            this.tpCadastro.Controls.Add(this.label4);
            this.tpCadastro.Controls.Add(this.label3);
            this.tpCadastro.Controls.Add(this.txtIdLivro);
            this.tpCadastro.Controls.Add(this.dtpDataEmprestimo);
            this.tpCadastro.Location = new System.Drawing.Point(4, 22);
            this.tpCadastro.Name = "tpCadastro";
            this.tpCadastro.Padding = new System.Windows.Forms.Padding(3);
            this.tpCadastro.Size = new System.Drawing.Size(537, 258);
            this.tpCadastro.TabIndex = 0;
            this.tpCadastro.Text = "Criar";
            this.tpCadastro.UseVisualStyleBackColor = true;
            // 
            // tpLista
            // 
            this.tpLista.Controls.Add(this.dgvEmpréstimos);
            this.tpLista.Location = new System.Drawing.Point(4, 22);
            this.tpLista.Name = "tpLista";
            this.tpLista.Padding = new System.Windows.Forms.Padding(3);
            this.tpLista.Size = new System.Drawing.Size(537, 258);
            this.tpLista.TabIndex = 1;
            this.tpLista.Text = "Lista";
            this.tpLista.UseVisualStyleBackColor = true;
            this.tpLista.Enter += new System.EventHandler(this.tpLista_Enter);
            // 
            // dgvEmpréstimos
            // 
            this.dgvEmpréstimos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmpréstimos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpréstimos.Location = new System.Drawing.Point(7, 7);
            this.dgvEmpréstimos.Name = "dgvEmpréstimos";
            this.dgvEmpréstimos.ReadOnly = true;
            this.dgvEmpréstimos.Size = new System.Drawing.Size(524, 239);
            this.dgvEmpréstimos.TabIndex = 0;
            // 
            // FrmEmprestimos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 308);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmEmprestimos";
            this.Text = "Empréstimos";
            this.Load += new System.EventHandler(this.FrmEmprestimos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpCadastro.ResumeLayout(false);
            this.tpCadastro.PerformLayout();
            this.tpLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpréstimos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCriarEmprestimo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdLeitor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDataEmprestimo;
        private System.Windows.Forms.TextBox txtIdLivro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDataDevolucaoPrevista;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCadastro;
        private System.Windows.Forms.TabPage tpLista;
        private System.Windows.Forms.DataGridView dgvEmpréstimos;
    }
}