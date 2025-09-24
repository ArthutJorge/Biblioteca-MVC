using apBiblioteca.UI;
using System;
using System.Windows.Forms;

namespace apBiblioteca
{
    public partial class FrmBiblioteca : Form
    {
        private string servidor, banco, usuario, senha;

        public FrmBiblioteca()
        {
            InitializeComponent();
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmLivro());
        }

        private void leitoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmLeitor());
        }

        private void FrmBiblioteca_Load(object sender, EventArgs e)
        {

        }

        private void livrosEmprestadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmLivrosEmprestados());
        }

        private void livrosAtrasadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmLivrosAtrasados());
        }

        private void estatísticasDeEmpréstimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEstatisticas());
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void empréstimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEmprestimos());
        }

        private void devoluçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDevolucoes());
        }

        private void AbrirFormulario(Form formulario)
        {
            if (txtServidor.Text == "" || txtBD.Text == "" ||
                txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão!");  //verifica se os dados de conexão estão preenchidos

            else
            {
                if (formulario is FrmLivro)  //verifica qual é o formulario
                {
                    var frmLivro = (FrmLivro)formulario;
                    frmLivro.servidor = txtServidor.Text;  //preenche os dados de banco de dados da classe
                    frmLivro.banco = txtBD.Text;
                    frmLivro.usuario = txtUsuario.Text;
                    frmLivro.senha = txtSenha.Text;
                }
                else if (formulario is FrmLeitor)
                {
                    var frmLeitor = (FrmLeitor)formulario;
                    frmLeitor.servidor = txtServidor.Text;
                    frmLeitor.banco = txtBD.Text;
                    frmLeitor.usuario = txtUsuario.Text;
                    frmLeitor.senha = txtSenha.Text;
                }
                else if (formulario is FrmEmprestimos)
                {
                    var frmEmprestimos = (FrmEmprestimos)formulario;
                    frmEmprestimos.servidor = txtServidor.Text;
                    frmEmprestimos.banco = txtBD.Text;
                    frmEmprestimos.usuario = txtUsuario.Text;
                    frmEmprestimos.senha = txtSenha.Text;
                }
                else if (formulario is FrmDevolucoes)
                {
                    var frmDevolucoes = (FrmDevolucoes)formulario;
                    frmDevolucoes.servidor = txtServidor.Text;
                    frmDevolucoes.banco = txtBD.Text;
                    frmDevolucoes.usuario = txtUsuario.Text;
                    frmDevolucoes.senha = txtSenha.Text;
                }
                else if (formulario is FrmLivrosEmprestados)
                {
                    var frmLivrosEmprestados = (FrmLivrosEmprestados)formulario;
                    frmLivrosEmprestados.servidor = txtServidor.Text;
                    frmLivrosEmprestados.banco = txtBD.Text;
                    frmLivrosEmprestados.usuario = txtUsuario.Text;
                    frmLivrosEmprestados.senha = txtSenha.Text;
                }
                else if (formulario is FrmLivrosAtrasados)
                {
                    var frmLivrosAtrasados = (FrmLivrosAtrasados)formulario;
                    frmLivrosAtrasados.servidor = txtServidor.Text;
                    frmLivrosAtrasados.banco = txtBD.Text;
                    frmLivrosAtrasados.usuario = txtUsuario.Text;
                    frmLivrosAtrasados.senha = txtSenha.Text;
                }
                else if (formulario is FrmEstatisticas)
                {
                    var frmEstatisticas = (FrmEstatisticas)formulario;
                    frmEstatisticas.servidor = txtServidor.Text;
                    frmEstatisticas.banco = txtBD.Text;
                    frmEstatisticas.usuario = txtUsuario.Text;
                    frmEstatisticas.senha = txtSenha.Text;
                }

                formulario.Show(); //exibe o formulario passado como parametro
            }
        }
    }
}
