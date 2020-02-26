using System;
using System.Collections.Generic;
using System.Linq;

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

            var startTime = DateTime.Now;
            builder.Build();
            var stopTime = DateTime.Now;
            var totalTime = stopTime - startTime;

            Console.WriteLine();
            Console.WriteLine($"Word tree built in {totalTime.TotalMilliseconds} ms");
            Console.WriteLine();

            var viewer = new PredictionViewer(builder.RootNode);
            viewer.Start();
        }

        private static string RequestFileName()
        {
            Console.Write("Input filename: (default = Current Directory + words.txt)");
            var fileName = Console.ReadLine();
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "words.txt";
            }
            return fileName;
        }
    }
}
