using UnityEngine;
using System.Collections;

public class Grid_manager : MonoBehaviour {

    public GameObject  [,]grid = new GameObject[22, 13];
    public static Grid_manager instance;
    public ATetrimino current;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 22; ++i)
        {
            for (int j = 0; j < 13; ++j)
            {
                this.grid[i, j] = null;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
                 /*   if (this.is_current_here(i, j))
                    {
                        this.grid[i, j] = 2;
                    }
                    else
                        this.grid[i, j] = 0;*/
	}

    public bool can_move_down()
    {
        for (int k = 0; k < this.current.children_blocks.GetLength(0); ++k)
        {
            int i = (int)this.current.children_blocks[k].transform.position.y;
            int j = (int)this.current.children_blocks[k].transform.position.x;
            if (i <= 0 || this.grid[i - 1, j] != null)
                return (false);
        }
        return (true);
    }

    public bool is_right_free()
    {
        for (int k = 0; k < this.current.children_blocks.GetLength(0); ++k)
        {
            if (this.grid[(int)this.current.children_blocks[k].transform.position.y, (int)this.current.children_blocks[k].transform.position.x + 1] != null)
                return (false);
        }
        return (true);
    }

    public bool is_left_free()
    {
        for (int k = 0; k < this.current.children_blocks.GetLength(0); ++k)
        {
            if (this.grid[(int)this.current.children_blocks[k].transform.position.y, (int)this.current.children_blocks[k].transform.position.x - 1] != null)
                return (false);
        }
        return (true);
    }

    public bool is_position_possible()
    {
        for (int i = 0; i < this.current.blocks.GetLength(0); ++i)
        {
            for (int j = 0; j < this.current.blocks.GetLength(1); ++j)
            {
                if (this.current.blocks[i, j] == 1)
                {
                    int child_y = (int)this.current.transform.position.y + i;
                    int child_x = (int)this.current.transform.position.x + j;
                    if (child_y >= 0 && child_x >= 0 && child_x <= 12)
                    {
                        if (this.grid[child_y, child_x] != null)
                            return (false);
                    }
                }
            }
        }
        return (true);
    }

    bool is_current_here(int i, int j)
    {
        for (int k = 0; k < this.current.children_blocks.GetLength(0); ++k)
        {
            if (this.current.children_blocks[k].transform.position.y == i
                && this.current.children_blocks[k].transform.position.x == j)
                return (true);
        }
        return (false);
    }

    public void update_new_drop()
    {
        for (int k = 0; k < this.current.children_blocks.GetLength(0); ++k)
        {
            this.grid[(int)this.current.children_blocks[k].transform.position.y, (int)this.current.children_blocks[k].transform.position.x] = this.current.children_blocks[k];
        }
    }
}
