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
                "калькуляторе - введите \"Exit\".\nЕсли вы хотите ввести число - введите число.\nЕсли вы хотите сделать что-то другое - введите \"Another\".");

            while (isWorking)
            {
                string enteredValue = ReadValue("\nВведите число, \"Sum\", \"Exit\" или \"Another\": ");

                switch (enteredValue)
                {
                    case "exit":
                        isWorking = false;
                        break;
                    case "sum":

                        SumOfNumbers(numbers);

                        break;
                    case "another":
                        enteredValue = ReadValue("\nВы хотите ввести новое число?\nYes - да\nNo - нет\nВведите \"Yes\" или \"No\": ");

                        if (enteredValue == "yes")
                        {
                            enteredValue = ReadValue("Введите число: ");
                            AddNumber(numbers, enteredValue);
                        }
                        else if (enteredValue == "no")
                        {
                            enteredValue = ReadValue("\nВы хотите просуммировать введенные числа?\nYes - да\nNo - нет\nВведите \"Yes\" или \"No\": ");

                            if (enteredValue == "yes")
                            {
                                SumOfNumbers(numbers);
                            }
                            else if (enteredValue == "no")
                            {
                                enteredValue = ReadValue("\nВы хотите закончить работу?\nYes - да\nNo - нет\nВведите \"Yes\" или \"No\": ");

                                if (enteredValue == "yes")
                                {
                                    isWorking = false;
                                }
                                else if (enteredValue == "no")
                                {
                                    Console.WriteLine("\nТогда мне нечем вам помочь. Для возврата в главное меню нажмите любую клавишу...");
                                    Console.ReadKey(true);
                                }
                            }
                        }

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

        static void SumOfNumbers(List<int> numbers)
        {
            if (numbers.Count > 0)
            {
                int sumOfNumbers = 0;

                for (int j = 0; j < numbers.Count; j++)
                {
                    sumOfNumbers += numbers[j];
                }

                Console.WriteLine("\nСумма введенных чисел: " + sumOfNumbers);
            }
            else
            {
                Console.WriteLine("\nВы еще не ввели никаких чисел. В начале введите числа, и после этого я смогу их просуммировать.");
            }
        }
    }
}