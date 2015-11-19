using UnityEngine;
using System.Collections;

public class T_block : ATetrimino
{
    new public void Start()
    {
        this.blocks = new int[3, 3, 3];
        this.tetrimino_id = 5;
        base.Start();
    }

    public void set_front(int form)
    {
        switch (form)
        {
            case 0:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (i == 2)
                                this.blocks[i, j, k] = 0;
                            else if (i == 0 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else if (j == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 0;
                this.index_rightmost = 2;
                break;

            case 1:
                for (int i  = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (j == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else if (i == 1 && j == 2 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 1;
                this.index_rightmost = 2;
                break;

            case 2:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (i == 2)
                                this.blocks[i, j, k] = 0;
                            else if (i == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else if (j == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 1;
                this.index_rightmost = 3;
                break;

            case 3:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (j == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else if (i == 1 && j == 0 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 1;
                this.index_rightmost = 2;
                break;

            default:
                break;
        }
    }

    public void set_left(int form)
    {
        switch (form)
        {
            case 0:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (i == 2)
                                this.blocks[i, j, k] = 0;
                            else if (i == 0 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else if (k == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 2;
                this.index_rightmost = 0;
                break;

            case 1:
                for (int i  = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (k == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else if (i == 1 && k == 0 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 2;
                this.index_rightmost = 1;
                break;

            case 2:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (i == 2)
                                this.blocks[i, j, k] = 0;
                            else if (i == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else if (k == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 3;
                this.index_rightmost = 1;
                break;

            case 3:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (k == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else if (i == 1 && k == 2 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 2;
                this.index_rightmost = 1;
                break;

            default:
                break;
        }
    }

    public void set_back(int form)
    {
        switch (form)
        {
            case 0:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (i == 2)
                                this.blocks[i, j, k] = 0;
                            else if (i == 0 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else if (j == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 2;
                this.index_rightmost = 0;
                break;

            case 1:
                for (int i  = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (j == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else if (i == 1 && j == 0 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 2;
                this.index_rightmost = 1;
                break;

            case 2:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (i == 2)
                                this.blocks[i, j, k] = 0;
                            else if (i == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else if (j == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 3;
                this.index_rightmost = 1;
                break;

            case 3:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (j == 1 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else if (i == 1 && j == 2 && k == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 2;
                this.index_rightmost = 1;
                break;

            default:
                break;
        }
    }

    public void set_right(int form)
    {
        switch (form)
        {
            case 0:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (i == 2)
                                this.blocks[i, j, k] = 0;
                            else if (i == 0 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else if (k == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 0;
                this.index_rightmost = 2;
                break;

            case 1:
                for (int i  = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (k == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else if (i == 1 && k == 2 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 1;
                this.index_rightmost = 2;
                break;

            case 2:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (i == 2)
                                this.blocks[i, j, k] = 0;
                            else if (i == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else if (k == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 1;
                this.index_rightmost = 3;
                break;

            case 3:
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            if (k == 1 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else if (i == 1 && k == 0 && j == 0)
                                this.blocks[i, j, k] = 1;
                            else
                                this.blocks[i, j, k] = 0;
                        }
                    }
                }
                this.index_leftmost = 1;
                this.index_rightmost = 2;
                break;

            default:
                break;
        }

    }

    override public void set_form(int form, int face)
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