using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Alquiler_Bicicletas {
    internal class AlquilerBicicletas {
        private readonly string archivo_bici = Path.Combine("Datos", "bicis.txt");

        public void EjecutarServicioAlquiler() {
            InicializarArchivo();
        }
        private void InicializarArchivo() {
            Directory.CreateDirectory("Datos");

            if (!File.Exists(archivo_bici)) {
                File.Create(archivo_bici).Close();
            }
        }
        private int ValidarId() {
            int _id = 0;
            while (true) {
                Console.Write("Ingresar Id de la bicicleta> ");
                if (int.TryParse(Console.ReadLine(), out _id) && _id >= 0 && _id <= 9999) {
                    break;
                }
                else {
                    Console.WriteLine("!!!!!!!! ID INVALIDO, POR FAVOR INGRESE UN NUMERO VALIDO !!!!!!!!");
                }
            }
            return _id;
        }
        private double ValidarPrecio() {
            double _precio = 0;
            while (true) {
                Console.Write("Ingresar Precio por hora> ");
                if (double.TryParse(Console.ReadLine(), out _precio) && _precio >= 0) {
                    break;
                }
                else {
                    Console.WriteLine("!!!!!!!! PRECIO INVALIDO, POR FAVOR INGRESE UN NUMERO VALIDO !!!!!!!!");
                }
            }
            return _precio;
        }
        private bool ExisteBici(int _id) {
            string[] lineas = File.ReadAllLines(archivo_bici);

            foreach (string linea in lineas) {
                string[] datos = linea.Split('|');
                if (int.Parse(datos[0]) == _id) {
                    return true;
                }
            }
            return false;
        }
        public void Retirar() {
            Console.Clear();
            int Id = 0;
            string NombreUsuario = string.Empty;
            DateTime HoraSalida = DateTime.Now;
            double PrecioPorHora = 0;

            Console.WriteLine("============================== Complete el formulario de retiro ==============================");
            Console.WriteLine("");
            Id = ValidarId();
            if (ExisteBici(Id)) {
                Console.WriteLine("La bicicleta con ID " + Id + " ya ha sido retirada.");
                return;
            }

            Console.Write("Ingrese el Nombre del usuario: > ");
            NombreUsuario = Console.ReadLine();

            Console.Write("Ingrese el precio por hora: > ");
            PrecioPorHora = ValidarPrecio();

            Bicicletas bici = new Bicicletas(Id, NombreUsuario, HoraSalida, PrecioPorHora);
            StreamWriter sw = new StreamWriter(archivo_bici, true);

            sw.WriteLine(bici.IdBicletas + "|" + bici.NombreUsuario + "|" + bici.HoraSalida + "|" + bici.PrecioPorHora);
            sw.Close();

            Console.WriteLine();
            Console.WriteLine("Bicicleta retirada correctamente.");

            Console.ReadKey();
        }
        public void Mostrar() {
            Console.Clear();
            string[] lineas = File.ReadAllLines(archivo_bici);

            if (lineas.Length == 0) {
                Console.WriteLine("No hay bicicletas retiradas.");
                Console.ReadKey();
                return;
            }

            foreach (string linea in lineas) {
                string[] datos = linea.Split('|');
                Console.WriteLine("==================================");
                Console.WriteLine("ID: " + datos[0]);
                Console.WriteLine("Usuario: " + datos[1]);
                Console.WriteLine("Hora Inicio: " + datos[2]);
                Console.WriteLine("Precio/Hora: $" + datos[3]);
            }
            Console.ReadKey();
        }
        public void Devolver() {
            int id = 0;
            bool buscar = false;
            double precio = 0, horas = 0, total = 0;

            string[] lineas = File.ReadAllLines(archivo_bici);

            List<string> nuevasLineas = new List<string>();

            if (lineas.Length == 0) {
                Console.Clear();
                Console.WriteLine("No hay bicicletas retiradas.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            id = ValidarId();

            foreach (string linea in lineas) {
                string[] datos = linea.Split('|');

                if (int.Parse(datos[0]) == id) {
                    buscar = true;

                    DateTime inicio = DateTime.Parse(datos[2]);
                    precio = double.Parse(datos[3]);

                    TimeSpan tiempo = DateTime.Now - inicio;

                    horas = Math.Ceiling(tiempo.TotalHours);

                    total = horas * precio;

                    Console.WriteLine();
                    Console.WriteLine("========= TICKET =========");
                    Console.WriteLine("Usuario: " + datos[1]);
                    Console.WriteLine("Bicicleta: " + datos[0]);
                    Console.WriteLine("Inicio: " + inicio);
                    Console.WriteLine("Fin: " + DateTime.Now);
                    Console.WriteLine("Horas utilizadas: " + horas);
                    Console.WriteLine("Total a pagar: $" + total);
                    Console.WriteLine("==========================");
                }
                else {
                    nuevasLineas.Add(linea);
                }
            }
            if (buscar == false) {
                Console.WriteLine("Bicicleta no encontrada.");
                return;
            }
            File.WriteAllLines(archivo_bici, nuevasLineas);
            Console.ReadKey();

        }

    }
}
