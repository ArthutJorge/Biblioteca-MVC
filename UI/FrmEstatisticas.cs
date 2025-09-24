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
    public partial class FrmEstatisticas : Form
    {

        public  string servidor, banco, usuario, senha;

        public FrmEstatisticas()
        {
            InitializeComponent();
        }

        private void FrmEstatisticas_Load(object sender, EventArgs e)
        {
            try
            {
                var bll1 = new EmprestimoBLL(servidor, banco, usuario, senha);  //para cada txt, cria uma bll especializada e obtem os dados numericos
                int qtosEmprestimos = bll1.QuantosEmprestimos();
                txtEmprestimosCriados.Text = qtosEmprestimos.ToString(); // exibe os dados

                var bll2 = new LivroBLL(servidor, banco, usuario, senha);
                int qtosLivros = bll2.QuantosLivros();
                txtLivros.Text = qtosLivros.ToString();

                var bll3 = new LeitorBLL(servidor, banco, usuario, senha);
                int qtosLeitores = bll3.QuantosLeitores();
                txtLeitores.Text = qtosLeitores.ToString();

                var bll4 = new LivroBLL(servidor, banco, usuario, senha);
                int qtosLivrosNDevolvidos = bll4.QuantosLivrosNaoDevolvidos();
                txtLivrosNDevolvidos.Text = qtosLivrosNDevolvidos.ToString();

                var bll5 = new EmprestimoBLL(servidor, banco, usuario, senha);
                int qtosEmprestimosAno = bll5.QuantosEmprestimosAno();
                txtEmprestimosAno.Text = qtosEmprestimosAno.ToString();

                var bll6 = new EmprestimoBLL(servidor, banco, usuario, senha);
                int qtosEmprestimosMes = bll6.QuantosEmprestimosMes();
                txtEmprestimosMes.Text = qtosEmprestimosMes.ToString();

                var bll7 = new EmprestimoBLL(servidor, banco, usuario, senha);
                int qtosEmprestimosHoje = bll7.QuantosEmprestimosHoje();
                txtEmprestimosHoje.Text = qtosEmprestimosHoje.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }
    }
}
