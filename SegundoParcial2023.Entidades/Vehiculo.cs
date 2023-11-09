using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public abstract class Vehiculo
    {
        private DateTime ingreso;
        private string patente;

        public Vehiculo(string patente)
        {
            if (Validar(patente))
            {
                Patente = patente;
            }
            else
            {
                Patente = "Error";
            }
            ingreso = DateTime.Now.AddHours(-3);
        }

        public string Patente { get=>patente; set=>patente=value; }

        public abstract string ConsultarDatos();
        public override string ToString()
        {
            return $"Patente {patente.ToUpper()}";
        }
        public DateTime GetIngreso()
        {
            return ingreso;
        }
        public virtual string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ToString());
            sb.AppendLine($"Fecha Ingreso: {ingreso.ToShortDateString()}");
            sb.AppendLine($"Hora Ingreso: {ingreso.Hour}");
            sb.AppendLine("");
            return sb.ToString();   
        }
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.patente==v2.patente;
        }
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        public override bool Equals(object? obj)
        {
            Vehiculo v;
            if (obj is null || obj.GetType() != this.GetType())
            {
                return false;
            }
            v = obj as Vehiculo;
            return this == v;
        }
        public  static bool Validar(string patente)
        {
            if (patente == null)
            {
                return false;
            }
            if (patente.Length != 7 && patente.Length != 9)
            {
                return false;
            }
            else if (patente.Length == 7)
            {
                return ValidarPatenteVieja(patente);
            }
            else
            {
                return ValidarPatenteNueva(patente);
            }

        }

        private static bool ValidarPatenteNueva(string patente)
        {
            var array = patente.Split(' ');
            var parteAlfa1 = array[0];
            var parteNum = array[1];
            var parteAlfa2 = array[2];
            if (!ValidarParteAlfa(parteAlfa1))
            {
                return false;
            }
            if (!(ValidarParteNum(parteNum)))
            {
                return false;
            }
            if (!ValidarParteAlfa(parteAlfa2))
            {
                return false;
            }

            return true;

        }

        private static bool ValidarPatenteVieja(string patente)//AAA NNN
        {
            var array = patente.Split(' ');
            var parteAlfa = array[0];
            var parteNum = array[1];
            if (!ValidarParteAlfa(parteAlfa))
            {
                return false;
            }
            if (!ValidarParteNum(parteNum))
            {
                return false;
            }
            return true;
        }
        private static bool ValidarParteAlfa(string parteAlfa)
        {
            foreach (var letra in parteAlfa)
            {
                if (!char.IsLetter(letra)) // Esta función devuelve un valor booleano que indica si el carácter pasado 								
                                           // como argumento es una letra del alfabeto o no.
                {
                    return false;
                }
            }
            return true;
        }
        private static bool ValidarParteNum(string parteNum)
        {
            foreach (var item in parteNum)
            {
                if (!char.IsNumber(item))
                {
                    return false;
                }
            }
            return true;
        }


        public static string GetTipo(string patente)
        {
            if (patente == null)
            {
                return "Patente no ingresada";
            }

            else if (patente.Length == 7)
            {
                return "Patente Vieja";
            }
            else if (patente.Length == 9)
            {
                return "Patente Nueva";
            }
            else
            {
                return "Formato no válido";
            }

        }
    }
}

