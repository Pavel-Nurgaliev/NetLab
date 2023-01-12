using System;
using System.IO;

namespace PointProcessor
{
    public class Processor
    {
        public static void ProcessFiles(string[] filenames)
        {
            foreach (var file in filenames)
            {
                ProcessFile(file);
            }
        }

        private static void ProcessFile(string file)
        {
            using (StreamReader streamReader = new StreamReader(file))
            {
                ProcessReader(streamReader);
            }
        }
        public static void ProcessConsole()
        {

            Console.WriteLine("Нажмите enter, чтобы выйти");
            Console.WriteLine("Введите координаты:");

            ProcessReader(Console.In);
        }
        private static void ProcessReader(TextReader textReader)
        {
            string line = string.Empty;

            while (!string.IsNullOrEmpty(line = textReader.ReadLine()))
            {
                var processedLine = ProcessLine(line);

                if (processedLine is not null) Console.WriteLine(processedLine);
            }
        }

        public static string ProcessLine(string line)
        {
            return Parser.TryParsePoint(line, out var point) ? Formatter.Format(point) : null;
        }
    }
}
