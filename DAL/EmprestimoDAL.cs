using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apBiblioteca.DAL
{
    internal class EmprestimoDAL
    {

        string _cadeiaDeConexao = "";
        SqlConnection _conexao = null;

        public EmprestimoDAL(string servidor, string banco,
                        string usuario, string senha)
        {
            _cadeiaDeConexao = $"Data Source={servidor}; " +
                               $"Initial Catalog={banco}; " +
                               $"User Id={usuario}; " +
                               $"Password={senha};";
            _conexao = new SqlConnection(_cadeiaDeConexao);
        }

        public List<Emprestimo> SelectListEmprestimos()
        {
            try
            {
                var cmd = new SqlCommand("Select * from mvc.emprestimo", _conexao); // seleciona todos dados do emprestimo
                _conexao.Open();
                var listaEmprestimos = new List<Emprestimo>();
                SqlDataReader dr = cmd.ExecuteReader();   // result set --> resultado do select
                while (dr.Read())   // lê o próximo registro do result set
                {
                    var emprestimo = new Emprestimo((int)dr["idEmprestimo"],
                                               Convert.ToInt32(dr["idLivro"]),
                                               Convert.ToInt32(dr["idLeitor"]),
                                               Convert.ToDateTime(dr["dataEmprestimo"]),
                                               Convert.ToDateTime(dr["dataDevolucaoPrevista"]),
                                               Convert.ToDateTime(dr["dataDevolucaoReal"])
                                         );
                    listaEmprestimos.Add(emprestimo); // adiciona na lista
                }
                _conexao.Close();
                return listaEmprestimos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar livro " + ex.Message);
            }
        }

        public void InsertEmprestimo(Emprestimo qualEmprestimo)
        {
            try
            {
                string sql = "INSERT INTO mvc.Emprestimo " + // insere empréstimo
                " (idLivro, idLeitor, dataEmprestimo, dataDevolucaoPrevista, dataDevolucaoReal) " +
                " VALUES (@idLivro, @idLeitor, @dataEmprestimo, @dataDevolucaoPrevista, @dataDevolucaoReal) ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", qualEmprestimo.IdLivro);
                cmd.Parameters.AddWithValue("@idLeitor", qualEmprestimo.IdLeitor);
                cmd.Parameters.AddWithValue("@dataEmprestimo", qualEmprestimo.DataEmprestimo);
                cmd.Parameters.AddWithValue("@dataDevolucaoPrevista", qualEmprestimo.DataDevolucaoPrevista);
                if (qualEmprestimo.DataDevolucaoReal == null) // se ainda não foi devolvido, devolução é nula
                    cmd.Parameters.AddWithValue("@dataDevolucaoReal", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@dataDevolucaoReal", qualEmprestimo.DataDevolucaoReal);
                _conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public DataTable SelectEmprestimos()
        {
            try
            {
                string sql = // seleciona informações do leitor, livro e do empréstimo
                  "SELECT e.idEmprestimo, " +
                  "       l.idLivro, " +
                  "       le.idLeitor, " +
                  "       TRIM(l.tituloLivro) AS tituloLivro, " +
                  "       TRIM(le.nomeLeitor) AS nomeLeitor, " +
                  "       e.dataEmprestimo, " +
                  "       e.dataDevolucaoPrevista, " +
                  "       e.dataDevolucaoReal " +
                  "FROM mvc.Emprestimo e " +
                  "JOIN mvc.Livro l ON e.idLivro = l.idLivro " +
                  "JOIN mvc.Leitor le ON e.idLeitor = le.idLeitor";

                SqlCommand executorDeComandosSQL = new SqlCommand(sql, _conexao);
                _conexao.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = executorDeComandosSQL;
                DataTable dt = new DataTable();
                da.Fill(dt);    // busca os registros usando o SelectCommand 
                                // e os armazena no DataTable dt
                _conexao.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar empréstimos: " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }


        public int QuantosEmprestimos()
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM mvc.emprestimo"; 

                SqlCommand executorDeComandosSQL = new SqlCommand(sql, _conexao);
                _conexao.Open();
                int count = (int)executorDeComandosSQL.ExecuteScalar();
                _conexao.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar empréstimos: " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }

        public int QuantidadeEmprestimosDeHoje()
        {
            try
            {
                string sql =
                  "SELECT COUNT(*) FROM mvc.emprestimo " +
                  "WHERE CONVERT(date, dataEmprestimo) = CONVERT(date, GETDATE())";

                SqlCommand executorDeComandosSQL = new SqlCommand(sql, _conexao);
                _conexao.Open();
                int count = (int)executorDeComandosSQL.ExecuteScalar();
                _conexao.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar empréstimos de hoje: " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }

        public int QuantidadeEmprestimosDesteMes()
        {
            try
            {
                string sql =
                  "SELECT COUNT(*) FROM mvc.emprestimo " +
                  "WHERE YEAR(dataEmprestimo) = YEAR(GETDATE()) AND MONTH(dataEmprestimo) = MONTH(GETDATE())";

                SqlCommand executorDeComandosSQL = new SqlCommand(sql, _conexao);
                _conexao.Open();
                int count = (int)executorDeComandosSQL.ExecuteScalar();
                _conexao.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar empréstimos deste mês: " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }

        public int QuantidadeEmprestimosDesteAno()
        {
            try
            {
                string sql =
                  "SELECT COUNT(*) FROM mvc.emprestimo " +
                  "WHERE YEAR(dataEmprestimo) = YEAR(GETDATE())";

                SqlCommand executorDeComandosSQL = new SqlCommand(sql, _conexao);
                _conexao.Open();
                int count = (int)executorDeComandosSQL.ExecuteScalar();
                _conexao.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar empréstimos deste ano: " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }



        public bool Devolver(int idLivro, int idLeitor, string dataDevolucaoReal)
        {
            try
            {
                string sqlSelect = @"select dataEmprestimo from MVC.emprestimo where idLeitor = @idLeitor and idLivro = @idLivro";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, _conexao);
                cmdSelect.Parameters.AddWithValue("@idLeitor", idLeitor);
                cmdSelect.Parameters.AddWithValue("@idLivro", idLivro);

                _conexao.Open();
                object result = cmdSelect.ExecuteScalar();

                if (result != null)
                {
                    DateTime dataEmprestimo = Convert.ToDateTime(result);
                    DateTime dataDevolucao = Convert.ToDateTime(dataDevolucaoReal);

                    if (dataDevolucao < dataEmprestimo) // se a data de devolução for anterior ao dia que foi emprestado
                        return false; 

                    string sqlUpdate = @"update MVC.emprestimo set dataDevolucaoReal = @dataDevolucaoReal where idLeitor = @idLeitor and idLivro = @idLivro";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, _conexao);
                    cmdUpdate.Parameters.AddWithValue("@dataDevolucaoReal", dataDevolucaoReal);
                    cmdUpdate.Parameters.AddWithValue("@idLeitor", idLeitor);
                    cmdUpdate.Parameters.AddWithValue("@idLivro", idLivro);

                    cmdUpdate.ExecuteNonQuery();
                    return true;
                }
                else
                    return false; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }





    }
}
