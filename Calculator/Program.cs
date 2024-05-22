
class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // O valor padrão é "não-um-número" se uma operação, como divisão, puder resultar em erro.

        // Use uma instrução switch para fazer as contas.
        switch (op)
        {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
            // Retorna o texto para uma entrada de opção incorreta
            default:
                break;
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        // Exibir o título como o aplicativo de calculadora do console C#.
        Console.WriteLine("Calculadora de console em C#\r");
        Console.WriteLine("----------------------------\n");

        while (!endApp)
        {
            // Declare variáveis e defina-as como vazias.
            string numInput1 = "";
            string numInput2 = "";
            double result = 0;

            // Peça ao usuário para digitar o primeiro número.
            Console.Write("Digite um número e pressione Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.WriteLine("Esta entrada não é válida. Por favor insira um valor inteiro: ");
                numInput1 = Console.ReadLine();
            }

            // Peça ao usuário para digitar o segundo número.
            Console.WriteLine("Digite o segundo número e digite enter");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.WriteLine("Esta entrada não é válida. Por favor insira um valor inteiro: ");
                numInput2 = Console.ReadLine();
            }

            // Peça ao usuário para escolher uma operação.
            Console.WriteLine("Escolha um operador na lista a seguir: ");
            Console.WriteLine("\ta - Somar");
            Console.WriteLine("\ts - Subtrair");
            Console.WriteLine("\tm - Multiplicar");
            Console.WriteLine("\td - Dividir");
            Console.Write("Sua Opção: ");

            string op = Console.ReadLine();

            try
            {
                result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("Esta operação resultará em um erro matemático. \n");
                }
                else Console.WriteLine("Seu resultado: {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh não! Ocorreu uma exceção ao tentar fazer as contas.\n - Detalhes: " + e.Message);
            }

            Console.WriteLine("----------------------------\n");

            // Aguarde a resposta do usuário antes de fechar.
            Console.WriteLine("Pressione 'n' e Enter para fechar o aplicativo ou pressione qualquer outra tecla e Enter para continuar:");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Espaçamento de linha amigável.
        }
        return;
    }
}


