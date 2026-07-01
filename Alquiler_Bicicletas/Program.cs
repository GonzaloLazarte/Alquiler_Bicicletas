using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Alquiler_Bicicletas {
    internal class Program {
        static void Main(string[] args) {
            MenuAlquilerBici menu = new MenuAlquilerBici(); //Instanciamos el objeto menu
            menu.EjecutarMenu();                            //Llamamos al método EjecutarMenu de la clase MenuAlquilerBici para iniciar el menú de alquiler de bicicletas
        }
    }
}
