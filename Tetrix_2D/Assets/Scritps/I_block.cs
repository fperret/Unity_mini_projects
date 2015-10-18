using UnityEngine;
using System.Collections;

public class I_block : ATetrimino
{
    new public void Start()
    {
        this.blocks = new int[5, 5];
        base.Start();
    }

    override public void set_form(int form)
    {
        if (form == 0 || form == 2)
        {
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    if (j == 2)
                        this.blocks[i, j] = 1;
                    else
                        this.blocks[i, j] = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    if (i == 2)
                        this.blocks[i, j] = 1;
                    else
                        this.blocks[i, j] = 0;
                }
            }
        }
    }

}
