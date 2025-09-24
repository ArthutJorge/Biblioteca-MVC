using System;
using System.Collections.Generic;
using System.Data;
using apBiblioteca;
using DAL;
using DTO;


namespace BLL
{
  class LivroBLL
  {
        public string servidor, banco, usuario, senha;
        LivroDAL dal = null;
        public LivroBLL(string servidor, string banco, string usuario, string senha)
        {
            this.servidor = servidor;
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public int SelecionarUltimoIdLivro()
        {
            int ultimoId = -1;
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                ultimoId = dal.SelectUltimoIdLivro();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ultimoId;
        }


        public int QuantosLivros()
        {
            int qtos = -1;
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                qtos = dal.QuantidadeTotalDeLivros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return qtos;
        }


        public int QuantosLivrosNaoDevolvidos()
        {
            int qtos = -1;
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                qtos = dal.QuantidadeDeLivrosNaoDevolvidos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return qtos;
        }

        public Livro ProcurarProximo(int id)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                return dal.SelectNextById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelecionarLivros()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                tb = dal.SelectLivros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }

        public DataTable SelectLivrosEmprestados()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                tb = dal.SelectLivrosEmprestados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return tb;
        }

        public DataTable SelectLivrosAtrasados()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                tb = dal.SelectLivrosAtrasados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return tb;
        }


        public void IncluirLivro(Livro livro)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                dal.InsertLivro(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AlterarLivro(Livro livro)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                dal.UpdateLivro(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExcluirLivro(Livro livro)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                dal.DeleteLivro(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Livro> ListarLivros()
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                return dal.SelectListLivros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Livro ListarLivroPorId(int id)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                return dal.SelectLivroById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Livro ListarLivroPorCodigo(string codigo)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                return dal.SelectLivroByCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool podeSerEmprestado(int id)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                return dal.PodeSerEmprestado(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
