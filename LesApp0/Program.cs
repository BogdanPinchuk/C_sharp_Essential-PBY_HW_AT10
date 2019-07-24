using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    // делегат параметризований мысцем заповнення типом Т і приймає
    // два аргумента тільки по ссилці
    delegate void Delegate<T>(ref T a, ref T b); // where T : class; - фільт який би приймав лише ссилочні змінні

    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // рандомні числа
            Random rnd = new Random();

            {
                // створення делегату
                Delegate<int> del;

                // задаємо значення
                int a = rnd.Next(sbyte.MinValue, sbyte.MaxValue),
                    b = rnd.Next(sbyte.MinValue, sbyte.MaxValue);

                // зв'язування методів із делегатом
                del = Method2;
                del += Method1;
                del += Method2;

                // виконання результату
                del(ref a, ref b);
            }

            {
                // створення делегату
                Delegate<string> del;

                var week = Enum.GetValues(typeof(DayOfWeek))
                    .Cast<DayOfWeek>().ToArray();

                // задаємо значення
                string a = week[rnd.Next(0, week.Length)].ToString(),
                    b = week[rnd.Next(0, week.Length)].ToString();

                // зв'язування методів із делегатом
                del = Method2;
                del += Method1;
                del += Method2;

                // виконання результату
                del(ref a, ref b);
            }

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Узагальнений метод 0
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Method1<T>(ref T a, ref T b)
        {
            // міняємо місцями
            T c = a;
            a = b;
            b = c;
        }

        /// <summary>
        /// Узагальнений метод 1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Method2<T>(ref T a, ref T b)
        {
            Console.WriteLine($"\n\tЗнаачення 1-го аргументу - {a.ToString()}");
            Console.WriteLine($"\tЗнаачення 2-го аргументу - {b.ToString()}");
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
