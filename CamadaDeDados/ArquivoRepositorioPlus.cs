using CamadaDeNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados
{
    public class ArquivoRepositorioPlus
    {

        protected void AddPersonJson(Pessoa person)
        {
            /* 
              Primeiro o json estava nesse caminho:
              @"C:\Users\nelso\source\repos\atCSharp\CamadaDeDados\repositorio.json" 

              Depois para esse que é o atual:
              C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0

              Caso ocorra algum erro ao achar, troque o caminho onde tem os comentarios para onde o repositorio.json esta na sua maquina
            */
            var json = File.ReadAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json");
            var PersonDeserialized = new List<Pessoa>();

            if (json != "")
            {
                PersonDeserialized = JsonConvert.DeserializeObject<List<Pessoa>>(json);
            }

            PersonDeserialized?.Add(person);

            /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
            File.WriteAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json", JsonConvert.SerializeObject(PersonDeserialized));
            
        }

        protected void SetPersonJson(Pessoa person, int personIndex)
        {
            /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
            var json = File.ReadAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json");

            var PersonDeserialized = new List<Pessoa>();
            if (json != "")
            {
                PersonDeserialized = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                PersonDeserialized![personIndex] = person;
                /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
                File.WriteAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json", JsonConvert.SerializeObject(PersonDeserialized));    
            }                           
        }
        protected void DeletePersonJson(int personIndex)
        {
            Console.WriteLine("Você deseja mesmo Excluir a pessoa??");
            Console.WriteLine("[ 0 ] = Nao");
            Console.WriteLine("[ 1 ] = Sim");

            int confirmDelete = int.Parse(Console.ReadLine()!);

            if (confirmDelete == 1)
            {
                /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
                var json = File.ReadAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json");

                var PersonDeserialized = new List<Pessoa>();
                if (json != "")
                {

                    PersonDeserialized = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                    PersonDeserialized!.RemoveAt(personIndex);
                    /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
                    File.WriteAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json", JsonConvert.SerializeObject(PersonDeserialized));

                }
            }
            else if (confirmDelete == 0)
            {
                Console.WriteLine("Pessoa não foi removida.");
            }
            else
            {
                Console.WriteLine("Digite uma opção valida.");
            }



        }
        protected void DetailsPersonJson(List<Pessoa> peopleFound, int detailsOfWho)
        {

            if (detailsOfWho < peopleFound.Count)
            {
                int personIndex = peopleFound.FindIndex(p => p.Nome == peopleFound[detailsOfWho].Nome);

                Pessoa person = peopleFound[personIndex];

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


        public void ShowNamesJson()
        {
            /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
            var json = File.ReadAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json");

            var PersonDeserialized = new List<Pessoa>();
            if (json != "")
            {
                PersonDeserialized = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                Console.WriteLine("Nome da(s) pessoa(s) salva(s) no Json:");
                PersonDeserialized?.ForEach((pessoa) =>
                {
                    Console.WriteLine(pessoa.Nome);
                });
            }
            else
            {
                Console.WriteLine("Json esta vazio.");
            }
        }

        public void ShowPersonJson(int indexPerson)
        {
            /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
            var json = File.ReadAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json");

            var PersonDeserialized = new List<Pessoa>();
            if (json != "")
            {

                PersonDeserialized = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                Console.WriteLine("Informações da pessoa salva no Json:");

                Console.WriteLine($"Nome: {PersonDeserialized![indexPerson].Nome}," +
                    $" Data de Nascimento: {PersonDeserialized![indexPerson].DataNascimento}, " +
                    $" Idade: {PersonDeserialized![indexPerson].Idade}," +
                    $" Casado: {PersonDeserialized![indexPerson].IsCasado}," +
                    $" Altura: {PersonDeserialized![indexPerson].Altura}");
              
            }
            else
            {
                Console.WriteLine("Json esta vazio.");
            }
        }
    }
}
