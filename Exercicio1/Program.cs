using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\samuel.alves\\Desktop\\Teste.txt");
            Dictionary<string, int> candidatos = new Dictionary<string, int>();
            var response = "";

            do
            {
                Console.WriteLine("\nDigite o candidato e o sua quantiade de votos");
                response = Console.ReadLine();
                var candidato = response.Split(',')[0];

                if (response.Split(',')[1] != null)
                {
                    var qtdVotos = int.Parse(response.Split(',')[1]);

                    if (candidatos.ContainsKey(candidato))
                    {
                        candidatos[candidato] += qtdVotos;
                    }
                    else
                    {
                        candidatos.Add(candidato, qtdVotos);
                    }
                }

            } while (response != "Sair");

            var results = candidatos
                .GroupBy(g => g.Key)
                .Select(s => new
                {
                    Candidato = s.Key,
                    QtdVotos = s.Sum(s2 => s2.Value)
                });

            foreach (var result in results)
            {
                sw.WriteLine($"Candidato: {result.Candidato} contêm {result.QtdVotos} votos");
                Console.WriteLine($"\nCandidato: {result.Candidato} contêm {result.QtdVotos} votos");
            }

            sw.Close();
        }
    }
}
