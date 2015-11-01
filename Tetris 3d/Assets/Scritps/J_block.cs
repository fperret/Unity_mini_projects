using UnityEngine;
using System.Collections;

public class J_block : ATetrimino
{
    new public void Start()
    {
        this.blocks = new int[3, 3, 3];
        this.tetrimino_id = 1;
        base.Start();
    }

    override public void set_form(int form, int face)
    {
        if (form == 0)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (i == 2)
                        this.blocks[i, j, 0] = 0;
                    else if (i == 0)
                        this.blocks[i, j, 0] = 1;
                    else if (j == 0)
                        this.blocks[i, j, 0] = 1;
                    else
                        this.blocks[i, j, 0] = 0;
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 2;
        }
        else if (form == 1)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (j == 1)
                        this.blocks[i, j, 0] = 1;
                    else if (i == 2 && j == 2)
                        this.blocks[i, j, 0] = 1;
                    else
                        this.blocks[i, j, 0] = 0;
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 3;
        }
        else if (form == 2)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (i == 2)
                        this.blocks[i, j, 0] = 0;
                    else if (i == 1)
                        this.blocks[i, j, 0] = 1;
                    else if (j == 2)
                        this.blocks[i, j, 0] = 1;
                    else
                        this.blocks[i, j, 0] = 0;
                }
            }
            this.index_leftmost = 1;
            this.index_rightmost = 0;
        }
        else if (form == 3)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (j == 1)
                        this.blocks[i, j, 0] = 1;
                    else if (i == 0 && j == 0)
                        this.blocks[i, j, 0] = 1;
                    else
                        this.blocks[i, j, 0] = 0;
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 1;
        }
    }

}