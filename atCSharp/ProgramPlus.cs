using CamadaDeNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeApresentacao
{
    public class ProgramPlus
    {
        public void ShowMensages() 
        {
            /* Coloque aqui o caminho da sua maquina pra esse arquivo json, este é o caminho na minha maquina */
            var json = File.ReadAllText(@"C:\Users\nelso\source\repos\atCSharp\atCSharp\bin\Debug\net6.0\repositorio.json");

            var deserializedJson = new List<Pessoa>();
            if (json != "")
            {
                deserializedJson = JsonConvert.DeserializeObject<List<Pessoa>>(json);

                if (deserializedJson!.Count <= 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine($"Nome: {deserializedJson[i].Nome}," +
                        $" Data de Nascimento: {deserializedJson[i].DataNascimento}, " +
                        $" Idade: {deserializedJson[i].Idade}," +
                        $" Casado: {deserializedJson[i].IsCasado}," +
                        $" Altura: {deserializedJson[i].Altura}, " +
                        $"IdUnico: {deserializedJson[i].IdUnico}");
                    }
                }
                else if (deserializedJson.Count > 5)
                {
                    Console.WriteLine($"O número total de pessoas no Json: {deserializedJson.Count}");
                }
                else
                {
                    Console.WriteLine("Não existe nenhuma pessoa cadastrada.");
                }

            }
            else
            {
                Console.WriteLine("Json esta vazio, não existe nenhuma pessoa cadastrada.");
            }
        }
    }
}
