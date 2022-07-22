using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            List<int> numbers = new List<int>();

            Console.WriteLine("Привет! Я - калькулятор однофункциональный с функцией запоминания. Вы вводите числа, а я их суммирую, если вы попросите.\n" +
                "\nЕсли Вы хоитет просуммировать введенные числа - введите \"Sum\".\nЕсли вы хотите закончить работу в однофункциональном " +
                "калькуляторе - введите \"Exit\".\nЕсли вы хотите ввести число - введите число.");

            while (isWorking)
            {
                string enteredValue = ReadValue("\nВведите число, \"Sum\" или \"Exit\": ");

                switch (enteredValue)
                {
                    case "exit":
                        isWorking = false;
                        break;
                    case "sum":
                        WriteSum(numbers);
                        break;
                    default:
                        AddNumber(numbers, enteredValue);
                        break;
                }
            }
        }

        static string ReadValue(string text)
        {
            string enteredValue;

            Console.Write(text);
            enteredValue = Console.ReadLine().ToLower();

            return enteredValue;
        }

        static void AddNumber(List<int> numbers, string enteredValue)
        {
            if (int.TryParse(enteredValue, out int number))
            {
                numbers.Add(number);

                Console.WriteLine($"\nЧисло {number} успешно введено");
            }
            else
            {
                Console.WriteLine("\nВведенное значение не является числом.");
            }
        }

        static void WriteSum(List<int> numbers)
        {
            if (numbers.Count > 0)
            {
                int sum = 0;

                for (int j = 0; j < numbers.Count; j++)
                {
                    sum += numbers[j];
                }

                Console.WriteLine("\nСумма введенных чисел: " + sum);
            }
            else
            {
                Console.WriteLine("\nВы еще не ввели никаких чисел. В начале введите числа, и после этого я смогу их просуммировать.");
            }
        }
    }
}