using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULTIMA_CLASE
{
    public class Empleado
    {
        

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int Edad { get; set; }
        public string Cargo { get; set; }

        public decimal  Sueldo { get; set; } 

        public DateTime Ingreso { get; set; }

        public Empleado(int id, string nombre, string apellido, int edad, string cargo, decimal sueldo, DateTime ingreso)
        {
            Id = id;
            Nombre = nombre;
            this.Apellido = apellido;
            Edad = edad;
            Cargo = cargo;
            this.Sueldo = sueldo;
            this.Ingreso = ingreso;

        }




        public override string ToString()
        {
            return $"Id: {Id} Nombre: {Nombre} Apellido: {Apellido} Edad: {Edad} Cargo: {Cargo} sueldo: {Sueldo} ingreso: {Ingreso}";

        }
    }
}
