using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// була порада чим мешне використовувати поля
// а поля приватні автоматично створюються при своренні властивостей

namespace LesApp2
{
    struct Point
    {
        /// <summary>
        /// Координата по осі Ox
        /// </summary>
        public int? X { get; set; }
        /// <summary>
        /// Координата по осі Oy
        /// </summary>
        public int? Y { get; set; }

        /// <summary>
        /// Конструктор користувача
        /// </summary>
        public Point(int? x, int? y)
        {
            X = x;
            Y = y;
        }

    }
}
