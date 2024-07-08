using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.Data
{
    public class Parametro
    {


        public Parametro(string nombre, string valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
