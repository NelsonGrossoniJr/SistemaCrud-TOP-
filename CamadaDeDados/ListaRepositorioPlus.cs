using CamadaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados
{
    public class ListaRepositorioPlus
    {
        protected List<Pessoa> pessoaArrayObj = new List<Pessoa>();

        protected void AddPersonJson(Pessoa pessoa)
        {
            pessoaArrayObj.Add(pessoa);


            pessoaArrayObj.ForEach(pessoa =>
            {

                Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataNascimento}, Idade: {pessoa.Idade}, Casado: {pessoa.IsCasado}, Altura: {pessoa.Altura}, IdUnico: {pessoa.IdUnico}. ");
            });
        }

        protected void SetPersonJson(Pessoa pessoa, int indicePessoa)
        {

            pessoaArrayObj[indicePessoa] = pessoa;
            pessoaArrayObj.ForEach(pessoa =>
            {
                Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataNascimento}, Idade: {pessoa.Idade}, Casado: {pessoa.IsCasado}, Altura: {pessoa.Altura}, IdUnico: {pessoa.IdUnico}. ");
            });
        }

        protected void DeletePersonJson(int indicePessoa)
        {
            Console.WriteLine("Você deseja mesmo Excluir a pessoa??");
            Console.WriteLine("[ 0 ] = Nao");
            Console.WriteLine("[ 1 ] = Sim");

            int confirmDelete = int.Parse(Console.ReadLine()!);

            if (confirmDelete == 1)
            {
                pessoaArrayObj.RemoveAt(indicePessoa);

                Console.WriteLine("Pessoa removida com sucesso.");
                pessoaArrayObj.ForEach(pessoa =>
                {
                    Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataNascimento}, Idade: {pessoa.Idade}, Casado: {pessoa.IsCasado}, Altura: {pessoa.Altura}, IdUnico: {pessoa.IdUnico}. ");
                });
            }
            else if (confirmDelete == 2)
            {
                Console.WriteLine("Pessoa não foi removida.");
            }
            else
            {
                Console.WriteLine("Digite uma opção valida.");
            }

        }

        protected void DetailsPersonJson(List<Pessoa> peopleFound, int escolhaDetalhes)
        {
            if (escolhaDetalhes < peopleFound.Count)
            {
                int indicePessoa = peopleFound.FindIndex(p => p.Nome == peopleFound[escolhaDetalhes].Nome);
                Pessoa person = peopleFound[indicePessoa];

                Console.WriteLine("Detalhes da pessoa:");
                Console.WriteLine($"Nome: {person.Nome}");
                Console.WriteLine($"Data de Nascimento: {person.DataNascimento}");
                Console.WriteLine($"Idade: {person.Idade}");
                Console.WriteLine($"Casado: {person.IsCasado}");
                Console.WriteLine($"Altura: {person.Altura}");
                Console.WriteLine($"IdUnico: {person.IdUnico}");

                person.CalculandoExpectativaDeVida(person);
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}
