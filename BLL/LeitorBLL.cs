using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data;
using apBiblioteca;
using DAL;
using DTO;

namespace BLL
{
    class LeitorBLL
    {
        public string servidor, banco, usuario, senha;
        LeitorDAL dal = null;

        public LeitorBLL(string servidor, string banco, string usuario, string senha)
        {
            this.servidor = servidor;
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public int SelecionarUltimoIdLeitor()
        {
            int ultimoId = -1;
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                ultimoId = dal.SelectUltimoIdLeitor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ultimoId;
        }


        public int QuantosLeitores()
        {
            int qtos = -1;
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                qtos = dal.QuantidadeTotalDeLeitores();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return qtos;
        }


        public DataTable SelecionarLeitores()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                tb = dal.SelectLeitores();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }
        public void IncluirLeitor(Leitor leitor)
        {
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                dal.InsertLeitor(leitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AlterarLeitor(Leitor leitor)
        {
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                dal.UpdateLeitor(leitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExcluirLeitor(Leitor leitor)
        {
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                dal.DeleteLeitor(leitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Leitor> ListarLeitores()
        {
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                return dal.SelectListLeitores();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Leitor ListarLivroPorId(int id)
        {
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                return dal.SelectLeitorById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Leitor ListarLeitorPorNome(string nome)
        {
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                return dal.SelectLeitorByName(nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Leitor ProcurarProximo(int id)
        {
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                return dal.SelectNextById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool podeEmprestar(int id)
        {
            try
            {
                dal = new DAL.LeitorDAL(servidor, banco, usuario, senha);
                return dal.PodeEmprestar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
