namespace Module1_Challenge_AngelGonzales
{
    internal class Program
    {
        static readonly string[] lengthUnits = { "metro", "kilometro", "pulgada", "pie", "milla" };
        static readonly string[] weightUnits = { "kilogramo", "gramo", "libra", "onza", "tonelada" };
        static readonly string[] temperatureUnits = { "celsius", "fahrenheit", "kelvin" };

        static void Main(string[] args)
        {
            bool seguir=true;
            while (seguir)
            {
                mostrarEncabezado();
                int opcion = MenuPrincipal();
                switch (opcion)
                {
                    case 1:
                        //ConvertirUnidades("distancia", lengthUnits);
                        break;
                    case 2:
                        //ConvertirUnidades("masa", weightUnits);
                        break;
                    case 3:
                        //ConvertirUnidades("temperatura", temperatureUnits);
                        break;
                    case 4:
                        seguir= false;
                        Console.WriteLine("Fin del programa. ¡Gracias por su preferencia!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Digite cualquier tecla para continuar ...");
                        Console.ReadKey();
                        break;
                }
            }  
        }

        static void mostrarEncabezado()
        {
            Console.WriteLine("\n   UNIT CONVERTER / CONVERSOR DE UNIDADES    ");
            Console.WriteLine("==============================================\n");
        }
        static int MenuPrincipal()
        {
            Console.WriteLine("¿Qué tipo de conversión desea realizar?");
            Console.WriteLine("1. Longitud");
            Console.WriteLine("2. Peso");
            Console.WriteLine("3. Temperatura");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción (1-4): ");
            if (int.TryParse(Console.ReadLine(), out int opcion))
                return opcion;
            return 0;
        }

    }
}
