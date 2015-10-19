using UnityEngine;
using System.Collections;

public class O_block : ATetrimino
{
    new public void Start()
    {
        this.blocks = new int[2, 2];
        base.Start();
    }

    override public void set_form(int form)
    {
        this.blocks[0, 0] = 1;
        this.blocks[1, 0] = 1;
        this.blocks[0, 1] = 1;
        this.blocks[1, 1] = 1;
        this.index_leftmost = 0;
        this.index_rightmost = 1;
    }
}
