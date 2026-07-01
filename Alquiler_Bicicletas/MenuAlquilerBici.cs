using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Bicicletas {
    internal class MenuAlquilerBici {
        static AlquilerBicicletas servicio = new AlquilerBicicletas();
        public void EjecutarMenu() {
            int opcion = 0;
            while (true) {
                Console.Clear();
                Console.WriteLine("============================== ALQUILER DE BICICLETAS ==============================");
                Console.WriteLine("================================== MENU DE OPCIONES ================================");
                Console.WriteLine("");
                Console.WriteLine("1) - RETIRAR BICICLETA");
                Console.WriteLine("2) - VER BICICLETAS");
                Console.WriteLine("3) - DEVOLVER BICICLETA");
                Console.WriteLine("");
                Console.WriteLine("====================================================================================");
                Console.Write("PORFAVOR SELECCIONE UNA OPCION: > ");
                if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 3) {
                    servicio.EjecutarServicioAlquiler();
                    switch (opcion) {
                        case 1: servicio.Retirar(); break;
                        case 2: servicio.Mostrar(); break;
                        case 3: servicio.Devolver(); break;
                    }
                }
                else {
                    Console.WriteLine("!!!!!!!! OPCION INVALIDA, POR FAVOR INGRESE UN NUMERO VALIDO !!!!!!!!");
                    Console.ReadKey();
                }
            }
        }
    }
}
