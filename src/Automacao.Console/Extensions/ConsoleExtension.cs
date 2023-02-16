namespace Automacao.Extensions
{
    public static class ConsoleExtension
    {
        public static void PrintMenu()
        {
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("| Digite qual ambiente deseja alterar  |");
            Console.WriteLine("|          ou 0 para SAIR              |");
            Console.WriteLine("#--------------------------------------#");
            Console.Write("Codigo do ambiente: ");
        }
        public static void PrintOptionsMenu()
        {
            Console.WriteLine("\n#--------------------------------------#");
            Console.WriteLine("|        O que deseja realizar?        |");
            Console.WriteLine("#--------------------------------------#");
            Console.WriteLine("|    1- Troca de hibrido para manual   |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|            0 - Voltar                |");
            Console.WriteLine("#--------------------------------------#");
            Console.Write("Opção: ");
        }
    }
}
