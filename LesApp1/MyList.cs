using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Перестворювати масив кожен раз при додаванні/видалені
// об'єктів є неефктивним, що забирає ресурси і уповільнює роботу

namespace LesApp1
{
    /// <summary>
    /// Колекція типу Т
    /// </summary>
    class MyList<T>
    {
        /// <summary>
        /// Масив значень типу Т
        /// </summary>
        T[] array;
        /// <summary>
        /// Кількість елементів в масиві
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Ємніссть масиву
        /// </summary>
        public int Capacity { get { return array.Length; } }

        /// <summary>
        /// конструктор який створює масив значить певного типу
        /// </summary>
        public MyList()
        {
            // 4 - стандартне значення за замовчуванням
            array = new T[4];
            // установка початкового значення елементів
            Count = 0;
        }

        /// <summary>
        /// Індексатор
        /// </summary>
        /// <param name="index">індекс доступу до елементів</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    return array[index];
                }
                else
                {
                    Error();
                    return default;
                }
            }
            set
            {
                if (0 <= index && index < Count)
                {
                    array[index] = value;
                }
                else
                {
                    Error();
                }
            }
        }

        /// <summary>
        /// Помилка, вихыд за межі масиву
        /// </summary>
        private void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tСпроба виходу за межі колекції/масиву.");
            Console.ResetColor();
        }

        /// <summary>
        /// Зміна розміру масиву
        /// </summary>
        /// <param name="newSize">новий розмір масиву</param>
        private void Resize(int newSize)
        {
            // тимчасовий масив
            T[] temp = new T[newSize];
            // копіювання даних
            for (int i = 0; i < Count; i++)
            {
                temp[i] = array[i];
            }
            // зміна ссилки
            array = temp;
        }

        /// <summary>
        /// Додавання масиву значень
        /// </summary>
        /// <param name="mas">масив значень</param>
        public void AddRange(params T[] mas)
        {
            #region вибір розміру масиву
            // в даному випадку для керування об'ємом масиву необхідно
            // розв'язати рівняння: capacity = 2^n > count
            // 2^n > count
            // log_2(2^n) > log_2(count)
            // n > log_2(count)
            // n = ln(count) / ln(2)
            // а так як передається певна кількість елементів length,
            // які необхідно доадти в масив, то рівняння прийме вигляд
            // n = ln(count + length) / ln(2)
            // якщо count + length == capacity то в такому випадку степінь n,
            // буде цілим числом і ємність залишиться такою як і була і неможливо додати
            // нові об'єкти, а тому необхідно додати 1
            // якщо ж count + length > capacity, то ми отримаємо дійсне n
            // округливши його в напрямку + безкінечності функцією ceiling
            // ми отримаємо ціле число n, яке вмыщатиме всі нові об'єкти
            #endregion

            // немає вхідних даних то виходимо з методу
            if (mas.Length < 1)
            {
                return;
            }

            // степінь числа 2 який визначатиме ємність масиву
            var power = (int)Math.Ceiling(Math.Log(mas.Length + Count)
                / Math.Log(2));

            // перевырка чи всі елемнти помістяться в наявний масив
            if (mas.Length + Count == Capacity)
            {
                Resize((int)Math.Pow(2, power + 1));
            }
            else if (mas.Length + Count > Capacity)
            {
                Resize((int)Math.Pow(2, power));
            }

            // запис додаткових елемнтів в масив
            for (int i = 0; i < mas.Length; i++)
            {
                array[Count++] = mas[i];
            }
        }

        /// <summary>
        /// Додавання одного значення
        /// </summary>
        /// <param name="value"></param>
        public void Add(T[] value)
        {
            AddRange(value);
        }

        /// <summary>
        /// Видалення елемента по певному індексу
        /// </summary>
        /// <param name="index">індекс</param>
        public void RemoveAt(int index)
        {
            // якщо  іде звернення поза діапазоном
            if (!(0 <= index && index < Count))
            {
                Error();
                return;
            }

            // видаляємо елемнт простим зміщенням вліво
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            // Зменшуємо лічильник кількості елемнтів
            Count--;

            // для економії пам'яті перевіряємо величину  масиву
            if (Count == Capacity / 2)
            {
                Resize(Capacity / 2);
            }
        }

        /// <summary>
        /// Видалити всі елементи
        /// </summary>
        public void RemoveAll()
        {
            // 4 - стандартне значення за замовчуванням
            array = new T[4];
            // установка початкового значення елементів
            Count = 0;
        }

        /// <summary>
        /// Виведення результату масиву
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // для зцеплення рядків
            var s = new StringBuilder();
            // внесення даних з колекції/списку
            for (int i = 0; i < Count; i++)
            {
                s.Append(array[i].ToString() + " ");
            }

            return s.ToString();
        }

        /// <summary>
        /// Виведення інформації про колекцію
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"\n\tКількість елемнтів в колекції: {Count}");
            Console.WriteLine($"\tЄмність колекції: {Capacity}");
            Console.WriteLine($"\tТип даних: {typeof(T).Name}");
        }

    }
}
