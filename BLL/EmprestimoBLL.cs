using apBiblioteca.DAL;
using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apBiblioteca.BLL
{
    class EmprestimoBLL
    {
        public string servidor, banco, usuario, senha;
        EmprestimoDAL dal = null;

        public EmprestimoBLL(string servidor, string banco, string usuario, string senha)
        {
            this.servidor = servidor;
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public bool IncluirEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                dal = new DAL.EmprestimoDAL(servidor, banco, usuario, senha);

                LivroBLL livroBll = new LivroBLL(servidor, banco, usuario, senha);
                LeitorBLL leitorBll = new LeitorBLL(servidor, banco, usuario, senha);

                if(leitorBll.podeEmprestar(emprestimo.IdLeitor) && livroBll.podeSerEmprestado(emprestimo.IdLivro)) // verifica se livro pode ser emprestado e leitor pode emprestar
                {
                    dal.InsertEmprestimo(emprestimo);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelecionarEmprestimos()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new DAL.EmprestimoDAL(servidor, banco, usuario, senha);
                tb = dal.SelectEmprestimos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }


        public bool Devlover(int idLivro, int idLeitor, string data)
        {
            try
            {
                dal = new DAL.EmprestimoDAL(servidor, banco, usuario, senha);
                return dal.Devolver(idLivro, idLeitor, data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int QuantosEmprestimos()
        {
            int qtos = -1;
            try
            {
                dal = new DAL.EmprestimoDAL(servidor, banco, usuario, senha);
                qtos = dal.QuantosEmprestimos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return qtos;
        }


        public int QuantosEmprestimosAno()
        {
            int qtos = -1;
            try
            {
                dal = new DAL.EmprestimoDAL(servidor, banco, usuario, senha);
                qtos = dal.QuantidadeEmprestimosDesteAno();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return qtos;
        }



        public int QuantosEmprestimosMes()
        {
            int qtos = -1;
            try
            {
                dal = new DAL.EmprestimoDAL(servidor, banco, usuario, senha);
                qtos = dal.QuantidadeEmprestimosDesteMes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return qtos;
        }

        public int QuantosEmprestimosHoje()
        {
            int qtos = -1;
            try
            {
                dal = new DAL.EmprestimoDAL(servidor, banco, usuario, senha);
                qtos = dal.QuantidadeEmprestimosDeHoje();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return qtos;
        }


    }
}
