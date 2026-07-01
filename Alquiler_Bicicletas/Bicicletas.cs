using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler_Bicicletas {
    internal class Bicicletas {
        public int IdBicletas { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime HoraSalida { get; set; }
        public double PrecioPorHora { get; set; }
        public Bicicletas(int _id, string _nombre, DateTime _hora, double _precio) {
            IdBicletas = _id;
            NombreUsuario = _nombre;
            HoraSalida = _hora;
            PrecioPorHora = _precio;
        }
    }
}
