using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;

namespace Desafio
{
    class FornecedoresBLL
    {
        static void Main(string[] args)
        {
            FornecedoresBLL.AdicionarFornecedor("Loja AZ Informatica", "Rua Abcde, 1222", "90000-000", "São Paulo", "00,000.000/0000-00");
            String.IsNullOrEmpty("");
            String.IsNullOrWhiteSpace("");
            throw new Exception("Você deve informar o nome fantasia para fazer a inserção do registro.");
        }
    }
}
