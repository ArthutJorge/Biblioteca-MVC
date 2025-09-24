using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DTO;
using BLL;
using apBiblioteca.BLL;

namespace apBiblioteca.UI
{
  public partial class FrmLivro : Form
  {
        public string servidor, banco, usuario, senha;

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtCodigoLivro.Text != "" && txtTituloLivro.Text != ""
              && txtAutorLivro.Text != "")  //se os dados foram preencidos
            {
                var livro = new Livro(0, txtCodigoLivro.Text, txtTituloLivro.Text, txtAutorLivro.Text);  //cria um livro com todos os dados dos inputs
                try
                {
                    var bll = new LivroBLL(servidor, banco, usuario, senha);
                    bll.IncluirLivro(livro);  //inclui o livro
                    txtIdLivro.Text = bll.SelecionarUltimoIdLivro().ToString();  //seleciona o livro para exibi-lo
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Preencha os campos de dados.");
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoLivro.Text; //obtem o codigo a ser procurado
            var livro = new Livro(0, codigo, "", "");  //cria um livro com tal codigo
            try
            {
                var bll = new LivroBLL(servidor, banco, usuario, senha);
                livro = bll.ListarLivroPorCodigo(codigo);  // procura tal livro no banco de dados e o guarda em uma variavel
                if(livro != null)
                    Exibir(livro);  //exibe tal livro
                else
                    MessageBox.Show("Livro não encontrado");  //aviso de que tal nao existe
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdLivro.Text != "") //se o id ja estiver exibido
            {
                var livro = new Livro(Convert.ToInt32(txtIdLivro.Text), "", "", ""); //cria um livro com tal id
                try
                {
                    var bll = new LivroBLL(servidor, banco, usuario, senha);
                    bll.ExcluirLivro(livro); //exclui o livro (ativo = 0)
                    Livro ProximoLivro = bll.ProcurarProximo(Convert.ToInt32(txtIdLivro.Text)); //procura o proximo livro para exibir
                    if (ProximoLivro != null)
                        Exibir(ProximoLivro); //exibe o proximo livro
                    else
                        Limpar();  // se nao tiver nenhum livro, simplesmente limpa a tela

                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Selecione um livro primeiro");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtIdLivro.Text != "" && txtCodigoLivro.Text != "" && txtTituloLivro.Text != "" && txtAutorLivro.Text != "") //se os dados foram preenchidos
            {
                var livro = new Livro(int.Parse(txtIdLivro.Text),
               txtCodigoLivro.Text,
               txtTituloLivro.Text,
               txtAutorLivro.Text);  //cria novo livro com os dados dos inputs
                try
                {
                    var bll = new LivroBLL(servidor, banco, usuario, senha);
                    bll.AlterarLivro(livro);
                    MessageBox.Show("Dados alterados com sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Preencha os dados primeiro");
        }

        private void tpLista_Enter(object sender, EventArgs e)
        {
            try
            {
                var bll = new LivroBLL(servidor, banco, usuario, senha);
                dgvLivro.DataSource = bll.SelecionarLivros();  //obtem todos os livros
                dgvLivro.Columns[0].HeaderText = "Identificação"; //dá nomes as coluns
                dgvLivro.Columns[1].HeaderText = "Código";
                dgvLivro.Columns[2].HeaderText = "Título";
                dgvLivro.Columns[3].HeaderText = "Autor(es)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void Exibir(Livro livro)
        {
            txtIdLivro.Text = livro.IdLivro.ToString();  //exibe um determinado livro
            txtCodigoLivro.Text = livro.CodigoLivro;
            txtTituloLivro.Text = livro.TituloLivro;
            txtAutorLivro.Text = livro.AutorLivro;
        }

        private void tpLista_Enter_1(object sender, EventArgs e)
        {
            var bll = new LivroBLL(servidor, banco, usuario, senha);
            try
            {
                dgvLivro.DataSource = bll.SelecionarLivros();  //seleciona todos os livros e adicona como dados da DGV

                dgvLivro.Columns[0].HeaderText = "ID";  //dá nome às colunas
                dgvLivro.Columns[1].HeaderText = "Codigo";
                dgvLivro.Columns[2].HeaderText = "Título";
                dgvLivro.Columns[3].HeaderText = "Autor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void Limpar()
        {
            txtIdLivro.Text = "";  //limpa os inputs
            txtCodigoLivro.Text = "";
            txtTituloLivro.Text = "";
            txtAutorLivro.Text = "";
        }

        public FrmLivro()
        {
            InitializeComponent();
        }

        private void FrmLivro_Load(object sender, EventArgs e)
        {

        }
    }
}
