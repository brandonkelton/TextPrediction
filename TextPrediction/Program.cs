using System;

namespace TextPrediction
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = RequestFileName();
            var reader = new TextFileReader(fileName);
            reader.Read();
            var builder = new NodeBuilder(reader.Text);
            builder.Build();

            Console.WriteLine();
            Console.WriteLine("Nodes Built.");
            Console.ReadLine();
        }

        private static string RequestFileName()
        {
            Console.Write("Input filename: (default = Current Directory + words.txt)");
            var fileName = Console.ReadLine();
            if (String.IsNullOrEmpty(fileName))
            {
                fileName = "words.txt";
            }
            return fileName;
        }
    }
}
