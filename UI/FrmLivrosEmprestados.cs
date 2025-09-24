using apBiblioteca.BLL;
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
    public partial class FrmLivrosEmprestados : Form
    {

        public string servidor, banco, usuario, senha;

        public FrmLivrosEmprestados()
        {
            InitializeComponent();
        }

        private void FrmLivrosEmprestados_Load(object sender, EventArgs e)
        {
            var bll = new LivroBLL(servidor, banco, usuario, senha);
            try
            {
                dgvLivrosEmprestados.DataSource = bll.SelectLivrosEmprestados();  //obtem todos os livros atualmente emprestados

                dgvLivrosEmprestados.Columns[0].HeaderText = "Id livro";  //dá nome às colunas
                dgvLivrosEmprestados.Columns[1].HeaderText = "Código livro";
                dgvLivrosEmprestados.Columns[2].HeaderText = "Título livro";
                dgvLivrosEmprestados.Columns[3].HeaderText = "Autor livro";
                dgvLivrosEmprestados.Columns[4].HeaderText = "Data de empréstimo";
                dgvLivrosEmprestados.Columns[5].HeaderText = "Data de devolução esperada";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
