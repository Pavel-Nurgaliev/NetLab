using System;
using ProcessTextFileLibrary;

namespace ProcessTextFile.UI
{
    internal class Program
    {
        private const string FilePath = @"file.txt";
        public static void Main(string[] args)
        {
            var startMessage = "[01] Hello world!";

            WriteStartMessage(startMessage);

            PrintFile();

            WriteFile();

            PrintFile();
        }

        private static void WriteFile()
        {
            using (var fileProcessor = FileProcessor.Read(FilePath))
            {
                fileProcessor[2] = '2';
            }
        }

        private static void PrintFile()
        {
            using (var fileProcessor = FileProcessor.Read(FilePath))
            {
                ReadFile(fileProcessor);
            }
        }

        private static void WriteStartMessage(string startMessage)
        {
            try
            {
                var fileProcessor = FileProcessor.Create(FilePath, startMessage.Length);

                for (var i = 0; i < startMessage.Length; i++)
                {
                    fileProcessor[i] = startMessage[i];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ReadFile(FileProcessor fileProcessor)
        {
            try
            {
                for (var i = 0; i < fileProcessor.Length; i++)
                {
                    Console.Write(fileProcessor[i]);
                }

                Console.WriteLine();
            }
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
