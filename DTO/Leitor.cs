using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Leitor
  {
    const int tamanhoNome     =  50,
              tamanhoTelefone =  20,
              tamanhoEmail    =  50,
              tamanhoEndereco = 100;

    int idLeitor;
    string nomeLeitor,
           telefoneLeitor,
           emailLeitor,
           enderecoLeitor;

    public Leitor(int idLeitor, string nomeLeitor, 
      string telefoneLeitor, string emailLeitor, 
      string enderecoLeitor)
    {
      IdLeitor       = idLeitor;
      NomeLeitor     = nomeLeitor;
      TelefoneLeitor = telefoneLeitor;
      EmailLeitor    = emailLeitor;
      EnderecoLeitor = enderecoLeitor;
    }

        public static int TamanhoNome => tamanhoNome;

        public static int TamanhoTelefone => tamanhoTelefone;

        public static int TamanhoEmail => tamanhoEmail;

        public static int TamanhoEndereco => tamanhoEndereco;

        public int IdLeitor 
    { 
      get => idLeitor;
      set
      {
        if (value < 0)
          throw new Exception("Id negativo para leitor é inválido!");
        idLeitor = value;
      }
    }
    public string NomeLeitor 
    { 
      get => nomeLeitor;
      set 
      {
         nomeLeitor = value.PadRight(tamanhoNome, ' ').Substring(0,tamanhoNome); 
      }
    }
    public string TelefoneLeitor 
    { 
      get => telefoneLeitor;
      set
      {
         telefoneLeitor = value.PadRight(tamanhoTelefone, ' ').Substring(0, tamanhoTelefone);
      }
    }
    public string EmailLeitor 
    { 
      get => emailLeitor;
      set
      {
          emailLeitor = value.PadRight(tamanhoEmail, ' ').Substring(0, tamanhoEmail);
      }
    }
    public string EnderecoLeitor 
    { 
      get => enderecoLeitor;
      set
      {
                enderecoLeitor = value.PadRight(tamanhoEndereco, ' ').Substring(0, tamanhoEndereco);
            }
    }
  }
}
