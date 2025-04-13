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
                        ConvertirUnidades("distancia", lengthUnits);
                        break;
                    case 2:
                        ConvertirUnidades("masa", weightUnits);
                        break;
                    case 3:
                        ConvertirUnidades("temperatura", temperatureUnits);
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
            Console.Clear();
            Console.WriteLine("  UNIT CONVERTER / CONVERSOR DE UNIDADES    ");
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
        static void ConvertirUnidades(string dimension, string[] unidades)
        {
            Console.Clear();
            mostrarEncabezado();
            Console.WriteLine($"===== Convertir unidades de {dimension} ======");

            //Mostrar unidades de dimension
            Console.WriteLine("Unidades disponibles: ");
            for (int i = 0; i < unidades.Length; i++)
            {
                Console.WriteLine($"{(i)}.{unidades[i]}");
            }

            //Escoger y validar unidades de origen 
            Console.WriteLine("\nEscoja la unidad de origen (0,1,2,...):");            
            if (!int.TryParse(Console.ReadLine(),out int startIndex) || startIndex > unidades.Length)
            {
                Console.WriteLine("Ingreso de dato no válido\n");
            }
            Console.WriteLine("Unidad de origen: " + startIndex);

            //Escoger y validar unidad de destino
            Console.WriteLine("Escoja la unidad de destino (0,1,2,...):");
            if (!int.TryParse(Console.ReadLine(), out int endIndex) || endIndex > unidades.Length)
            {
                Console.WriteLine("Ingreso de dato no válido\n");
            }
            Console.WriteLine("Unidad de destino: " + endIndex);

            //Ingresar monto a convertir
            Console.WriteLine($"Introduzca el monto en {unidades[startIndex]}s");
            if (!double.TryParse(Console.ReadLine(),out double monto))
            {
                Console.WriteLine("Monto no válido. Ingrese un valor decimal");
            }
            Console.WriteLine("Monto a convertir: "+monto);

            //Conversion del monto 
            double montoConvertido = realizarConversion(dimension, unidades[startIndex], unidades[endIndex],monto);
            Console.WriteLine($"{monto} {unidades[startIndex]}s equivalen a {montoConvertido} {unidades[endIndex]}s");
            Console.WriteLine("Ingrese cualquier tecla para continuar");
            Console.ReadKey();
        }

        static double realizarConversion(string dimension,string unidadStart, string unidadEnd,double monto)
        {
            double resultado = 0;
            return resultado;
        }
    }
}

