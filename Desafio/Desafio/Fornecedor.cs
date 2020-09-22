using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{

    [Table("fornecedores")] class Fornecedor [Key] public int id { get; set; }
    public String NomeFantasia{get;set;}
    public String CNPJ{get;set;}
    public String Endereco{get;set;}
    public String Cidade{get;set;}
    public String CEP{get;set;}
    public DateTime Criacao{get;set;}
    public DateTime UltimaAlteracao{get;set;}
    public DateTime Exclusao{get;set;}
    
}
