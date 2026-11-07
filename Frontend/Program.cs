
using Backend;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList<int> list = new DoublyLinkedList<int>();

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

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opción válida.");
                opcion = -1;
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el número: ");

                    if (int.TryParse(Console.ReadLine(), out int New))
                    {
                        list.Add(New);
                        Console.WriteLine("Elemento agregado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número entero.");
                    }
                    break;

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
                    Console.WriteLine("\nGráfico :");
                    list.ShowGraph();
                    break;

                case 7:
                    Console.Write("Ingrese el número que desea buscar: ");

                    if (int.TryParse(Console.ReadLine(), out int search))
                    {
                        if (list.ItExists(search))
                            Console.WriteLine("El elemento sí existe.");
                        else
                            Console.WriteLine("El elemento no existe.");
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número entero.");
                    }
                    break;

                case 8:
                    Console.Write("Ingrese el número que desea eliminar: ");

                    if (int.TryParse(Console.ReadLine(), out int eliminate))
                    {
                        if (list.RemoveOneOccurrence(eliminate))
                            Console.WriteLine("Se eliminó una ocurrencia.");
                        else
                            Console.WriteLine("El elemento no existe.");
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número entero.");
                    }
                    break;

                case 9:
                    Console.Write("Ingrese el número que desea eliminar: ");

                    if (int.TryParse(Console.ReadLine(), out int deleteAll))
                    {
                        int amount = list.RemoveAllOccurrences(deleteAll);

                        Console.WriteLine("Cantidad de elementos eliminados: " + amount);
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número entero.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }
}

