using UnityEngine;
using System.Collections;

public class S_block : ATetrimino
{

    new public void Start()
    {
        this.blocks = new int[3, 3];
        base.Start();
    }

    override public void set_form(int form)
    {
        if (form == 0)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (i == 0)
                        this.blocks[i, j] = 0;
                    else if (i == 2 && j != 0)
                        this.blocks[i, j] = 1;
                    else if (i == 1 && j != 2)
                        this.blocks[i, j] = 1;
                    else
                        this.blocks[i, j] = 0;
                }
            }
        }
        else if (form == 1)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (j == 0)
                        this.blocks[i, j] = 0;
                    else if (i != 2 && j == 2)
                        this.blocks[i, j] = 1;
                    else if (i != 0 && j == 1)
                        this.blocks[i, j] = 1;
                    else
                        this.blocks[i, j] = 0;
                }
            }
        }
        else if (form == 2)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (i == 2)
                        this.blocks[i, j] = 0;
                    else if (i == 1 && j != 0)
                        this.blocks[i, j] = 1;
                    else if (i == 0 && j != 2)
                        this.blocks[i, j] = 1;
                    else
                        this.blocks[i, j] = 0;
                }
            }
        }
        else if (form == 3)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (j == 2)
                        this.blocks[i, j] = 0;
                    else if (i != 2 && j == 1)
                        this.blocks[i, j] = 1;
                    else if (i != 0 && j == 0)
                        this.blocks[i, j] = 1;
                    else
                        this.blocks[i, j] = 0;
                }
            }

        }
    }
}