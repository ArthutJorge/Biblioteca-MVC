using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    class LeitorDAL
    {

        string _cadeiaDeConexao = "";
        SqlConnection _conexao = null;

        public LeitorDAL(string servidor, string banco,
                        string usuario, string senha)
        {
            _cadeiaDeConexao = $"Data Source={servidor}; " +
                               $"Initial Catalog={banco}; " +
                               $"User Id={usuario}; " +
                               $"Password={senha};";
            _conexao = new SqlConnection(_cadeiaDeConexao);
        }

        public int SelectUltimoIdLeitor()
        {
            try
            {
                int ultimoId = -1;
                var cmd = new SqlCommand("SELECT MAX(idLeitor) AS UltimoId FROM mvc.Leitor WHERE ativo = 1", _conexao); // seleciona ultimo idLeitor criado
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader();   // result set --> resultado do select
                if (dr.Read())
                {
                    ultimoId = Convert.ToInt32(dr["UltimoId"]);
                }
                _conexao.Close();
                return ultimoId;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar leitor " + ex.Message);
            }
        }
        public List<Leitor> SelectListLeitores()
        {
            try
            {
                var cmd = new SqlCommand("Select * from mvc.leitor WHERE ativo = 1", _conexao); // seleciona todos leitores
                _conexao.Open();
                var listaLeitor = new List<Leitor>();
                SqlDataReader dr = cmd.ExecuteReader();   // result set --> resultado do select
                while (dr.Read())   // lê o próximo registro do result set
                {
                    var leitor = new Leitor((int)dr["IdLeitor"],
                                               dr["nomeLeitor"].ToString(),
                                               dr["telefoneLeitor"].ToString(),
                                               dr["emailLeitor"].ToString(),
                                               dr["enderecoLeitor"].ToString()
                                         );
                    listaLeitor.Add(leitor); // adiciona na lista
                }
                _conexao.Close();
                return listaLeitor;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar leitor " + ex.Message);
            }
        }


        public int QuantidadeTotalDeLeitores()
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM mvc.Leitor WHERE ativo = 1";  // seleciona todos leitores ativos
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                _conexao.Open();
                int totalLeitores = (int)cmd.ExecuteScalar();
                _conexao.Close();
                return totalLeitores;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao contar total de leitores: " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }

        public DataTable SelectLeitores()
        {
            try
            {
                string sql =
                  "SELECT idLeitor, TRIM(nomeLeitor), telefoneLeitor, TRIM(emailLeitor), TRIM(enderecoLeitor) " +
                  " FROM mvc.leitor WHERE ativo = 1"; // seleciona dados dos leitores
                SqlCommand executorDeComandosSQL =
                                      new SqlCommand(sql, _conexao);
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
                throw ex;
            }
        }



        public Leitor SelectNextById(int id)
        {
            try
            {
                _conexao.Open();
                // Procura o próximo leitor, se não encontrar procura um leitor anterior
                var cmd = new SqlCommand(@"
                    SELECT TOP 1 * 
                    FROM (
                        SELECT * FROM mvc.leitor WHERE ativo = 1 AND idLeitor > @id
                        UNION
                        SELECT * FROM mvc.leitor WHERE ativo = 1 AND idLeitor < @id
                    ) AS Combined
                    ORDER BY CASE 
                        WHEN idLeitor > @id THEN idLeitor - @id 
                        ELSE @id - idLeitor 
                    END, idLeitor", _conexao);

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Leitor leitor = new Leitor(Convert.ToInt32(dr["idLeitor"]),
                                dr["nomeLeitor"].ToString(),
                                dr["telefoneLeitor"].ToString(),
                                dr["emailLeitor"].ToString(),
                                dr["enderecoLeitor"].ToString());
                    dr.Close();
                    return leitor;
                }

                dr.Close();
                return null; // se não encontrado retorna nulo
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar leitor " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }


        public Leitor SelectLeitorById(int idDesejado)
        {
            try
            {
                string sql = "SELECT IdLeitor, nomeLeitor, telefoneLeitor, emailLeitor, enderecoLeitor " +
                             " FROM mvc.leitor WHERE IdLeitor = @id";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@id", idDesejado);
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Leitor leitor = null;
                if (dr.Read())
                {
                    leitor = new Leitor((int)dr["IdLeitor"],
                                               dr["nomeLeitor"] + "",
                                               dr["telefoneLeitor"].ToString(),
                                               dr["emailLeitor"].ToString(),
                                               dr["enderecoLeitor"].ToString()
                                         );
                }
                _conexao.Close();
                return leitor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Leitor SelectLeitorByName(string nomeDesejado)
        {
            try
            {
                string sql = " SELECT IdLeitor, nomeLeitor, telefoneLeitor, emailLeitor, enderecoLeitor " +
                " FROM mvc.leitor WHERE nomeLeitor = @nome AND ativo = 1";
                var cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@nome", nomeDesejado);
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Leitor leitor = null;
                if (dr.Read())
                    leitor = new Leitor((int)dr["IdLeitor"],
                                               dr["nomeLeitor"] + "",
                                               dr["telefoneLeitor"].ToString(),
                                               dr["emailLeitor"].ToString(),
                                               dr["enderecoLeitor"].ToString()
                                         );
                _conexao.Close();
                return leitor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertLeitor(Leitor qualLeitor)
        {
            try
            {
                string sql = "INSERT INTO mvc.leitor " +
                " (nomeLeitor, telefoneLeitor, emailLeitor, enderecoLeitor) " +
                " VALUES (@nome, @telefone, @email, @endereco) ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@nome", qualLeitor.NomeLeitor);
                cmd.Parameters.AddWithValue("@telefone", qualLeitor.TelefoneLeitor);
                cmd.Parameters.AddWithValue("@email", qualLeitor.EmailLeitor);
                cmd.Parameters.AddWithValue("@endereco", qualLeitor.EnderecoLeitor);
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

        public void UpdateLeitor(Leitor qualLeitor)
        {
            try
            {
                string sql = "UPDATE mvc.leitor " +
                " SET nomeLeitor= @nome, telefoneLeitor=@telefone," +
                " emailLeitor=@email, enderecoLeitor=@endereco " +
                " WHERE IdLeitor = @id ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@id", qualLeitor.IdLeitor);
                cmd.Parameters.AddWithValue("@nome", qualLeitor.NomeLeitor);
                cmd.Parameters.AddWithValue("@telefone", qualLeitor.TelefoneLeitor);
                cmd.Parameters.AddWithValue("@email", qualLeitor.EmailLeitor);
                cmd.Parameters.AddWithValue("@endereco", qualLeitor.EnderecoLeitor);
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

        public void DeleteLeitor(Leitor qualLeitor)
        {
            try 
            { // muda estado de ativo para 0 em vez de realizar um delete para evitar a perda de dados dos empréstimos 
                String sql = "UPDATE mvc.Leitor set ativo = 0 WHERE idLeitor = @idLeitor ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", qualLeitor.IdLeitor);
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


        public bool PodeEmprestar(int id)
        { // se o leitor está ativo e não está emprestando 5 livros atualmente
            try
            {
                String sql = @"
                    SELECT CASE 
                        WHEN (
                            SELECT COUNT(*) 
                            FROM MVC.Emprestimo 
                            WHERE idLeitor = @idLeitor
                            AND (dataDevolucaoReal IS NULL OR dataDevolucaoReal = '') 
                        ) > 4 OR (
                            SELECT ativo 
                            FROM MVC.Leitor 
                            WHERE idLeitor = @idLeitor
                        ) = 0
                        THEN 'false'
                        ELSE 'true'
                    END AS pode_ser_emprestado;";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", id);
                _conexao.Open();
                string resultado = (string)cmd.ExecuteScalar();
                _conexao.Close();

                return resultado == "true";

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
