using apBiblioteca.BLL;
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
    public partial class FrmDevolucoes : Form
    {


        public string servidor, banco, usuario, senha;

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (txtIdLeitor.Text != "" && txtIdLivro.Text != "") //se os dados ja foram preenchidos
            {
                var bll = new EmprestimoBLL(servidor, banco, usuario, senha); //cria a bll com os dados de conexão

                string data = dtpDataDevolucaoPrevista.Value.ToString("yyyy-MM-dd"); //formata a data 
                int idLivro = int.Parse(txtIdLivro.Text); // obtem os valores dos inputs
                int idLeitor = int.Parse(txtIdLeitor.Text);

                if(bll.Devlover(idLivro, idLeitor, data)) // tenta devolver o livro
                {
                    txtIdLeitor.Text = ""; // limpa os inputs
                    txtIdLivro.Text = "";

                    MessageBox.Show("Livro devolvido com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro! Data de devolução deve ser igual ou maior que a de empréstimo.");
                }
            }
        }

        private void btnCriarEmprestimo_Click(object sender, EventArgs e)
        {
            
        }

        public FrmDevolucoes()
        {
            InitializeComponent();
        }

        private void FrmDevolucoes_Load(object sender, EventArgs e)
        {

        }
    }
}
