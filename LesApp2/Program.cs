using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            #region Взято із 7 уроку ДЗ
            // випадкові числа
            Random rnd = new Random();

            // створення фігури
            Figure figure = new Figure();

            Console.WriteLine("До створення точок:");

            Console.WriteLine(figure.ToString());

            Console.WriteLine("\nДодавання точок:");

            // задання координат і виведення назви фігури
            for (int i = 0; i < 7; i++)
            {
                figure.Add(new Point(rnd.Next(sbyte.MinValue, sbyte.MaxValue), 
                    rnd.Next(sbyte.MinValue, sbyte.MaxValue)));
                Console.WriteLine(figure.ToString());
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + new string('#', 80));
            Console.ResetColor();

            Console.WriteLine("\nВидалення точок:");

            // для видалення точок
            int num = figure.Count;
            #region Видалення по перших індексах
#if true
            for (int i = 0; i <= num; i++)
            {
                figure.Remove(0);
                Console.WriteLine(figure.ToString());
            }
#endif
            #endregion

            #region Видалення по останніх індексах
#if false
            for (int i = num - 1; i >= -1; i--)
            {
                figure.Remove(i);
                Console.WriteLine(figure.ToString());
            }
#endif 
            #endregion
            #endregion

            // repeat
            DoExitOrRepeat();
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
