namespace Backend;

public class Node<T>
{
    public Node(T date)
    {
        Date = date;
        Next = null;
        Forme = null;
    }

    public T Date { get; set; }

    public Node<T>? Next { get; set; }

    public Node<T>? Forme { get; set; }

}
