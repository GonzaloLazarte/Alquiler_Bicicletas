using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Bicicletas {
    internal class MenuAlquilerBici {
        static AlquilerBicicletas servicio = new AlquilerBicicletas();  //instanciamos un objeto servicio para acceder a las propiedades de la clase alquilerBicicletas
        public void EjecutarMenu() {
            servicio.EjecutarServicioAlquiler();                        // ejecuta el metodo del objeto servicio que inicializa el archivo de bicicletas
            int opcion = 0;
            bool bucle = true;
            while (bucle) {
                Console.Clear();
                Console.WriteLine("============================== ALQUILER DE BICICLETAS ==============================");
                Console.WriteLine("================================== MENU DE OPCIONES ================================");
                Console.WriteLine("");
                Console.WriteLine("1) - RETIRAR BICICLETA");
                Console.WriteLine("");
                Console.WriteLine("2) - VER BICICLETAS");
                Console.WriteLine("");
                Console.WriteLine("3) - DEVOLVER BICICLETA");
                Console.WriteLine("");
                Console.WriteLine("4) - SALIR DEL PROGRAMA");
                Console.WriteLine("");
                Console.WriteLine("====================================================================================");
                Console.Write("PORFAVOR SELECCIONE UNA OPCION: > ");
                if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 4) {    //de validacion de la opcion ingresada
                    switch (opcion) {
                        case 1: servicio.Retirar(); break;              // 
                        case 2: servicio.Mostrar(); break;              //ejecutan los respectivos metodos del objeto servicio segun la opcion seleccionada
                        case 3: servicio.Devolver(); break;             //
                        case 4: bucle = false; break;
                    }
                }
                else {
                    Console.WriteLine("!!!!!!!! OPCION INVALIDA, POR FAVOR INGRESE UN NUMERO VALIDO !!!!!!!!");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            Console.WriteLine("====================================================================================");
            Console.WriteLine("||             GRACIAS POR USAR NUESTRO PROGRAMA HASTA LA PROXIMA                 ||");
            Console.WriteLine("====================================================================================");
            //Console.ReadKey();
        }
    }
}
