namespace Backend;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private Node<T>? First;
    private Node<T>? Last;

    public DoublyLinkedList()
    {
        First = null;
        Last = null;
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

        if (date.CompareTo(First.Date) <= 0)
        {
            New.Next = First;
            First.Forme = New;
            First = New;
            return;
        }

        if (date.CompareTo(Last!.Date) >= 0)
        {
            New.Forme = Last;
            Last.Next = New;
            Last = New;
            return;
        }

        Node<T> current = First;

        while (current != null && date.CompareTo(current.Date) > 0)
        {
            current = current.Next!;
        }

        New.Next = current;
        New.Forme = current!.Forme;

        current.Forme!.Next = New;
        current.Forme = New;
    }


    public void ShowNext()
    {
        Node<T>? current = First;

        if (current == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        while (current != null)
        {
            Console.Write(current.Date + " ");

            current = current.Next;
        }

        Console.WriteLine();
    }


    public void ShowBack()
    {
        Node<T>? current = Last;

        if (current == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

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
                if (current.Date.CompareTo(next.Date) < 0)
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

        int higherfrequency = 0;
        List<T> modas = new List<T>();

        Node<T>? current = First;

        while (current != null)
        {
            int frequency = 0;
            Node<T>? search = First;

            while (search != null)
            {
                if (current.Date.CompareTo(search.Date) == 0)
                    frequency++;

                search = search.Next;
            }

            if (frequency > higherfrequency)
            {
                higherfrequency = frequency;
                modas.Clear();
                modas.Add(current.Date);
            }
            else if (frequency == higherfrequency &&
                     !modas.Contains(current.Date))
            {
                modas.Add(current.Date);
            }

            current = current.Next;
        }

        Console.WriteLine("Moda(s): " + string.Join(", ", modas));
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
            if (!processed.Contains(current.Date))
            {
                int frequency = 0;
                Node<T>? search = First;

                while (search != null)
                {
                    if (current.Date.CompareTo(search.Date) == 0)
                        frequency++;

                    search = search.Next;
                }

                Console.WriteLine(current.Date + " " +
                                  new string('*', frequency));

                processed.Add(current.Date);
            }

            current = current.Next;
        }
    }

    public bool ItExists(T dato)
    {
        Node<T>? current = First;

        while (current != null)
        {
            if (current.Date.CompareTo(dato) == 0)
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
            if (current.Date.CompareTo(dato) == 0)
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

    public int RemoveAllOccurrences(T dato)
    {
        int eliminated = 0;

        Node<T>? current = First;

        while (current != null)
        {
            Node<T>? next = current.Next;

            if (current.Date.CompareTo(dato) == 0)
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
