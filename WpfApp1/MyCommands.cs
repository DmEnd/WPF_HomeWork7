using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    internal class MyCommands
    {
        //Объявляем команду
        public static RoutedCommand Exit { get; set; }
        //Инициализируем команду
        static MyCommands()
        {
            Exit = new RoutedCommand();
        }
    }
}
