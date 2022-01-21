using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Avaliacao.Entidades;

namespace Avaliacao
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empresa> list = new List<Empresa>();
            List<Fornecedor> list2 = new List<Fornecedor>();
            int opcao = 0;

            while(opcao != 5)
            {
                Console.WriteLine("======================== SISTEMAS AA =========================");
                Console.WriteLine();
                Console.WriteLine("================== ESCOLHA A OPÇÃO DESEJADA ==================");
                Console.WriteLine();
                Console.WriteLine("1- CADASTRO DE EMPRESAS");
                Console.WriteLine("2- LISTAGEM DE EMPRESAS CADASTRADAS");
                Console.WriteLine("3- CADASTRO DE FORNECEDORES");
                Console.WriteLine("4- LISTAGEM DE FORNECEDORES CADASTRADOS");
                Console.WriteLine("5- SAIR DO SISTEMA");
                Console.WriteLine();
                Console.Write("==> ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("ENTRE COM O NUMERO DE EMPRESAS A SEREM CADASTRADAS: ");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        for (int i = 1; i <= n; i++)
                        {
                            Console.WriteLine("EMPRESA #" + i );
                            Console.Write("NOME FANTASIA: ");
                            String name = Console.ReadLine();
                            Console.Write("ESTADO DE ORIGEM: ");
                            String str = Console.ReadLine();
                            Console.Write("CNPJ: ");
                            long ndoc = long.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.WriteLine();

                            list.Add(new Empresa(str, name, ndoc));
                        }
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("================== EMPRESAS CADASTRADAS ==================");
                        Console.WriteLine();
                        Console.WriteLine("Nome  | UF  | CNPJ ");
                        Console.WriteLine("----------------------------------------------------------");
                        foreach (Empresa emp in list)
                        {
                            Console.WriteLine(emp.EmpTag());
                            Console.WriteLine("----------------------------------------------------------");
                        }

                        if (list.Count == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("NENHUMA EMPRESA CADASTRADA");
                            Console.WriteLine();
                        }
                        Console.WriteLine("Precione qualquer tecla para continuar!!");
                        Console.WriteLine();
                        _ = Console.ReadKey(true).KeyChar;
                        break;

                    case 3:
                        Console.Write("ENTRE COM O NUMERO DE FORNECEDORES A SEREM CADASTRADOS: ");
                        int m = int.Parse(Console.ReadLine());
                        
                        for (int i = 1; i <= m; i++)
                        {
                            long ndoc;
                            var dataNacimento = DateTime.Now;
                            var data = DateTime.Now;

                            Console.WriteLine();
                            Console.WriteLine("FORNECEDOR #" + i);
                            Console.Write("NOME: ");
                            String nome = Console.ReadLine();
                            Console.Write("TELEFONE: ");
                            int tel = int.Parse(Console.ReadLine());
                            Console.Write("DATA DE CADASTRO (00/00/0000): ");
                            string datas = Console.ReadLine();

                            if (!String.IsNullOrEmpty(datas) && datas.Length == 10)
                                data = DateTime.Parse(datas);
                            Console.Write("PESSOA FÍSICA OU JURIDICA(F OU J): ");
                            String estJuridico = Console.ReadLine();
                            Console.Write("NOME DA EMPRESA A SER VINCULADA: ");
                            String emp = Console.ReadLine();

                            if (estJuridico == "F" || estJuridico == "f")
                            {
                                Console.Write("INFORME SUA IDADE: ");
                                int idade = int.Parse(Console.ReadLine());
                                while (idade < 18)
                                {
                                    Console.WriteLine(" PARA EFETUAR O CADASTRO DO FORNECEDOR PESSOA FÍSICA ELE DEVE SER MAIOR QUE 18 ANOS!! ");
                                    Console.Write("INFORME SUA IDADE: ");
                                    idade = int.Parse(Console.ReadLine());
                                }
                                Console.Write("CPF: ");
                                ndoc = long.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                                Console.Write("INFORME SUA DATA DE NASCIMENTO: ");
                                string datas1 = Console.ReadLine();
                                if (!String.IsNullOrEmpty(datas1) && datas1.Length == 10)
                                {
                                    dataNacimento = DateTime.Parse(datas1);
                                }
                                list2.Add(new Fornecedor( nome, ndoc, data, tel, "PF", dataNacimento, " ", emp,0));
                            }
                            else
                            {
                                Console.Write("CNPJ: ");
                                ndoc = long.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                                list2.Add(new Fornecedor(nome, ndoc, data, tel, "PJ", DateTime.MinValue, " ", emp, 0));
                            }
                        }
                        break;

                    case 4:
                        int ord;
                        Console.WriteLine();
                        Console.WriteLine("================== FORNECEDORES CADASTRADOS ==================");
                        Console.WriteLine();
                        Console.WriteLine("======> ESCOOLHA A ORDENAÇÃO DESEJADA <======");
                        Console.WriteLine();
                        Console.WriteLine("1- ORDENAR POR NOME:");
                        Console.WriteLine("2- ORDENAR POR CPF/CNPJ:");
                        Console.WriteLine("3- ORDENAR POR DATA DE CADASTRO:");
                        Console.WriteLine("4- ORDENAR POR EMPRESA:");
                        Console.WriteLine();
                        Console.Write("==> ");
                        ord = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        List<Fornecedor> ordNome;
                        if (ord == 1)
                        {
                            ordNome = list2.OrderBy(x => x.Nome).ToList();
                        }else if( ord == 2)
                        {
                            ordNome = list2.OrderBy(x => x.CPF_CNPJ).ToList();
                        }
                        else if (ord ==3)
                        {
                            ordNome = list2.OrderBy(x => x.Data_Cadastro).ToList();
                        }
                        else
                        {
                            ordNome = list2.OrderBy(x => x.NomeFantasia).ToList();
                        }

                        Console.WriteLine("NOME  | CPF/CNPJ | DATA CADASTRO | TELEFONE | TIPO PESSOA | EMPRESA");
                        Console.WriteLine("-------------------------------------------------------------------");
                        foreach (Fornecedor emp in ordNome)
                        {
                            Console.WriteLine(emp.FornTag());
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine();
                        }

                        if (list2.Count == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("NENHUM FORNECEDOR CADASTRADO");
                            Console.WriteLine();
                        }
                        Console.WriteLine("Precione qualquer tecla para continuar!!");
                        Console.WriteLine();
                        Console.WriteLine();
                        _ = Console.ReadKey(true).KeyChar;
                        break;
                }
            }
        }
    }
}
