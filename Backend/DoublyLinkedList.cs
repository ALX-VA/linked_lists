using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend;

public class DoublyLinkedList<T> 
{
    private Node<T>? First;
    private Node<T>? Last;

    private readonly IComparer<T> comparator;

    public DoublyLinkedList(IComparer<T>? comparator = null)
    {
        First = null;
        Last = null;

        this.comparator = comparator ?? Comparer<T>.Default;
    }


    public void Add(T date)
    {
        Node<T> New = new Node<T>(date);

        if (First == null)
        {
            First = New;
            Last = New;
            return;
        }

        if (comparator.Compare(date, First.Date) <= 0)
        {
            New.Next = First;
            First.Forme = New;
            First = New;
            return;
        }

        Node<T> current = First;

        while (current.Next != null &&
               comparator.Compare(date, current.Next.Date) > 0)
        {
            current = current.Next;
        }

        New.Next = current.Next;
        New.Forme = current;

        if (current.Next != null)
        {
            current.Next.Forme = New;
        }
        else
        {
            Last = New;
        }

        current.Next = New;
    }


    public void ShowNext()
    {
        if (First == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Node<T>? current = First;

        while (current != null)
        {
            Console.Write(current.Date + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }


    public void ShowBack()
    {
        if (Last == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Node<T>? current = Last;

        while (current != null)
        {
            Console.Write(current.Date + " ");
            current = current.Forme;
        }

        Console.WriteLine();
    }


    public void SortDescending()
    {
        if (First == null)
            return;

        Node<T>? current = First;

        while (current != null)
        {
            Node<T>? next = current.Next;

            while (next != null)
            {
                if (comparator.Compare(current.Date, next.Date) < 0)
                {
                    T temporary = current.Date;
                    current.Date = next.Date;
                    next.Date = temporary;
                }

                next = next.Next;
            }

            current = current.Next;
        }
    }



    public void ShowModas()
    {
        if (First == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        List<T> modas = new List<T>();
        int highFrequency = 0;

        Node<T>? current = First;

        while (current != null)
        {
            int frequency = 0;
            Node<T>? search = First;

            while (search != null)
            {
                if (comparator.Compare(current.Date, search.Date) == 0)
                    frequency++;

                search = search.Next;
            }

            if (frequency > highFrequency)
            {
                highFrequency = frequency;
                modas.Clear();
                modas.Add(current.Date);
            }
            else if (frequency == highFrequency)
            {
                bool itexists = false;

                foreach (T moda in modas)
                {
                    if (comparator.Compare(moda, current.Date) == 0)
                    {
                        itexists = true;
                        break;
                    }
                }

                if (!itexists)
                    modas.Add(current.Date);
            }

            current = current.Next;
        }

        Console.WriteLine("Moda(s): " + string.Join(", ", modas));
        Console.WriteLine("Frecuencia: " + highFrequency);
    }


    public void ShowGraph()
    {
        if (First == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        List<T> processed = new List<T>();

        Node<T>? current = First;

        while (current != null)
        {
            bool Alreadyprocessed = false;

            foreach (T date in processed)
            {
                if (comparator.Compare(date, current.Date) == 0)
                {
                    Alreadyprocessed = true;
                    break;
                }
            }

            if (!Alreadyprocessed)
            {
                int frequency = 0;
                Node<T>? search = First;

                while (search != null)
                {
                    if (comparator.Compare(current.Date, search.Date) == 0)
                        frequency++;

                    search = search.Next;
                }

                Console.WriteLine(
                    $"{current.Date} {new string('*', frequency)}"
                );

                processed.Add(current.Date);
            }

            current = current.Next;
        }
    }

    public bool ItExists(T date)
    {
        Node<T>? current = First;

        while (current != null)
        {
            if (comparator.Compare(current.Date, date) == 0)
                return true;

            current = current.Next;
        }

        return false;
    }

    public bool RemoveOneOccurrence(T dato)
    {
        Node<T>? current = First;

        while (current != null)
        {
            if (comparator.Compare(current.Date, dato) == 0)
            {
                if (current.Forme != null)
                    current.Forme.Next = current.Next;
                else
                    First = current.Next;

                if (current.Next != null)
                    current.Next.Forme = current.Forme;
                else
                    Last = current.Forme;

                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public int RemoveAllOccurrences(T date)
    {
        int eliminated = 0;

        Node<T>? current = First;

        while (current != null)
        {
            Node<T>? next = current.Next;

            if (comparator.Compare(current.Date, date) == 0)
            {
                if (current.Forme != null)
                    current.Forme.Next = current.Next;
                else
                    First = current.Next;

                if (current.Next != null)
                    current.Next.Forme = current.Forme;
                else
                    Last = current.Forme;

                eliminated++;
            }

            current = next;
        }

        return eliminated;
    }

}
