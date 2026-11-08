namespace Backend;

public class DataComparator : IComparer<IComparable>
{
    public int Compare(IComparable? x, IComparable? y)
    {
        if (x == null && y == null)
            return 0;

        if (x == null)
            return -1;

        if (y == null)
            return 1;

        bool xIsNumber = x is int;
        bool yIsNumber = y is int;

        if (xIsNumber && yIsNumber)
        {
            return ((int)x).CompareTo((int)y);
        }

        if (xIsNumber)
            return -1;

        if (yIsNumber)
            return 1;

        return string.Compare(
            x.ToString(),
            y.ToString(),
            StringComparison.OrdinalIgnoreCase
        );
    }

}
