using apBiblioteca.BLL;
using BLL;
using DTO;
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
  public partial class FrmLeitor : Form
  {
        public string servidor, banco, usuario, senha;

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtNomeLeitor.Text != "" && txtEnderecoLeitor.Text != "" && txtEmailLeitor.Text != "" && txtTelefoneLeitor.Text != "") //se dados preenchidos
            {
                var leitor = new Leitor(0, txtNomeLeitor.Text, txtTelefoneLeitor.Text, txtEmailLeitor.Text, txtEnderecoLeitor.Text);  //cria leitor com os dados
                try
                {
                    var bll = new LeitorBLL(servidor, banco, usuario, senha);
                    bll.IncluirLeitor(leitor);  //inclui o leitor pela camada BLL
                    txtIdLeitor.Text = bll.SelecionarUltimoIdLeitor().ToString();  //muda o id exibido para o id do livro incluido
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
            var leitor = new Leitor(0, "", "", "","");
            try
            {
                var bll = new LeitorBLL(servidor, banco, usuario, senha);
                leitor = bll.ListarLivroPorId(Convert.ToInt32(txtIdLeitor.Text));
                if (leitor != null)
                    Exibir(leitor); //exibe o leitor procurado
                else
                    MessageBox.Show("Leitor não encontrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdLeitor.Text != "")  // se o id foi preenchido
            {
                var leitor = new Leitor(Convert.ToInt32(txtIdLeitor.Text), "", "", "",""); // cria um leitor com o mesmo id
                try
                {
                    var bll = new LeitorBLL(servidor, banco, usuario, senha);
                    bll.ExcluirLeitor(leitor);  // exclui o leitor (inativa ele)
                    Leitor ProximoLeitor= bll.ProcurarProximo(Convert.ToInt32(txtIdLeitor.Text));  //procura o proximo leitor para exibir
                    if (ProximoLeitor != null) //se houver proximo leitor
                        Exibir(ProximoLeitor);  //exibe o leitor
                    else
                        Limpar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Selecione um leitor primeiro");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNomeLeitor.Text != "" && txtEnderecoLeitor.Text != "" && txtEmailLeitor.Text != "" && txtTelefoneLeitor.Text != "")  // se os dados estão preenchidos
            {
                var leitor = new Leitor(int.Parse(txtIdLeitor.Text),  
               txtNomeLeitor.Text,
               txtTelefoneLeitor.Text,
               txtEmailLeitor.Text,
               txtEnderecoLeitor.Text);  //cria leitor com os dados
                try
                {
                    var bll = new LeitorBLL(servidor, banco, usuario, senha);
                    bll.AlterarLeitor(leitor);
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

        private void Exibir(Leitor leitor)
        {
            txtIdLeitor.Text = leitor.IdLeitor.ToString();     //exibe os dados de determinado leitor
            txtNomeLeitor.Text = leitor.NomeLeitor.ToString();
            txtEnderecoLeitor.Text = leitor.EnderecoLeitor.ToString();
            txtTelefoneLeitor.Text = leitor.TelefoneLeitor.ToString();
            txtEmailLeitor.Text = leitor.EmailLeitor.ToString();
        }

        private void tpLista_Enter(object sender, EventArgs e)
        {
            var bll = new LeitorBLL(servidor, banco, usuario, senha); //cria uma bll com os dados de conexão

            dgvLeitor.DataSource = bll.SelecionarLeitores();  // faz com que os dados da dgv seja os leitores do BD

            dgvLeitor.Columns[0].HeaderText = "Identificação";  //dá nome as colunas
            dgvLeitor.Columns[1].HeaderText = "Nome";
            dgvLeitor.Columns[2].HeaderText = "Telefone";
            dgvLeitor.Columns[3].HeaderText = "Email";
            dgvLeitor.Columns[4].HeaderText = "Endereço";
        }

        private void Limpar()
        {
            txtIdLeitor.Text = ""; // limpa todos os inputs
            txtNomeLeitor.Text = "";
            txtEnderecoLeitor.Text = "";
            txtTelefoneLeitor.Text = "";
            txtEmailLeitor.Text = "";
        }

        public FrmLeitor()
        {
            InitializeComponent();
        }

        private void FrmLeitor_Load(object sender, EventArgs e)
        {

        }

       
    }
  }
