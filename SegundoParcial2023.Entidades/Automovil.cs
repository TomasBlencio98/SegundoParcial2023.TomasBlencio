using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public class Automovil:Vehiculo
    {
        private ConsoleColor color;
        private static int valorHora;
        static Automovil()
        {
            valorHora = 50;
        }

        public Automovil(string patente, ConsoleColor coll) : base(patente)
        {
            this.color = coll;
        }
        public Automovil(string patente, ConsoleColor coll, int valor)
            : this(patente,coll)
        {
            valorHora= valor;
        }
        public override string ConsultarDatos()
        {
            return $"{GetType().Name} , {color} , {valorHora} , " +
                $"{base.Patente}";
        }
        public override string ImprimirTicket()
        {
            return $"{base.ImprimirTicket()}";
        }
    }
}
