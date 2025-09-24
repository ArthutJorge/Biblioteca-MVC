using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
  class LivroDAL
  {
        string _cadeiaDeConexao = "";
        SqlConnection _conexao = null;

        public LivroDAL(string servidor, string banco,
                        string usuario, string senha)
        {
            _cadeiaDeConexao = $"Data Source={servidor}; " +
                               $"Initial Catalog={banco}; " +
                               $"User Id={usuario}; " +
                               $"Password={senha};";
            _conexao = new SqlConnection(_cadeiaDeConexao);
        }

        public int SelectUltimoIdLivro()
        {
            try
            {
                int ultimoId = -1;
                var cmd = new SqlCommand("SELECT MAX(idLivro) AS UltimoId FROM mvc.Livro WHERE ativo = 1", _conexao); // seleciona último idLivro gerado pelo programa
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
                throw new Exception("Erro ao acessar livro " + ex.Message);
            }
        }
        public Livro SelectNextById(int id)
        {
            try
            {
                _conexao.Open();

                // Procura o próximo livro, se não encontrar procura um livro anterior
                var cmd = new SqlCommand(@"
                    SELECT TOP 1 * 
                    FROM (
                        SELECT * FROM mvc.Livro WHERE ativo = 1 AND idLivro > @id
                        UNION
                        SELECT * FROM mvc.Livro WHERE ativo = 1 AND idLivro < @id
                    ) AS Combined
                    ORDER BY CASE 
                        WHEN idLivro > @id THEN idLivro - @id 
                        ELSE @id - idLivro 
                    END, idLivro", _conexao);

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                Livro livro = new Livro(Convert.ToInt32(dr["idLivro"]),
                            dr["codigoLivro"].ToString(),
                            dr["tituloLivro"].ToString(),
                            dr["autorLIvro"].ToString());
                    dr.Close();
                    return livro;
                }

                dr.Close();
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar livro " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }
        public List<Livro> SelectListLivros()
        {
            try
            {
                var cmd = new SqlCommand("Select * from mvc.Livro WHERE ativo = 1", _conexao); // seleciona todos livros
                _conexao.Open();
                var listaLivros = new List<Livro>();
                SqlDataReader dr = cmd.ExecuteReader();   // result set --> resultado do select
                while (dr.Read())   // lê o próximo registro do result set
                {
                    var livro = new Livro((int)dr["idLivro"],
                                               dr["codigoLivro"] + "",
                                               dr["tituloLivro"].ToString(),
                                               Convert.ToString(dr["autorLivro"])
                                         );
                    listaLivros.Add(livro); // adiciona na lista
                }
                _conexao.Close();
                return listaLivros;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar livro " + ex.Message);
            }
        }


        public int QuantidadeTotalDeLivros()
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM mvc.Livro WHERE ativo = 1"; // seleciona todos livros ativos
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                _conexao.Open();
                int totalLivros = (int)cmd.ExecuteScalar();
                _conexao.Close();
                return totalLivros;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao contar total de livros: " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }


        public int QuantidadeDeLivrosNaoDevolvidos()
        {
            try
            {
                string sql =
                  "SELECT COUNT(*) FROM mvc.emprestimo " +
                  "WHERE dataDevolucaoReal IS NULL OR dataDevolucaoReal = ''";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                _conexao.Open();
                int livrosNaoDevolvidos = (int)cmd.ExecuteScalar();
                _conexao.Close();
                return livrosNaoDevolvidos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao contar livros não devolvidos: " + ex.Message);
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }


        public DataTable SelectLivros()
        {
            try
            {
                string sql =
                  "SELECT idLivro, TRIM(codigoLivro), TRIM(tituloLivro), TRIM(autorLivro) " +
                  " FROM mvc.Livro WHERE ativo = 1";
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

        public Livro SelectLivroById(int idDesejado)
        {
            try
            {
                string sql = "SELECT idLivro, codigoLivro, tituloLivro, autorLivro " +
                             " FROM mvc.Livro WHERE idLivro = @id AND ativo = 1";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@id", idDesejado);
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Livro livro = null;
                if (dr.Read())
                {
                    livro = new Livro(Convert.ToInt32(dr["idLivro"]),
                                    dr["codigoLivro"].ToString(),
                                    dr["tituloLivro"].ToString(),
                                    dr["autorLIvro"].ToString());
                }
                //_conexao.Close();
                return livro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Livro SelectLivroByCodigo(string codigoDesejado)
        {
            try
            {
                string sql = " SELECT idLivro, codigoLivro, tituloLivro, autorLivro " +
                " FROM mvc.Livro WHERE codigoLivro = @codigo AND ativo = 1";
                var cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@codigo", codigoDesejado);
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Livro livro = null;
                if (dr.Read())
                    livro = new Livro(Convert.ToInt32(dr["idLivro"]),
                                      dr["codigoLivro"].ToString(),
                                      dr["tituloLivro"].ToString(),
                                      dr["autorLIvro"].ToString());
                _conexao.Close();
                return livro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertLivro(Livro qualLivro)
        {
            try
            {
                string sql = "INSERT INTO mvc.Livro " +
                " (codigoLivro, tituloLivro, autorLivro, ativo) " +
                " VALUES (@codigo, @titulo, @autor, 1) ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@codigo", qualLivro.CodigoLivro);
                cmd.Parameters.AddWithValue("@titulo", qualLivro.TituloLivro);
                cmd.Parameters.AddWithValue("@autor", qualLivro.AutorLivro);
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

        public void UpdateLivro(Livro qualLivro)
        {
            try
            {
                string sql = "UPDATE mvc.Livro " +
                " SET tituloLivro= @titulo, codigoLivro=@codigo," +
                " autorLivro=@autor " +
                " WHERE idLivro = @idLivro ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", qualLivro.IdLivro);
                cmd.Parameters.AddWithValue("@codigo", qualLivro.CodigoLivro);
                cmd.Parameters.AddWithValue("@titulo", qualLivro.TituloLivro);
                cmd.Parameters.AddWithValue("@autor", qualLivro.AutorLivro);
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
        public void DeleteLivro(Livro qualLivro)
        {
            try
            { // muda estado de ativo para 0 em vez de realizar um delete para evitar a perda de dados dos empréstimos 
                String sql = "UPDATE mvc.Livro set ativo = 0 WHERE idLIvro = @idLivro ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", qualLivro.IdLivro);
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
        public bool PodeSerEmprestado(int id)
        {
            // se o livro está ativo e não foi emprestado por outra pessoa
            try
            {
                String sql = @"
                SELECT CASE 
                       WHEN EXISTS (
                           SELECT 1 
                           FROM MVC.Emprestimo E
                           INNER JOIN MVC.Livro L ON E.idLivro = L.idLivro
                           WHERE E.idLivro = @idLivro
                           AND L.ativo = 1
                           AND (E.dataDevolucaoReal IS NULL OR E.dataDevolucaoReal = '')
                       )
                       THEN 'false'
                       ELSE 'true'
                   END AS pode_ser_emprestado;";

                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", id);
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


        public DataTable SelectLivrosEmprestados()
        {
            try
            { // seleciona todos livros emprestados
                string sql =
                  "SELECT l.idLivro, TRIM(l.codigoLivro), TRIM(l.tituloLivro), TRIM(l.autorLivro), e.dataEmprestimo, e.dataDevolucaoPrevista " +
                  "FROM mvc.Livro l JOIN mvc.emprestimo e " +
                  "ON l.idLivro = e.idLivro " +
                  "WHERE l.ativo = 1 AND (e.dataDevolucaoReal IS NULL OR e.dataDevolucaoReal = '')";
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


        public DataTable SelectLivrosAtrasados()
        {
            try
            { // seleciona todos livros atrasados
                string sql =
                  "SELECT l.idLivro, TRIM(l.codigoLivro), TRIM(l.tituloLivro), TRIM(l.autorLivro), e.dataEmprestimo, " +
                  "DATEDIFF(DAY, e.dataDevolucaoPrevista, GETDATE()) AS diasAtraso " +
                  "FROM mvc.Livro l JOIN mvc.emprestimo e " +
                  "ON l.idLivro = e.idLivro " +
                  "WHERE l.ativo = 1 AND (e.dataDevolucaoReal IS NULL OR e.dataDevolucaoReal = '')" +
                  "AND DATEDIFF(DAY, e.dataDevolucaoPrevista, GETDATE()) > 0";

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
                throw ex;
            }
        }




    }
}
