namespace apBiblioteca.UI
{
    partial class FrmLivrosAtrasados
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
            this.dgvLivrosAtrasados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivrosAtrasados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLivrosAtrasados
            // 
            this.dgvLivrosAtrasados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivrosAtrasados.Location = new System.Drawing.Point(12, 12);
            this.dgvLivrosAtrasados.Name = "dgvLivrosAtrasados";
            this.dgvLivrosAtrasados.Size = new System.Drawing.Size(547, 357);
            this.dgvLivrosAtrasados.TabIndex = 0;
            // 
            // FrmLivrosAtrasados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 381);
            this.Controls.Add(this.dgvLivrosAtrasados);
            this.Name = "FrmLivrosAtrasados";
            this.Text = "Livros Atrasados";
            this.Load += new System.EventHandler(this.FrmLivrosAtrasados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivrosAtrasados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLivrosAtrasados;
    }
}