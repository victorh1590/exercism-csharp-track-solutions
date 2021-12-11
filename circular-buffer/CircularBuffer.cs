using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>
{
    private object?[] Buffer;
    private int Begin { get; set; }
    private int End { get; set; }
    private int _capacity { get; init; }
    
    private bool Full { get; set; }

    private bool Empty { get; set; }

    public CircularBuffer(int capacity)
    {
        _capacity = capacity;
        Begin = 0;
        End = 0;
        // Buffer = new List<T?>(capacity);
        Buffer = new object?[capacity];
        for (int i = 0; i < capacity; i++)
        {
            Buffer[i] = null;
        }
        
        if (capacity != 0)
        {
            Empty = true;
            Full = false;
        }
        else
        {
            Empty = false;
            Full = true;
        }
    }

    private int CycleIncrement(int currentPosition) 
        => currentPosition + 1 < _capacity ? currentPosition + 1 : 0;
    
    // private bool BufferIsEmpty() => End == Begin;
    //
    // private bool BufferIsFull() => Math.Abs(End - Begin) == _capacity + 1;

    private void SetFullWhenWrite()
    {
        Empty = false;
        if (Begin == End) Full = true;
    }

    private void SetEmptyWhenRead()
    {
        Full = false;
        if (Begin == End && Buffer[End] == null) Empty = true;
    }
    
    public T Read()
    {
        if (!Empty)
        {
            var result = Buffer[Begin];
            Buffer[Begin] = null;
            Begin = CycleIncrement(Begin);
            SetEmptyWhenRead();
            return (T) result!;
        }
        throw new InvalidOperationException();
    }

    public void Write(T? value)
    {
        if (!Full)
        {
            Buffer[End] = value;
            End = CycleIncrement(End);
            SetFullWhenWrite();
            return;
        }
        throw new InvalidOperationException();
    }

    public void Overwrite(T? value)
    {
        if(!Full) Write(value);
        else
        {
            Buffer[Begin] = value;
            Begin = CycleIncrement(Begin);
        }
    }

    public void Clear()
    {
        if (!Empty)
        {
            Buffer[Begin] = null;
            Begin = CycleIncrement(Begin);
            SetEmptyWhenRead();
        }
    }
}