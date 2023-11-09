using SegundoParcial2023.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Datos
{
    public class Estacionamiento
    {
        private int espacioDisponible;
        private string nombre;
        private List<Vehiculo> vehiculos;
        private Estacionamiento()
        {
            vehiculos = new List<Vehiculo>();
        }
        public Estacionamiento(string nombre, int espacio):this()
        {
            this.nombre = nombre;
            this.espacioDisponible=espacio;
        }
        public static explicit operator string(Estacionamiento e)
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Espacios Disponibles: {e.espacioDisponible}");
            sb.AppendLine("Vehiculos");
            foreach (var v in e.vehiculos)
            {
                sb.AppendLine(v.ConsultarDatos());
            }
            return sb.ToString();
        }


        public static bool operator ==(Estacionamiento estacion, Vehiculo vehiculo)
        {
            if (estacion is null || vehiculo is null)
            {
                return false;
            }
            foreach (var v in estacion.vehiculos)
            {
                if (v == vehiculo)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Estacionamiento estacion, Vehiculo vehiculo)
        {
            return !(estacion == vehiculo);
        }


        public static Estacionamiento operator +(Estacionamiento estacion, Vehiculo vehiculo)
        {
            if (estacion is null || vehiculo is null)
            {
                return estacion;
            }
            if (estacion.espacioDisponible<=estacion.vehiculos.Count)
            {
                return estacion;
            }
            if (estacion == vehiculo)
            {
                return estacion; //falso porqe ya existe
            }
            else
            {
                estacion.vehiculos.Add(vehiculo);
                return estacion;
            }
        }


        public static string operator -(Estacionamiento estacion, Vehiculo vehiculo)
        {
            if (estacion is null || vehiculo is null)
            {
                return "Error";
            }
            if (estacion != vehiculo)
            {
                return "El vehiculo no se encuentra en el Estacionamiento";
            }
            else
            {
                int valorHora = 0;
                if (vehiculo.GetType()==typeof(Moto))
                {
                    valorHora = 30;
                }
                else if (vehiculo.GetType() == typeof(PickUp))
                {
                    valorHora = 70;
                }
                else
                {
                    valorHora = 50;
                }
                DateTime horaSalida = DateTime.Now;
                TimeSpan estadia = horaSalida.Subtract(vehiculo.GetIngreso());
                // Para obtener la duración en horas, minutos y segundos
                int horas = estadia.Hours;
                int minutos = estadia.Minutes;
                int segundos = estadia.Seconds;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(vehiculo.ImprimirTicket());
                sb.AppendLine($"Hora Egreso: {horaSalida.Hour}");
                sb.AppendLine($"Estadia: {estadia.Hours}");
                sb.AppendLine($"Costo: {estadia.Hours*valorHora}");
                return sb.ToString();
            }

        }


    }
}
