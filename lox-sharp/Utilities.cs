namespace lox_sharp
{
    public static class Utilities
    {
        public static void Error(int line, string message)
        {
            Log(line, message);
        }

        private static void Log(int line, string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Line {line}] Error: {message}");
            Console.ResetColor();
            Program.HadError = true;
        }
    }
}
