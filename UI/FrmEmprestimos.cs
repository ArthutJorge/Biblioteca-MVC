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
    public partial class FrmEmprestimos : Form
    {

        public string servidor, banco, usuario, senha;

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            
        }

        private void tpLista_Enter(object sender, EventArgs e)
        {
            var bll = new EmprestimoBLL(servidor, banco, usuario, senha);
            try
            {
                dgvEmpréstimos.DataSource = bll.SelecionarEmprestimos();  //obtem todos os emprestimos

                dgvEmpréstimos.Columns[0].HeaderText = "Id empréstimo";  //dá nome as colunas
                dgvEmpréstimos.Columns[1].HeaderText = "Id livro";
                dgvEmpréstimos.Columns[2].HeaderText = "Id leitor";
                dgvEmpréstimos.Columns[3].HeaderText = "Titulo livro";
                dgvEmpréstimos.Columns[4].HeaderText = "Nome leitor";
                dgvEmpréstimos.Columns[5].HeaderText = "Data empréstimo";
                dgvEmpréstimos.Columns[6].HeaderText = "Data devolução prevista";
                dgvEmpréstimos.Columns[7].HeaderText = "Data devolução real";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }


        private void btnCriarEmprestimo_Click(object sender, EventArgs e) //criar emprestimo
        {
            if (txtIdLeitor.Text != "" && txtIdLivro.Text != "") //se os dados foram preenchidos
            {
                if (dtpDataEmprestimo.Value.Date <= dtpDataDevolucaoPrevista.Value.Date)  
                    //certifica que a data de devolucao é fisicamente possivel (igual ou maior que a do emprestimo)
                {
                    var emprestimo = new Emprestimo(0, Convert.ToInt32(txtIdLivro.Text), Convert.ToInt32(txtIdLeitor.Text), 
                    dtpDataEmprestimo.Value, dtpDataDevolucaoPrevista.Value, null); //cria um emprestimo com os valores dos inputs

                    try
                    {
                        var bll = new EmprestimoBLL(servidor, banco, usuario, senha);
                        if (bll.IncluirEmprestimo(emprestimo)) //tenta incluir o emprestimo
                        {
                            txtIdLeitor.Text = "";  // limpa os inputs
                            txtIdLivro.Text = "";
                            MessageBox.Show("Empréstimo criado!");
                        }
                        else
                        {
                            MessageBox.Show("Empréstimo inválido. O livro está em uso ou o leitor já pegou seu limite de livros.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("A data de empréstimo deve ser menor ou igual à data de devolução prevista.");
                }
            }
            else
            {
                MessageBox.Show("Preencha os dados primeiro");
            }
        }



        public FrmEmprestimos()
        {
            InitializeComponent();
        }

        private void FrmEmprestimos_Load(object sender, EventArgs e)
        {

        }
    }
}
