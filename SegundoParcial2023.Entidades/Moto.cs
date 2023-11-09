using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public class Moto : Vehiculo
    {
        private int cilindrada;
        private short ruedas;
        private static int valorHora;
        static Moto()
        {
            valorHora = 30;
        }
        public Moto(string patente,int cilindrada) 
            :base(patente)
        {
            this.cilindrada = cilindrada;
            this.ruedas = 2;
        }
        public Moto(string patente, int cilindrada,short ruedas)
            : this(patente,cilindrada)
        {
            this.ruedas = ruedas;
        }
        public Moto(string patente, int cilindrada, short ruedas, int valor)
            : this(patente, cilindrada,ruedas)
        {
            valorHora = valor;
        }
        public override string ConsultarDatos()
        {
            return $"{GetType().Name} , {cilindrada}, " +
                $"{ruedas} , {valorHora} , {base.Patente}";
        }
        public override string ImprimirTicket()
        {
            return $"{base.ImprimirTicket()}";
        }
    }
}
