using CsvDemo.Models;
using CsvHelper;
using System.Globalization;

namespace CsvDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = @"D:\Projetos\res\csv\people-100.csv";
            string outputFile = @"D:\Projetos\res\csv\people-100-output.csv";
            List<Person> outputRecords = new();

            using var reader = new StreamReader(inputFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<Person>();

            foreach(var record in records)
            {
                if (record.Sex.Equals(SexEnum.Male) && record.FirstName.StartsWith("S"))
                {
                    outputRecords.Add(record);
                    Console.WriteLine($"{record.FirstName} {record.LastName} Added o the men's list");
                }    
            }
            using var writer = new StreamWriter(outputFile);
            using var csvOut = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvOut.WriteRecords(outputRecords);
            Console.ReadLine();
        }
    }
}