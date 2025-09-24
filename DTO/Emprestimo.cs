using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  class Emprestimo
  {
    int idEmprestimo,
        idLivro,
        idLeitor;
        DateTime dataEmprestimo,
                 dataDevolucaoPrevista;
        DateTime? dataDevolucaoReal; // pode ser nulo na hora da criação

    public Emprestimo(int idEmprestimo, int idLivro, 
      int idLeitor, DateTime dataEmprestimo, 
      DateTime dataDevolucaoPrevista, 
      DateTime? dataDevolucaoReal)
    {
      this.idEmprestimo = idEmprestimo;
      this.idLivro = idLivro;
      this.idLeitor = idLeitor;
      this.dataEmprestimo = dataEmprestimo;
      this.dataDevolucaoPrevista = dataDevolucaoPrevista;
      this.dataDevolucaoReal = dataDevolucaoReal;
    }

    public int IdEmprestimo 
    { 
      get => idEmprestimo;
      set 
      {
        if (value <= 0)
          throw new Exception("Id de Empréstimo deve ser maior que 0.");
        idEmprestimo = value; 
      }
    }
    public int IdLivro 
    { 
      get => idLivro;
      set 
      {
        if (value <= 0)
          throw new Exception("Id de Livro deve ser maior que 0.");
        idLivro = value; 
      }
    }
    public int IdLeitor 
    { 
      get => idLeitor;
      set 
      {
        if (value <= 0)
          throw new Exception("Id de Leitor deve ser maior que 0.");
        idLeitor = value; 
      }
    }
    public DateTime DataEmprestimo 
    { 
      get => dataEmprestimo; 
      set => dataEmprestimo = value; 
    }
    public DateTime DataDevolucaoPrevista 
    { 
      get => dataDevolucaoPrevista; 
      set => dataDevolucaoPrevista = value; 
    }
    public DateTime? DataDevolucaoReal 
    { 
      get => dataDevolucaoReal; 
      set => dataDevolucaoReal = value; 
    }
  }
}
