using System;
namespace Avaliacao.Entidades
{
    class Fornecedor : Empresa 
    {
       
        public string Nome { get; set; }
        public long CPF_CNPJ { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public int Telefone { get; set; }
        public string Estado_Pessoa { get; set; }
        public DateTime Data_Nascimento { get; set; }

        public Fornecedor()
        {
        }
        

        public Fornecedor(string nome, long _CPF_CNPJ, DateTime data_Cadastro, int telefone, string estado_Pessoa, DateTime data_Nascimento, string uf, string nomeFantasia, long _CNPJ)
            : base (uf ,nomeFantasia,_CNPJ )
        {            
            Nome = nome;
            CPF_CNPJ = _CPF_CNPJ;
            Data_Cadastro = data_Cadastro;
            Telefone = telefone;
            Estado_Pessoa = estado_Pessoa;
            Data_Nascimento = data_Nascimento;
        }

        public virtual string FornTag()
        {
            return Nome
                + " | "
                + CPF_CNPJ
                + " | " 
                + Data_Cadastro
                + " | "
                + Telefone
                + " | "
                + Estado_Pessoa
                + " | "
                + NomeFantasia;
        }
    }
}