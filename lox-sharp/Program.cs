using static lox_sharp.Utilities;

namespace lox_sharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.Write("Usage: loxsharp [script]");
                Environment.Exit(64);
            } else if (args.Length == 1)
            {
                RunFile(args[0]);
            } else
            {
                RunPrompt();
            }
        }

        private static void RunFile(string path)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(path);
            }
            catch (IOException ex)
            {
                PrintError(ex.Message);
                throw;
            }
        }

        private static void RunPrompt()
        {
            try
            {
                StreamReader input = new StreamReader(Console.OpenStandardInput());
                Console.SetIn(input);

                while (true)
                {
                    Console.WriteLine("> ");
                    string? line = Console.ReadLine();
                    if (line == null)
                        break;

                    Run(line);
                }
            }
            catch (IOException ex)
            {
                PrintError(ex.Message);
                throw;
            }
        }

        private static void Run(string source)
        {
            Scanner scanner = new Scanner(source);
            List<Token> tokens = scanner.ScanTokens();

            // For now, just print the tokens.
            foreach (Token token in tokens)
            {
                Console.WriteLine(token);
            }
        }
    }
}