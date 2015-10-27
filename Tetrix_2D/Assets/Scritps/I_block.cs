using UnityEngine;
using System.Collections;

public class I_block : ATetrimino
{
    new public void Start()
    {
        this.blocks = new int[4, 4];
        this.tetrimino_id = 0;
        base.Start();
    }

    override public void set_form(int form)
    {
        if (form == 0 || form == 2)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (i == 1)
                        this.blocks[i, j] = 1;
                    else
                        this.blocks[i, j] = 0;
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 3;
        }
        else if (form == 1)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (j == 2)
                        this.blocks[i, j] = 1;
                    else
                        this.blocks[i, j] = 0;
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 0;
        }
        else if (form == 3)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (j == 1)
                        this.blocks[i, j] = 1;
                    else
                        this.blocks[i, j] = 0;
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 0;
        }
    }

}
