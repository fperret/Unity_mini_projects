using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid_manager : MonoBehaviour {

    public GameObject[,,] grid = new GameObject[25, 13, 13];
    public static Grid_manager instance;
    public ATetrimino current;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 25; ++i)
        {
            for (int j = 0; j < 13; ++j)
            {
                for (int k = 0; k < 13; ++k)
                    this.grid[i, j, k] = null;
            }
        }
        Game_manager.instance.give_new_tetrimino();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool can_move_down()
    {
        // Transformer en foreach ?
        for (int e = 0; e < this.current.children_blocks.GetLength(0); ++e)
        {
            int i = (int)this.current.children_blocks[e].transform.position.y;
            int j = (int)this.current.children_blocks[e].transform.position.x;
            int k = (int)this.current.children_blocks[e].transform.position.z;
            if (i <= 0 || i <= 24 && this.grid[i - 1, j, k] != null)
                return (false);
        }
        return (true);
    }

    public bool can_move_down(GameObject game_object)
    {
        Transform[] blocks = game_object.GetComponentsInChildren<Transform>();
        // Transformer en foreach ?
        for (int e = 1; e < blocks.GetLength(0); ++e)
        {
            int i = (int)blocks[e].position.y;
            if (i <= 0 || (i <= 23 && this.grid[i - 1,
                                                (int)blocks[e].position.x,
                                                (int)blocks[e].position.z] != null))
                return (false);
        }
        return (true);
    }

    public bool is_right_free()
    {
        // Transformer en foreach ?
        for (int e = 0; e < this.current.children_blocks.GetLength(0); ++e)
        {
            int i = (int)this.current.children_blocks[e].transform.position.y;
            if (i <= 23 && this.grid[(int)this.current.children_blocks[e].transform.position.y,
                                     (int)this.current.children_blocks[e].transform.position.x + 1,
                                     (int)this.current.children_blocks[e].transform.position.z] != null)
                return (false);
        }
        return (true);
    }

    public bool is_left_free()
    {
        // Transformer en foreach ?
        for (int e = 0; e < this.current.children_blocks.GetLength(0); ++e)
        {
            int i = (int)this.current.children_blocks[e].transform.position.y;
            if (i <= 23 && this.grid[i,
                                    (int)this.current.children_blocks[e].transform.position.x - 1,
                                    (int)this.current.children_blocks[e].transform.position.z] != null)
                return (false);
        }
        return (true);
    }

    public bool is_front_free()
    {
        foreach (GameObject block in this.current.children_blocks)
        {
            int i = (int)block.transform.position.y;
            if (i <= 23 && this.grid[i,
                                    (int)block.transform.position.x,
                                    (int)block.transform.position.z - 1] != null)
                return (false);
        }
        return (true);
    }

    public bool is_back_free()
    {
        foreach (GameObject block in this.current.children_blocks)
        {
            int i = (int)block.transform.position.y;
            if (i <= 23 && this.grid[i,
                                    (int)block.transform.position.x,
                                    (int)block.transform.position.z + 1] != null)
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
                for (int k = 0; k < this.current.blocks.GetLength(2); ++k)
                {
                    if (this.current.blocks[i, j, k] == 1)
                    {
                        int child_y = (int)this.current.transform.position.y + i;
                        int child_x = (int)this.current.transform.position.x + j;
                        int child_z = (int)this.current.transform.position.z + k;
                        if (child_y >= 0 && child_y <= 24 && child_x >= 0 && child_x <= 12)
                        {
                            if (this.grid[child_y, child_x, child_z] != null)
                                return (false);
                        }
                    }
                }
            }
        }
        return (true);
    }

    bool is_current_here(int i, int j)
    {
        // Transformer en foreach ?
        for (int e = 0; e < this.current.children_blocks.GetLength(0); ++e)
        {
            if (this.current.children_blocks[e].transform.position.y == i
                && this.current.children_blocks[e].transform.position.x == j)
                return (true);
        }
        return (false);
    }

    private bool check_row_full(int i, int k)
    {
        for (int j = 0; j < this.grid.GetLength(1); ++j)
        {
            if (this.grid[i, j, k] == null)
                return (false);
        }
        return (true);
    }

    public void update_new_drop(bool instant_drop)
    {
        // Transformer en foreach ?
        for (int e = 0; e < this.current.children_blocks.GetLength(0); ++e)
        {
            int check_i = (int)this.current.children_blocks[e].transform.position.y;
            if (check_i > 23)
            {
                Game_manager.instance.game_over();
                return;
            }
            this.grid[check_i, (int)this.current.children_blocks[e].transform.position.x, (int)this.current.children_blocks[e].transform.position.z] = this.current.children_blocks[e];
        }

        // Check row
        // Transformer en foreach ?
        for (int e = 0; e < this.current.children_blocks.GetLength(0); ++e)
        {
            int row = (int)this.current.children_blocks[e].transform.position.y;
            int depth = (int)this.current.children_blocks[e].transform.position.z;
            if (this.check_row_full(row, depth))
            {
                for (int j = 0; j < this.grid.GetLength(1); ++j)
                {
                    Destroy(this.grid[row, j, depth]);
                }
                for (int i = row + 1; i < this.grid.GetLength(0); ++i)
                {
                    for (int j = 0; j < this.grid.GetLength(1); ++j)
                    {
                        for (int k = 0; k < this.grid.GetLength(2); ++k)
                        {
                            if (this.grid[i, j, k] != null)
                            {
                                this.grid[i, j, k].transform.position += Vector3.down;
                            }
                            this.grid[i - 1, j, k] = this.grid[i, j, k];
                        }
                    }
                }
                Game_manager.instance.update_lines(1);
                Game_manager.instance.update_score(50);
            }
        }
        if (instant_drop)
            Game_manager.instance.update_score(10);
        else
            Game_manager.instance.update_score(5);
        Game_manager.instance.give_new_tetrimino();
    }
}
