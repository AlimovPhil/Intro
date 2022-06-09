using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
5. (*) Список задач(ToDo-list):
● написать приложение для ввода списка задач;
● задачу описать классом ToDo с полями Title и IsDone;
● на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран; -
● если задача выполнена, вывести перед её названием строку «[x]»; 
● вывести порядковый номер для каждой задачи;
● при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
● записать актуальный массив задач в файл tasks.json/xml/bin.*/
namespace Lesson5
{
        /// <summary>
        /// Задача
        /// </summary>
        [Serializable] // Атрибут Serializable требуется для корректной работы бинарной сериализации
        public class ToDo
        {
            /// <summary>
            /// Наименование задачи
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Задача завершена?
            /// </summary>
            public bool IsDone { get; set; }

        }
}
