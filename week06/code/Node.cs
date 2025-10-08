public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
            {
                Left = new Node(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
            {
                Right = new Node(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            if (Left is null)
            {
                return false;
            }
            else
            {
                return Left.Contains(value);
            }
        }
        else if (value > Data)
        {
            if (Right is null)
            {
                return false;
            }
            else
            {
                return Right.Contains(value);
            }
        }
        else
        {
            return false;
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        var leftSubtree = 0;
        var rightSubtree = 0;

        if (Left is not null)
        {
            leftSubtree = Left.GetHeight() + 1;
        }
        if (Right is not null)
        {
            rightSubtree = Right.GetHeight() + 1;
        }

        if (leftSubtree > rightSubtree)
        {
            return leftSubtree;
        }
        else if (leftSubtree < rightSubtree)
        {
            return rightSubtree;
        }
        else if (leftSubtree == rightSubtree && Left is not null && Right is not null)
        {
            return (leftSubtree + rightSubtree) / 2;
        }
        else
        {
            return 1;
        }
    }
}