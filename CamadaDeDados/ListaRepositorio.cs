using CamadaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados
{
    public class ListaRepositorio : ListaRepositorioPlus, IRepositorio
    {

        public void Inclusao()
        {

            Console.Write("Informe o nome: ");
            string name = Console.ReadLine()!;

            Console.Write("Informe a data de nascimento(dd/mm/aaaa): ");
            string dateOfBirth = Console.ReadLine()!;
            DateTime dateOfBirthConverted = DateTime.Parse(dateOfBirth);

            Console.Write("Informe a sua idade: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("Informe se é casado?? Se Sim, responda com(true) Se Não com(false): ");
            bool isMarried = bool.Parse(Console.ReadLine()!);

            Console.Write("Informe a sua altura: ");
            double height = double.Parse(Console.ReadLine()!);

            Guid uniqId = Guid.NewGuid();

            Pessoa Person = new Pessoa(name, dateOfBirthConverted, age, isMarried, height, uniqId);

            AddPersonJson(Person);

        }

        public void Alteracao()
        {
            Console.Write("Informe o nome da pessoa que deseja alterar: ");
            string searchName = Console.ReadLine()!;


            int personIndex = pessoaArrayObj.FindIndex(p => p.Nome == searchName);

            if (personIndex != -1)
            {
                Console.Write("Informe o nome: ");
                string name = Console.ReadLine()!;

                Console.Write("Informe a data de nascimento(dd/mm/aaaa): ");
                string dateOfBirth = Console.ReadLine()!;
                DateTime dateOfBirthConverted = DateTime.Parse(dateOfBirth);

                Console.Write("Informe a sua idade: ");
                int age = int.Parse(Console.ReadLine()!);

                Console.Write("Informe se é casado?? Se Sim, responda com(true) Se Não com(false): ");
                bool isMarried = bool.Parse(Console.ReadLine()!);

                Console.Write("Informe a sua altura: ");
                double height = double.Parse(Console.ReadLine()!);

                Guid uniqId = Guid.NewGuid();

                Pessoa personUpdated = new Pessoa(name, dateOfBirthConverted, age, isMarried, height, uniqId);

                SetPersonJson(personUpdated, personIndex);

            }
            else
            {
                Console.WriteLine("Pessoa não encontrada!");
            }
        }

        public void Exclusao()
        {
            Console.Write("Informe o nome da pessoa que deseja excluir: ");
            string searchName = Console.ReadLine()!;

            int personIndex = pessoaArrayObj.FindIndex(p => p.Nome == searchName);

            if (personIndex != -1)
            {
                DeletePersonJson(personIndex);
            }
            else
            {
                Console.WriteLine("Pessoa não encontrada!");
            }
        }

        public void Pesquisa()
        {
            int detailCounter = 0;

            Console.Write("Informe o nome da pessoa que deseja pesquisar: ");
            string searchName = Console.ReadLine()!;

            List<Pessoa> peopleFound = pessoaArrayObj.FindAll(p => p.Nome!.Contains(searchName));

            if (peopleFound.Count != 0)
            {

                Console.WriteLine("Resultados da pesquisa:");
                foreach (Pessoa person in peopleFound)
                {
                    Console.WriteLine(person.Nome);
                    Console.WriteLine($"{detailCounter} - Visualizar detalhes");
                    detailCounter++;
                }

                Console.WriteLine("Digite o número que representa o nome para exibir seus detalhes:");
                int detailsOfWho = int.Parse(Console.ReadLine()!);
                DetailsPersonJson(peopleFound, detailsOfWho);
            }
            else
            {
                Console.WriteLine("Pessoa não encontrada!");
            }
        }
    }
}
