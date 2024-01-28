using atCSharp;
using CamadaDeNegocio;
using System.Linq.Expressions;
using System.Security.Cryptography;
using CamadaDeDados;
using Newtonsoft.Json;
using System.Diagnostics;
using CamadaDeApresentacao;

class Program
{
    static void Main(string[] args)
    {
        IRepositorio IrepositoryFile = new ArquivoRepositorio();
        Teste repositoryFile = new Teste(IrepositoryFile);

        IRepositorio IrepositoryList = new ListaRepositorio();
        Teste repositoryList = new Teste(IrepositoryList);

        int whichRepository = 2;
        Teste repositoryConverted = null!;
        String nameRepository = "";


        Console.WriteLine("Olá, seja Bem-vindo usuário!");
        do
        {  
            Console.WriteLine("Você gostaria de salvar em Arquivo ou em Lista?");

            Console.WriteLine("Digite:");
            Console.WriteLine(" [ 0 ] = Arquivo ");
            Console.WriteLine(" [ 1 ] = Lista ");
            Console.WriteLine(" [ 2 ] = Sair");
            try
            {
                whichRepository = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Valor inválido. Por favor, digite um número e não uma String.");

            }

            switch (whichRepository)
            {
                case 0:
                    repositoryConverted = repositoryFile;
                    nameRepository = "Arquivo";
                  
                    break;

                case 1:
                    repositoryConverted = repositoryList;
                    nameRepository = "Lista(Memória)";
                    
                    break;

                case 2:
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Valor inválido. Por favor, digite [ 0 ], [ 1 ] ou [ 2 ].");
                    break;
            }

        } while (whichRepository < 0 || whichRepository > 2);

        if(repositoryConverted == repositoryFile && nameRepository == "Arquivo") 
        {
            ProgramPlus programPlus = new ProgramPlus();
            programPlus.ShowMensages();
        }

        bool verifyLoop = true;

        Console.WriteLine($"Você esta salvando em {nameRepository}!");
        while (verifyLoop)
        {

            Console.WriteLine("Selecione o metodo que quer usar:");
            Console.WriteLine("Digite:");
            Console.WriteLine(" [ 0 ] = Incluir Pessoa.");
            Console.WriteLine(" [ 1 ] = Alterar Pessoa. ");
            Console.WriteLine(" [ 2 ] = Excluir Pessoa. ");
            Console.WriteLine(" [ 3 ] = Pesquisar Pessoa. ");
            Console.WriteLine(" [ 4 ] = Sair. ");

            int whichMethod = int.Parse(Console.ReadLine()!);

            switch (whichMethod)
            {

                case 0:
                    Console.WriteLine("Incluindo Pessoa...");
                    repositoryConverted?.Incluindo();
                    break;
                case 1:
                    Console.WriteLine("Alterando Pessoa...");
                    repositoryConverted?.Alterando();
                    break;
                case 2:
                    Console.WriteLine("Excluindo Pessoa...");
                    repositoryConverted?.Excluindo();
                    break;
                case 3:
                    Console.WriteLine("Pesquisando Pessoa...");
                    repositoryConverted?.Pesquisando();
                    break;
                case 4:
                    Console.WriteLine("Saindo do Programa...");
                    verifyLoop = false;
                    break;
                default:
                    Console.WriteLine("Valor inválido. Por favor, digite [ 0 ], [ 1 ], [ 2 ], [ 3 ] ou [ 4 ].");
                    break;

            }
        }
    }
}