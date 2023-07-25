using System.Text;

namespace calc_hw1
{
    public class Calculator
    {
        public double Addition(double a, double b)
        {
            return a + b;
        }

        public double Subtraction(double a, double b)
        {
            return a - b;
        }

        public double Multiplication(double a, double b)
        {
            return a * b;
        }

        public double Division(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Ділення на 0 неможливе!");
            }
            return a / b;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Calculator calculator = new Calculator();

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("а. Почати роботу з калькулятором");
                Console.WriteLine("б. Вийти з калькулятора");
                Console.Write("Введіть Ваш вибір: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice.ToLower())
                {
                    case "а":
                        Console.Write("Введіть перше число: ");
                        double firstNumber;
                        while (!double.TryParse(Console.ReadLine(), out firstNumber))
                        {
                            Console.WriteLine("Щось не так. Спробуйте ще раз.");
                            Console.Write("Введіть перше число: ");
                        }

                        Console.Write("Введіть оператор (+, -, *, /): ");
                        char operation = char.Parse(Console.ReadLine());

                        Console.Write("Введіть друге число: ");
                        double secondNumber;
                        while (!double.TryParse(Console.ReadLine(), out secondNumber))
                        {
                            Console.WriteLine("Щось не так. Спробуйте ще раз.");
                            Console.Write("Введіть друге число: ");
                        }

                        double result = 0;

                        switch (operation)
                        {
                            case '+':
                                result = calculator.Addition(firstNumber, secondNumber);
                                Console.WriteLine($"Результат: {result}");
                                break;
                            case '-':
                                result = calculator.Subtraction(firstNumber, secondNumber);
                                Console.WriteLine($"Результат: {result}");
                                break;
                            case '*':
                                result = calculator.Multiplication(firstNumber, secondNumber);
                                Console.WriteLine($"Результат: {result}");
                                break;
                            case '/':
                                try
                                {
                                    result = calculator.Division(firstNumber, secondNumber);
                                    Console.WriteLine("Результат: " + result);
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine("Помилка: " + ex.Message);
                                }
                                break;
                            default:
                                Console.WriteLine("Неправильний оператор. Спробуйте ще раз.");
                                break;
                        }
                        break;
                    case "б":
                        Console.WriteLine("Хай щастить!");
                        return;
                    default:
                        Console.WriteLine("Неправильний вибір, спробуйте ще раз.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}