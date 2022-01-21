using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Avaliacao.Entidades
{
    class Empresa
    {
        public string UF { get; set; }
        public string NomeFantasia { get; set; }
        public long CNPJ { get; set; }

        public Empresa()
        {

        }

        public Empresa(string uf, string nomeFantasia,long _CNPJ)
        {
            UF = uf;
            NomeFantasia = nomeFantasia;
            CNPJ = _CNPJ;
        }

        public virtual string EmpTag()
        {
            return NomeFantasia
                + " | "
                + UF
                + " | "
                + CNPJ;
        }
    }
}
