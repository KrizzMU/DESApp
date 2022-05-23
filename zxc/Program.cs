using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread] // Указывает, что потоковой моделью COM для приложения является однопотоковое подразделение (STA)
                    // все потоки в этой программе выполняются в рамках одного процесса, а управление программой осуществляется одним главным потоком.
        static void Main()
        {
            Application.EnableVisualStyles(); //Включает визуальные стили для приложения.
            Application.SetCompatibleTextRenderingDefault(false); //Задает значения по умолчанию во всем приложении для свойства UseCompatibleTextRendering, определенного в конкретных элементах управления.
            Application.Run(new Form1()); //Запускает стандартный цикл обработки сообщений приложения в текущем потоке и делает указанную форму видимой.
        }
    }
}
