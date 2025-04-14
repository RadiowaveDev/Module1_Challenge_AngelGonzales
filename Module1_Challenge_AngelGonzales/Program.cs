using System.Drawing;

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
            Console.WriteLine("================================================\n");
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
            Console.WriteLine($"======= Convertir unidades de {dimension} ========");

            //Mostrar unidades de dimension
            Console.WriteLine("Unidades disponibles: ");
            for (int i = 0; i < unidades.Length; i++)
            {
                Console.WriteLine($"{(i)}.{unidades[i]}");
            }

            //Escoger y validar unidad de origen 
            Console.WriteLine("\nEscoja la unidad de origen (0,1,2,...):");            
            if (!int.TryParse(Console.ReadLine(),out int startIndex) || startIndex > unidades.Length)
            {
                Console.WriteLine("Ingreso de dato no válido\n");
                Console.WriteLine("Digite cualquier tecla para continuar ...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Unidad de origen: " + startIndex);

            //Escoger y validar unidad de destino
            Console.WriteLine("\nEscoja la unidad de destino (0,1,2,...):");
            if (!int.TryParse(Console.ReadLine(), out int endIndex) || endIndex > unidades.Length)
            {
                Console.WriteLine("Ingreso de dato no válido\n");
                Console.WriteLine("Digite cualquier tecla para continuar ...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Unidad de destino: " + endIndex);

            //Ingresar monto a convertir
            Console.WriteLine($"\nIntroduzca el monto en {unidades[startIndex]}");
            if (!double.TryParse(Console.ReadLine(),out double monto))
            {
                Console.WriteLine("Monto no válido. Ingrese un valor decimal");
            }
            Console.WriteLine("Monto a convertir: " + monto);

            //Conversion del monto 
            double montoConvertido = realizarConversion(dimension, unidades[startIndex], unidades[endIndex],monto);
            Console.WriteLine($"\n{monto} {unidades[startIndex]} equivalen a {montoConvertido} {unidades[endIndex]}");
            Console.WriteLine("Ingrese cualquier tecla para continuar");
            Console.ReadKey();
        }

        static double realizarConversion(string dimension,string unidadStart, string unidadEnd,double monto)
        {
            if (unidadStart == unidadEnd)
            {
                return monto;
            }
            
            double resultado = 0;
            double valorReferencia = 0;

            switch (dimension)
            {
                case "distancia":
                    valorReferencia = conversionAMetros(unidadStart, monto);
                    resultado = conversionDesdeMetros(unidadEnd,valorReferencia);
                    break;
                case "masa":
                    valorReferencia = conversionAKilogramos(unidadStart, monto);
                    resultado = conversionDesdeKilogramos(unidadEnd,valorReferencia);
                    break;
                case "temperatura":
                    resultado = conversionTemperatura(unidadStart,unidadEnd,monto);
                    break;
            }
            return Math.Round(resultado,5);
        }

        static double conversionAMetros(string unidadStar,double monto)
        {
            //string[] lengthUnits = { "metro", "kilometro", "pulgada", "pie", "milla" };
            switch (unidadStar)
            {
                case "metro":
                    return monto;
                case "kilometro":
                    return monto * 1000;
                case "pulgada":
                    return monto *0.0254;
                case "pie":
                    return monto * 0.3048;
                case "milla":
                    return monto * 1609.344;
                default:
                    return 0;
            }
        }
        static double conversionDesdeMetros(string unidadEnd, double metros)
        {
            switch (unidadEnd)
            {
                case "metro":
                    return metros;
                case "kilometro":
                    return metros / 1000;
                case "pulgada":
                    return metros / 0.0254;
                case "pie":
                    return metros / 0.3048;
                case "milla":
                    return metros / 1609.344;
                default:
                    return 0;
            }
        }
        static double conversionAKilogramos(string unidadStart, double monto)
        {
            //string[] weightUnits = { "kilogramo", "gramo", "libra", "onza", "tonelada" };
            switch (unidadStart)
            {
                case "kilogramo":
                    return monto;
                case "gramo":
                    return monto / 1000;
                case "libra":
                    return monto * 0.45359237;
                case "onza":
                    return monto * 0.0283495;
                case "tonelada":
                    return monto * 1000;
                default:
                    return 0;
            }
        }
        static double conversionDesdeKilogramos(string unidadEnd, double kilos)
        {
            switch (unidadEnd)
            {
                case "kilogramo":
                    return kilos;
                case "gramo":
                    return kilos * 1000;
                case "libra":
                    return kilos / 0.45359237;
                case "onza":
                    return kilos / 0.0283495;
                case "tonelada":
                    return kilos / 1000;
                default:
                    return 0;
            }
        }

        static double conversionTemperatura(string unidadStart, string unidadEnd, double monto)
        {
            //string[] temperatureUnits = { "celsius", "fahrenheit", "kelvin" };
            double celsius = 0;
            switch (unidadStart)
            {
                case "celsius":
                    celsius = monto;
                    break;
                case "fahrenheit":
                    celsius = (monto - 32) * 5 / 9; ;
                    break;
                case "kelvin":
                    celsius = monto - 273.15;
                    break;
            }
            switch (unidadEnd)
            {
                case "celsius":
                    return celsius;
                case "fahrenheit":
                    return (celsius * 9 / 5) +32;
                case "kelvin":
                    return celsius + 273.15;
                default:
                    return 0;
            }
        }
    }
}

