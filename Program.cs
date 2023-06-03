using ULTIMA_CLASE;

class Program
{
    static void Main(string[] args)
    {
        // Código de inicio de la aplicación

        // Crear una instancia de GestorEmpleados y llamar a sus métodos
        string databasePath = @"C:\Users\Abac Lemus\Desktop\III CICLO\Pogramacion 1\proyectos\ULTIMA CLASE\database.sqlite"; ;
        GestorEmpleados gestorEmpleados = new GestorEmpleados(databasePath);
        gestorEmpleados.CrearTabla();
        DateTime ingreso = DateTime.Now;


        //Agregar empleados
        Empleado empleado1 = new Empleado(1, "manuel", "Lopez", 21, "Gerente", 8000, ingreso);
        gestorEmpleados.AgregarEmpleado(empleado1);

        Empleado empleado2 = new Empleado(2, "Leo", "ZEpeda", 18, "programador", 10000, ingreso);
        gestorEmpleados.AgregarEmpleado(empleado1);


        Empleado empleado3 = new Empleado(3, "Neftali", "Barrera", 26, "backend", 9000, ingreso);
        gestorEmpleados.AgregarEmpleado(empleado1);


        Empleado empleado4 = new Empleado(4, "Byron", "rodriguez", 30, "estrcturador de datos", 8000, ingreso);
        gestorEmpleados.AgregarEmpleado(empleado1);




        Console.WriteLine("Empleados agregados exitosamente.");

        // Resto de las operaciones que desees realizar

        //int idEmpleadoAEliminar = 5;
        //gestorEmpleados.EliminarEmpleado(idEmpleadoAEliminar);
        //Console.WriteLine("Empleado eliminado exitosamente.");

        //int idEmpleadoAEliminar1 = 6;
        //gestorEmpleados.EliminarEmpleado(idEmpleadoAEliminar1);
        //Console.WriteLine("Empleado eliminado exitosamente.");

        //int idEmpleadoAEliminar2 = 3;
        //gestorEmpleados.EliminarEmpleado(idEmpleadoAEliminar2);
        //Console.WriteLine("Empleado eliminado exitosamente.");

        //int idEmpleadoAEliminar3 = 4;
        //gestorEmpleados.EliminarEmpleado(idEmpleadoAEliminar3);
        //Console.WriteLine("Empleado eliminado exitosamente.");

        Console.ReadKey();

        // Obtener la lista de empleados
        List<Empleado> empleados = gestorEmpleados.ObtenerEmpleados();

        // Mostrar el nombre, cargo y edad de cada empleado
        empleados.ForEach(e => Console.WriteLine($"Nombre: {e.Nombre }, Cargo: {e.Cargo }, Edad: {e.Edad } , sueldo: {e.Sueldo},ingreso: {e.Ingreso}"));



        // Pausa para ver los resultados antes de que finalice el programa
        Console.WriteLine("Presiona cualquier tecla para salir...");

    }
}
