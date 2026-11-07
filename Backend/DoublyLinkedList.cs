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


    public void Ad(T date)
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

        if (date.CompareTo(Last.Date) >= 0)
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


}
