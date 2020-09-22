using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class DAL
    {
        static void Main(string[] args)
        {
            try
            {
                FornecedoresBLL.AdicionarFornecedor("Loja AZ Informatica", "Rua Abcde, 1222", "90000-000", "São Paulo", "00,000.000/0000-00");
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao adicionar o fornecedor na base de dados. Erro: {0}");
            }
        }
    }
}
}