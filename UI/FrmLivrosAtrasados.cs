using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apBiblioteca.UI
{
    public partial class FrmLivrosAtrasados : Form
    {
        public string servidor, banco, usuario, senha;

        public FrmLivrosAtrasados()
        {
            InitializeComponent();
        }

        private void FrmLivrosAtrasados_Load(object sender, EventArgs e)
        {
            var bll = new LivroBLL(servidor, banco, usuario, senha);
            try
            {
                dgvLivrosAtrasados.DataSource = bll.SelectLivrosAtrasados();  //obtem todo os livros atrasados

                dgvLivrosAtrasados.Columns[0].HeaderText = "Id livro"; //dá nome às colunas
                dgvLivrosAtrasados.Columns[1].HeaderText = "Código livro";
                dgvLivrosAtrasados.Columns[2].HeaderText = "Título livro";
                dgvLivrosAtrasados.Columns[3].HeaderText = "Autor livro";
                dgvLivrosAtrasados.Columns[4].HeaderText = "Data de empréstimo";
                dgvLivrosAtrasados.Columns[5].HeaderText = "Dias de atraso";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
