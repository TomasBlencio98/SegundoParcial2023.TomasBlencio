using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public class PickUp:Vehiculo
    {
        private string modelo;
        private static int valorHora;


        static PickUp()
        {
            valorHora = 70;
        }

        public PickUp(string patente, string modelo) : base(patente)
        {
            this.modelo = modelo;
        }
        public PickUp(string patente, string modelo, int valorh)
            : this(patente,modelo)
        {
            valorHora= valorh;
        }
        public override string ConsultarDatos()
        {
            return $"{GetType().Name} , {modelo} , {valorHora} ," +
                $"{base.Patente}";
        }
        public override string ImprimirTicket()
        {
            return $"{base.ImprimirTicket()}";
        }
    }
}
