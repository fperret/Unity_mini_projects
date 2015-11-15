using UnityEngine;
using System.Collections;
using System;

public class I_block : ATetrimino
{
    new public void Start()
    {
        this.blocks = new int[4, 4, 4];
        this.tetrimino_id = 0;
        base.Start();
    }

    public void set_front(int form)
    {
        if (form == 0 || form == 2)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        if (i == 1 && k == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
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
                    for (int k = 0; k < 4; ++k)
                    {
                        if (j == 2 && k == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
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
                    for (int k = 0; k < 4; ++k)
                    {
                        if (j == 1 && k == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 0;
        }
    }

    public void set_left(int form)
    {
        if (form == 0 || form == 2)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        if (i == 1 && j == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
                }
            }
            this.index_leftmost = 3;
            this.index_rightmost = 0;
        }
        else if (form == 1)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        if (k == 1 && j == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
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
                    for (int k = 0; k < 4; ++k)
                    {
                        if (k == 2 && j == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 0;
        }
    }

    public void set_back(int form)
    {
        if (form == 0 || form == 2)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        if (i == 1 && k == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
                }
            }
            this.index_leftmost = 3;
            this.index_rightmost = 0;
        }
        else if (form == 1)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        if (j == 1 && k == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
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
                    for (int k = 0; k < 4; ++k)
                    {
                        if (j == 2 && k == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 0;
        }
    }

    public void set_right(int form)
    {
        if (form == 0 || form == 2)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        if (i == 1 && j == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
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
                    for (int k = 0; k < 4; ++k)
                    {
                        if (k == 2 && j == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
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
                    for (int k = 0; k < 4; ++k)
                    {
                        if (k == 1 && j == 0)
                            this.blocks[i, j, k] = 1;
                        else
                            this.blocks[i, j, k] = 0;
                    }
                }
            }
            this.index_leftmost = 0;
            this.index_rightmost = 0;
        }
    }

    public override void set_form(int form, int face)
    {
        switch (face)
        {
            case Constants.FRONT:
                this.set_front(form);
                break;

            case Constants.LEFT:
                this.set_left(form);
                break;

            case Constants.BACK:
                this.set_back(form);
                break;

            case Constants.RIGHT:
                this.set_right(form);
                break;

            default:
                break;
        }
    }
}
