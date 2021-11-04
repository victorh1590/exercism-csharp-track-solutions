#nullable enable
using System;

public class Deque<T>
{
    private Node<T> Head { get; }
    private Node<T> Tail { get; }

    public Deque()
    {
        Head = new Node<T>();
        Tail = new Node<T>(Head, null!);
        Head.NextNode = Tail;
    }

    public void Push(T value)
    {
        Node<T> newNode = new(value);
        if (Count() == 0)
        {
            Head.NextNode = newNode;
            Tail.LastNode = newNode;
            newNode.LastNode = Head;
            newNode.NextNode = Tail;
        }
        else
        {
            newNode.NextNode = Tail;
            newNode.LastNode = Tail.LastNode;
            Tail.LastNode.NextNode = newNode;
            Tail.LastNode = newNode;
        }
    }

    public T? Pop()
    {
        if (Count() == 0) return default;
        
        var removed = Tail.LastNode;
        removed.LastNode.NextNode = Tail;
        Tail.LastNode = removed.LastNode;
        return removed.Value;
    }

    public void Unshift(T value)
    {
        Node<T> newNode = new(value);
        if (Count() == 0)
        {
            Head.NextNode = newNode;
            Tail.LastNode = newNode;
            newNode.LastNode = Head;
            newNode.NextNode = Tail;
        }
        else
        {
            var second = Head.NextNode;
            newNode.NextNode = second;
            newNode.LastNode = Head;
            second.LastNode = newNode;
            Head.NextNode = newNode;
        }
    }

    public T? Shift()
    {
        if (Count() == 0) return default;
        
        var removed = Head.NextNode;
        removed.NextNode.LastNode = Head;
        Head.NextNode = removed.NextNode;
        return removed.Value;
    }

    public int Count()
    {
        Node<T> currentNode = Head.NextNode;
        int counter = 0;
        while (!currentNode.Equals(Tail))
        {
            currentNode = currentNode.NextNode;
            counter++;
        }
        return counter;
    }
}

public class Node<T>
{
    public T? Value { get; set; }
    public Node<T> LastNode { get; set; }
    public Node<T> NextNode { get; set; }

    public Node(T? value)
    {
        Value = value;
        LastNode = null!;
        NextNode = null!;
    }
    
    public Node(Node<T> lastNode, Node<T> nextNode)
    {
        Value = default;
        LastNode = lastNode;
        NextNode = nextNode;
    }
    
    public Node()
    {
        Value = default;
        LastNode = null!;
        NextNode = null!;
    }
}