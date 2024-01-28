using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CamadaDeNegocio;
using Newtonsoft.Json;


namespace CamadaDeDados
{
    public class ArquivoRepositorio : ArquivoRepositorioPlus, IRepositorio
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

            ShowNamesJson();

        }


        public void Alteracao()
        {
            Console.Write("Informe o nome da pessoa que deseja alterar: ");
            string searchName = Console.ReadLine()!;

            /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
            var json = File.ReadAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json");
            var deserializedJson = new List<Pessoa>();
            int personIndex = -1;

            if (json != "")
            {
                deserializedJson = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                personIndex = deserializedJson!.FindIndex(p => p.Nome == searchName);
            }


            if (personIndex != -1)
            {             

                Console.WriteLine($"Nome: {deserializedJson[personIndex].Nome}, DataNascimento: {deserializedJson[personIndex].DataNascimento}, Idade: {deserializedJson[personIndex].Idade}, Casado: {deserializedJson[personIndex].IsCasado}, IdUnico: {deserializedJson[personIndex].IdUnico} ");

                Console.Write("Informe o novo nome: ");
                string newName = Console.ReadLine()!;

                Console.Write("Informe a nova data de nascimento(dd/mm/aaaa): ");
                string newDateOfBirth = Console.ReadLine()!;
                DateTime newDateOfBirthConverted = DateTime.Parse(newDateOfBirth);

                Console.Write("Informe a nova idade: ");
                int newAge = int.Parse(Console.ReadLine()!);

                Console.Write("Informe se é casado?? Se Sim, responda com(true) Se Não com(false): ");
                bool newIsMarried = bool.Parse(Console.ReadLine()!);

                Console.Write("Informe a nova altura: ");
                double newHeight = double.Parse(Console.ReadLine()!);

                Guid uniqId = Guid.NewGuid();

                Pessoa personUpdated = new Pessoa(newName, newDateOfBirthConverted, newAge, newIsMarried, newHeight, uniqId);


                SetPersonJson(personUpdated, personIndex);

                ShowNamesJson();
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

            /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
            var json = File.ReadAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json");
            var deserializedJson = new List<Pessoa>();
            int personIndex = -1;

            if (json != "")
            {
                deserializedJson = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                personIndex = deserializedJson!.FindIndex(p => p.Nome == searchName);
            }

            if (personIndex != -1)
            {
                Console.WriteLine("Pessoa encontrada!");

                ShowPersonJson(personIndex);

                DeletePersonJson(personIndex);

                ShowNamesJson();
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

            /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
            var json = File.ReadAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json");
            var deserializedJson = new List<Pessoa>();
            List<Pessoa> peopleFound = new List<Pessoa>();

            if (json != "")
            {
                deserializedJson = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                peopleFound = deserializedJson!.FindAll(p => p.Nome!.Contains(searchName));
            }

            

            if (peopleFound.Count != 0)
            {
                Console.WriteLine("Resultados da pesquisa:");
                foreach (Pessoa person in peopleFound)
                {
                    Console.WriteLine(person.Nome);

                    Console.WriteLine($"{detailCounter} - Visualizar detalhes");
                    detailCounter++;
                }
                Console.WriteLine("Digite o numero que representa o nome para exibir seus detalhes:");
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