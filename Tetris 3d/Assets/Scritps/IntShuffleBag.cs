using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntShuffleBag
{
    private List<int> data;

    private int current_elem;
    private int current_pos = -1;

    private int Capacity { get { return data.Capacity; } }
    private int Size { get { return data.Count; } }

    public IntShuffleBag(int capacity)
    {
        this.data = new List<int>(capacity);
    }

    public void Add(int elem, int amount)
    {
        for (int i = 0; i < amount; ++i)
            this.data.Add(elem);
        this.current_pos = this.Size - 1;
    }

    public int Next()
    {
        if (this.current_pos < 1)
        {
            this.current_pos = this.Size - 1;
            this.current_elem = this.data[0];
            return (this.current_elem);
        }

        int pos = Random.Range(0, this.current_pos);
        this.current_elem = this.data[pos];
        this.data[pos] = this.data[this.current_pos];
        this.data[this.current_pos] = this.current_elem;
        this.current_pos--;
        return (this.current_elem);
    }
}
