
using Backend;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList<IComparable> list =
            new DoublyLinkedList<IComparable>(new DataComparator()); ;

        int opcion;

        do
        {
            Console.WriteLine("\n===== LISTA DOBLEMENTE LIGADA =====");
            Console.WriteLine("1. Adicionar");
            Console.WriteLine("2. Mostrar hacia adelante");
            Console.WriteLine("3. Mostrar hacia atrás");
            Console.WriteLine("4. Ordenar descendentemente");
            Console.WriteLine("5. Mostrar la(s) moda(s)");
            Console.WriteLine("6. Mostrar gráfico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una ocurrencia");
            Console.WriteLine("9. Eliminar todas las ocurrencias");
            Console.WriteLine("0. Salir");
            Console.Write("\nSeleccione una opción: ");

            int.TryParse(Console.ReadLine(), out opcion);
            

            switch (opcion)
            {
                case 1:
                    {
                        IComparable? date = ReadData();

                        if (date != null)
                        {
                            list.Add(date);
                            Console.WriteLine("Dato agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No ingresaste ningún dato.");
                        }

                        break;
                    }

                case 2:
                    Console.WriteLine("\nLista hacia adelante:");
                    list.ShowNext();
                    break;

                case 3:
                    Console.WriteLine("\nLista hacia atrás:");
                    list.ShowBack();
                    break;

                case 4:
                    list.SortDescending();
                    Console.WriteLine("Lista ordenada descendentemente.");
                    list.ShowNext();
                    break;

                case 5:
                    list.ShowModas();
                    break;

                case 6:
                    Console.WriteLine("\nGráfico de ocurrencias:");
                    list.ShowGraph();
                    break;

                case 7:
                    {
                        IComparable? dato = ReadData();

                        if (dato != null)
                        {
                            Console.WriteLine(
                                list.ItExists(dato)
                                ? "El dato sí existe."
                                : "El dato no existe."
                            );
                        }
                        else
                        {
                            Console.WriteLine("Dato no válido.");
                        }

                        break;
                    }

                case 8:
                    {
                        IComparable? date = ReadData();

                        if (date != null)
                        {
                            if (list.RemoveOneOccurrence(date))
                                Console.WriteLine("Se eliminó una ocurrencia.");
                            else
                                Console.WriteLine("El dato no existe.");
                        }
                        else
                        {
                            Console.WriteLine("Dato no válido.");
                        }

                        break;
                    }

                case 9:
                    {
                        IComparable? date = ReadData();

                        if (date != null)
                        {
                            int eliminate =
                                list.RemoveAllOccurrences(date);

                            Console.WriteLine(
                                $"Se eliminaron {eliminate} ocurrencia(s)."
                            );
                        }
                        else
                        {
                            Console.WriteLine("Dato no válido.");
                        }

                        break;
                    }

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }

    static IComparable? ReadData()
    {
        Console.Write("Ingrese un número o una palabra: ");

        string text = Console.ReadLine()?.Trim() ?? "";

        if (text == "")
            return null;

        if (int.TryParse(text, out int number))
            return number;

        return text;
    }
}

