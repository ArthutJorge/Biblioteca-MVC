namespace apBiblioteca.UI
{
    partial class FrmLivrosEmprestados
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
            this.dgvLivrosEmprestados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivrosEmprestados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLivrosEmprestados
            // 
            this.dgvLivrosEmprestados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivrosEmprestados.Location = new System.Drawing.Point(12, 12);
            this.dgvLivrosEmprestados.Name = "dgvLivrosEmprestados";
            this.dgvLivrosEmprestados.Size = new System.Drawing.Size(529, 365);
            this.dgvLivrosEmprestados.TabIndex = 0;
            // 
            // FrmLivrosEmprestados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 389);
            this.Controls.Add(this.dgvLivrosEmprestados);
            this.Name = "FrmLivrosEmprestados";
            this.Text = "Livros Emprestados";
            this.Load += new System.EventHandler(this.FrmLivrosEmprestados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivrosEmprestados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLivrosEmprestados;
    }
}