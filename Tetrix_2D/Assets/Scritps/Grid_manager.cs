using UnityEngine;
using System.Collections;

public class Grid_manager : MonoBehaviour {

    public int  [,]grid = new int[22, 13];
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
                this.grid[i, j] = 0;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < 22; ++i)
        {
            string my_debug = "";
            for (int j = 0; j < 13; ++j)
            {
                if (this.grid[i, j] == 0)
                {
                 /*   if (this.is_current_here(i, j))
                    {
                        this.grid[i, j] = 2;
                    }
                    else
                        this.grid[i, j] = 0;*/
                }
                my_debug += this.grid[i, j].ToString();
            }
            Debug.Log(my_debug);
        }
        Debug.Log("--------------------");
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
            this.grid[(int)this.current.children_blocks[k].transform.position.y, (int)this.current.children_blocks[k].transform.position.x] = this.current.tetrimino_id;
        }
    }
}
