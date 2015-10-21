using UnityEngine;
using System.Collections;

abstract public class ATetrimino : MonoBehaviour
{
    public int[,] blocks;
    // 0 = lowest children
    public GameObject[] children_blocks;
    protected int index_leftmost;
    protected int index_rightmost;

    public int tetrimino_id;
    public int current_form;
    // Passer par un script différent pour les input et le set disable ?
    private bool is_controlled;
    private float time_call;

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
        // Should move piece accordingly /!\ IMPORTANT
        if (!Grid_manager.instance.is_position_possible())
        {
            this.current_form -= 1;
            if (this.current_form == -1)
                this.current_form = 3;
            this.set_form(this.current_form);
        }
        this.build_form();
        if (this.children_blocks[this.index_leftmost].transform.position.x <= 0)
        {
            this.transform.position += new Vector3(-this.children_blocks[this.index_leftmost].transform.position.x, 0, 0);
        }
        else if (this.children_blocks[this.index_rightmost].transform.position.x >= 12)
        {
            this.transform.position += new Vector3(12 - this.children_blocks[this.index_rightmost].transform.position.x, 0, 0);
        }
        if (this.children_blocks[0].transform.position.y <= 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, 0, 0);
        }
    }

    public void fall()
    {
        if (Grid_manager.instance.can_move_down())
            this.transform.position += Vector3.down;
        // Desactiver le script ?
        else if (this.is_controlled)
        {
            this.is_controlled = false;
            Grid_manager.instance.update_new_drop();
        //    Game_manager.instance.give_new_tetrimino();
            CancelInvoke("fall");
        }

    }

    public void Start()
    {
        InvokeRepeating("fall", 1f, 1f);
        this.current_form = 0;
        this.set_form(0);
        this.is_controlled = true;
        this.time_call = 0;
        Grid_manager.instance.current = this;
    }

    public void Update()
    {
        this.time_call += Time.deltaTime;
        if (this.is_controlled)
        {
            if (this.time_call >= 0.08f)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (this.children_blocks[this.index_rightmost].transform.position.x < 12 && Grid_manager.instance.is_right_free())
                        this.transform.position += Vector3.right;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (this.children_blocks[this.index_leftmost].transform.position.x > 0 && Grid_manager.instance.is_left_free())
                        this.transform.position += Vector3.left;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    this.fall();
                }
                this.time_call = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.rotate();
            }
        }
    }
}
