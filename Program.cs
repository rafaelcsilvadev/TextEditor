using System;
using System.IO;

namespace TextEditor
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir um arquivo de Texto");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine()!);

            switch(option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        private static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para do arquivo?");
            var path = Console.ReadLine();

            using(var file = new StreamReader(path!))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-------------------------");
            string text = "";
            do
            {
                text = $"{text} {Console.ReadLine()}";
                text = $"{text} {Environment.NewLine}";
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);

        }

        private static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using(var file = new StreamWriter(path!))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}