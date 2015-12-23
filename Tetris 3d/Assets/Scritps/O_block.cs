using UnityEngine;
using System.Collections;

public class O_block : ATetrimino
{
    new public void Start()
    {
        this.blocks = new int[2, 2, 2];
        this.tetrimino_id = 3;
        base.Start();
    }

    public void set_front()
    {
        this.blocks[0, 0, 0] = 1;
        this.blocks[1, 0, 0] = 1;
        this.blocks[0, 1, 0] = 1;
        this.blocks[1, 1, 0] = 1;
        this.index_leftmost = 0;
        this.index_rightmost = 1;
    }

    public void set_left()
    {
        this.blocks[0, 0, 0] = 1;
        this.blocks[1, 0, 0] = 1;
        this.blocks[0, 0, 1] = 1;
        this.blocks[1, 0, 1] = 1;
        this.index_leftmost = 1;
        this.index_rightmost = 0;
    }

    public void set_back()
    {
        this.blocks[0, 0, 0] = 1;
        this.blocks[1, 0, 0] = 1;
        this.blocks[0, 1, 0] = 1;
        this.blocks[1, 1, 0] = 1;
        this.index_leftmost = 1;
        this.index_rightmost = 0;
    }

    public void set_right()
    {
        this.blocks[0, 0, 0] = 1;
        this.blocks[1, 0, 0] = 1;
        this.blocks[0, 0, 1] = 1;
        this.blocks[1, 0, 1] = 1;
        this.index_leftmost = 0;
        this.index_rightmost = 1;
    }



    public override void set_form(int face)
    {
        for (int i = 0; i < 2; ++i)
        {
            for (int j = 0; j < 2; ++j)
            {
                for (int k = 0; k < 2; ++k)
                {
                    this.blocks[i, j, k] = 0;
                }
            }
        }

        switch (face)
        {
            case Constants.FRONT:
                this.set_front();
                break;

            case Constants.LEFT:
                this.set_left();
                break;

            case Constants.BACK:
                this.set_back();
                break;

            case Constants.RIGHT:
                this.set_right();
                break;

            default:
                break;
        }
    }
}
