using System;
using System.Collections.Generic;
using System.IO;

namespace ExercicioComDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            Console.WriteLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {

                    Dictionary<string, int> dictionary = new Dictionary<string, int>();

                    while (!sr.EndOfStream)
                    {

                        string[] votingRecord = sr.ReadLine().Split(',');
                        string candidate = votingRecord[0];
                        int votes = int.Parse(votingRecord[1]);

                        if (dictionary.ContainsKey(candidate))
                        {
                            dictionary[candidate] += votes;
                        }
                        else
                        {
                            dictionary[candidate] = votes;
                        }
                    }

                    foreach (var item in dictionary)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
/*  C:\ProgramasCSharp\ConceitoDeDictionary\ExercicioComDictionary\ExercicioComDictionary\File\In.txt
 * PROBLEMA EXEMPLO:
 - Na contagem de votos de uma eleição, são gerados vários registros
de votação contendo o nome do candidato e a quantidade de votos
(formato .csv) que ele obteve em uma urna de votação. Você deve
fazer um programa para ler os registros de votação a partir de um
arquivo, e daí gerar um relatório consolidado com os totais de cada
candidato.

* EXEMPLO SAÍDA:
- Input file example:
    Alex Blue,15
    Maria Green,22
    Bob Brown,21
    Alex Blue,30
    Bob Brown,15
    Maria Green,27
    Maria Green,22
    Bob Brown,25
    Alex Blue,31
- Execution:
Enter file full path: (Exemplo:) c:\temp\in.txt
Alex Blue: 76
Maria Green: 71
Bob Brown: 61
 */