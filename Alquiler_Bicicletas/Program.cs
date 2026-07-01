using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Alquiler_Bicicletas {
    internal class Program {
        static AlquilerBicicletas servicio;
        static void Main(string[] args) {
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
                    servicio = new AlquilerBicicletas(opcion);
                }
                else {
                    Console.WriteLine("!!!!!!!! OPCION INVALIDA, POR FAVOR INGRESE UN NUMERO VALIDO !!!!!!!!");
                    Console.ReadKey();
                }
            }


        }
    }
}
