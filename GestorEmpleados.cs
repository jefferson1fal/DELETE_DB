using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ULTIMA_CLASE
{
    public class GestorEmpleados
    {
        private string connectionString;

        public GestorEmpleados(string databasePath)
        {
            connectionString = $"Data Source={databasePath};Version=3;";
        }

        public void CrearTabla()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE IF NOT EXISTS Empleados (Id INTEGER PRIMARY KEY AUTOINCREMENT, Nombre VARCHAR(100), Apellido VARCHAR(100), Edad INTEGER, Cargo VARCHAR(100), Sueldo decimal, Ingreso DateTime)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Empleados (Nombre, Apellido, Edad, Cargo, Sueldo, Ingreso) " +
                               "VALUES (@Nombre, @Apellido, @Edad, @Cargo, @Sueldo, @Ingreso)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    command.Parameters.AddWithValue("@Edad", empleado.Edad);
                    command.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                    command.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);
                    command.Parameters.AddWithValue("@Ingreso", empleado.Ingreso);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarEmpleado(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Empleados WHERE Id = @Id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Empleados";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nombre = reader.GetString(1);
                            string apellido = reader.GetString(2);
                            int edad = reader.GetInt32(3);
                            string cargo = reader.GetString(4);
                            decimal sueldo = (decimal)reader.GetFloat(5);
                            DateTime ingreso = reader.GetDateTime(6);
                            Empleado empleado = new Empleado(id, nombre, apellido, edad, cargo, sueldo, ingreso);
                            empleados.Add(empleado);
                        }
                    }
                }
            }
            return empleados;
        }
    }
}
