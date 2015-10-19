using UnityEngine;
using System.Collections;

abstract public class ATetrimino : MonoBehaviour
{
    public int[,] blocks;
    // 0 = lowest children
    public GameObject[] children_blocks;
    protected int index_leftmost;
    protected int index_rightmost;
    public int           current_form;

    public abstract void set_form(int form);

    private void build_form()
    {
        int k = 0;
        for (int i = 0; i < blocks.GetLength(0); ++i)
        {
            for (int j = 0; j < blocks.GetLength(1); ++j)
            {
                if (blocks[i, j] == 1)
                {
                    this.children_blocks[k].transform.position = new Vector3(this.transform.position.x + j, this.transform.position.y + i, 0);
                    k++;
                }
            }
        }
    }

    public void rotate()
    {
        this.current_form += 1;
        if (this.current_form == 4)
            this.current_form = 0;
        this.set_form(this.current_form);
        this.build_form();
    }

    public void fall()
    {
        if (this.children_blocks[0].transform.position.y > 0)
            this.transform.position += Vector3.down;
    }

    public void Start()
    {
        InvokeRepeating("fall", 1f, 1f);
        this.current_form = 0;
        this.set_form(0);
        Grid_manager.instance.current = this;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.children_blocks[this.index_rightmost].transform.position.x < 12)
                this.transform.position += Vector3.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.children_blocks[this.index_leftmost].transform.position.x > 0)
                this.transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rotate();
        }
    }
}
