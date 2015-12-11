using UnityEngine;
using System.Collections;

abstract public class ATetrimino : MonoBehaviour
{
    public int[,,] blocks;
    // 0 = lowest children
    public GameObject[] children_blocks;
    public GameObject preview;
    protected int index_leftmost;
    protected int index_rightmost;
    protected int index_frontmost;
    protected int index_backmost;

    public int tetrimino_id;
    public int current_form;
    public bool from_storage;
    private bool is_controlled;
    private float time_call;

    public abstract void set_form(int form, int face);

    private void build_form()
    {
        // Modification d'un axe qui ne devrait pas etre fait a ce moment la
        int e = 0;
        Transform[] preview_blocks = this.preview.GetComponentsInChildren<Transform>();
        for (int i = 0; i < blocks.GetLength(0); ++i)
        {
            for (int j = 0; j < blocks.GetLength(1); ++j)
            {
                for (int k = 0; k < blocks.GetLength(2); ++k)
                {
                    if (blocks[i, j, k] == 1)
                    {
                        this.children_blocks[e].transform.position = new Vector3(this.transform.position.x + j, this.transform.position.y + i, this.transform.position.z + k);
                        preview_blocks[e + 1].localPosition = this.children_blocks[e].transform.localPosition;
                        e++;
                    }
                }
            }
        }
    }

    public void rotate()
    {
        this.current_form += 1;
        if (this.current_form == 4)
            this.current_form = 0;
        this.set_form(this.current_form, Game_manager.instance.current_face);
        // Should move piece accordingly /!\ IMPORTANT
        if (!Grid_manager.instance.is_position_possible())
        {
            this.current_form -= 1;
            if (this.current_form == -1)
                this.current_form = 3;
            this.set_form(this.current_form, Game_manager.instance.current_face);
        }
        this.build_form();
        switch (Game_manager.instance.current_face)
        {
            case Constants.FRONT:
                if (this.children_blocks[this.index_leftmost].transform.position.x <= 0)
                {
                    this.transform.position += new Vector3(-this.children_blocks[this.index_leftmost].transform.position.x, 0, 0);
                }
                else if (this.children_blocks[this.index_rightmost].transform.position.x >= 12)
                {
                    this.transform.position += new Vector3(12 - this.children_blocks[this.index_rightmost].transform.position.x, 0, 0);
                }
                break;

            case Constants.LEFT:
                if (this.children_blocks[this.index_leftmost].transform.position.z >= 12)
                {
                    this.transform.position += new Vector3(0, 0, 12 - this.children_blocks[this.index_leftmost].transform.position.z);
                }
                else if (this.children_blocks[this.index_rightmost].transform.position.z <= 0)
                {
                    this.transform.position += new Vector3(0, 0, -this.children_blocks[this.index_rightmost].transform.position.z);
                }
                break;

            case Constants.BACK:
                if (this.children_blocks[this.index_leftmost].transform.position.x >= 12)
                {
                    this.transform.position += new Vector3(12 - this.children_blocks[this.index_leftmost].transform.position.x, 0, 0);
                }
                else if (this.children_blocks[this.index_rightmost].transform.position.x <= 0)
                {
                    this.transform.position += new Vector3(-this.children_blocks[this.index_rightmost].transform.position.x, 0, 0);
                }
                break;

            case Constants.RIGHT:
                if (this.children_blocks[this.index_leftmost].transform.position.z <= 0)
                {
                    this.transform.position += new Vector3(0, 0, -this.children_blocks[this.index_leftmost].transform.position.z);
                }
                else if (this.children_blocks[this.index_rightmost].transform.position.z >= 12)
                {
                    this.transform.position += new Vector3(0, 0, 12 - this.children_blocks[this.index_rightmost].transform.position.z);
                }
                break;


        }
        if (this.children_blocks[0].transform.position.y <= 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        }
    }

    public void fall()
    {
        if (Grid_manager.instance.can_move_down())
            this.transform.position += Vector3.down;
        else if (this.is_controlled)
        {
            this.is_controlled = false;
            Destroy(this.preview);
            Grid_manager.instance.update_new_drop(false);
            CancelInvoke("fall");
        }
    }

    public void Awake()
    {
        this.from_storage = false;
    }

    public void Start()
    {
        float speed = 1f - ((float)Game_manager.instance.level / 10);
        if (speed < 0.1f)
            speed = 0.1f;
        InvokeRepeating("fall", speed, speed);
        this.current_form = 0;
        this.set_form(0, Game_manager.instance.current_face);
        this.is_controlled = true;
        this.time_call = 0;
        Grid_manager.instance.current = this;
        this.preview = (GameObject) Instantiate(this.preview, this.transform.position, Quaternion.identity);
    }

    private void place_preview()
    {
        this.preview.transform.position = this.transform.position;
        while (Grid_manager.instance.can_move_down(this.preview))
        {
            this.preview.transform.position += Vector3.down;
        }
    }

    private void instant_drop()
    {
        while (Grid_manager.instance.can_move_down())
        {
            this.transform.position += Vector3.down;
        }
        this.is_controlled = false;
        Destroy(this.preview);
        Grid_manager.instance.update_new_drop(true);
        CancelInvoke("fall");
    }

    private void move_left()
    {
        switch (Game_manager.instance.current_face)
        {
            case Constants.FRONT:
                if (this.children_blocks[this.index_leftmost].transform.position.x > 0 && Grid_manager.instance.is_left_free())
                    this.transform.position += Vector3.left;
                break;
            case Constants.LEFT:
                if (this.children_blocks[this.index_leftmost].transform.position.z < 12 && Grid_manager.instance.is_back_free())
                    this.transform.position += Vector3.forward;
                break;
            case Constants.BACK:
                if (this.children_blocks[this.index_leftmost].transform.position.x < 12 && Grid_manager.instance.is_right_free())
                    this.transform.position += Vector3.right;
                break;
            case Constants.RIGHT:
                if (this.children_blocks[this.index_leftmost].transform.position.z > 0 && Grid_manager.instance.is_front_free())
                    this.transform.position += Vector3.back;
                break;
        }
    }

    private void move_right()
    {
        switch (Game_manager.instance.current_face)
        {
            case Constants.FRONT:
                if (this.children_blocks[this.index_rightmost].transform.position.x < 12 && Grid_manager.instance.is_right_free())
                    this.transform.position += Vector3.right;
                break;
            case Constants.LEFT:
                if (this.children_blocks[this.index_rightmost].transform.position.z > 0 && Grid_manager.instance.is_front_free())
                    this.transform.position += Vector3.back;
                break;
            case Constants.BACK:
                if (this.children_blocks[this.index_rightmost].transform.position.x > 0 && Grid_manager.instance.is_left_free())
                    this.transform.position += Vector3.left;
                break;
            case Constants.RIGHT:
                if (this.children_blocks[this.index_rightmost].transform.position.z < 12 && Grid_manager.instance.is_back_free())
                    this.transform.position += Vector3.forward;
                break;
        }
    }

    public void Update()
    {
        if (this.is_controlled && !Game_manager.instance.game_pause)
        {
            this.time_call += Time.deltaTime;
            if (Input.GetKeyDown(Inputs_manager.instance.move_right_key))
                move_right();
            else if (Input.GetKeyDown(Inputs_manager.instance.move_left_key))
                move_left();
            else if (this.time_call >= 0.08f)
            {
                if (Input.GetKey(Inputs_manager.instance.move_right_key))
                    move_right();
                else if (Input.GetKey(Inputs_manager.instance.move_left_key))
                    move_left();
                else if (Input.GetKey(KeyCode.S))
                {
                    // Changer index pour block le plus en avant
                    if (this.children_blocks[0].transform.position.z > 0 && Grid_manager.instance.is_front_free())
                        this.transform.position += Vector3.back;
                }
                else if (Input.GetKey(KeyCode.Z))
                {
                    // Changer index pour block le plus en arriere
                    if (this.children_blocks[0].transform.position.z < 12 && Grid_manager.instance.is_back_free())
                        this.transform.position += Vector3.forward;
                }
                else if (Input.GetKey(Inputs_manager.instance.fall_key))
                {
                    this.fall();
                }
                this.time_call = 0;
            }
            if (Input.GetKeyDown(Inputs_manager.instance.rotate_key))
            {
                this.rotate();
            }
            if  (Input.GetKeyDown(Inputs_manager.instance.drop_key))
            {
                this.instant_drop();
            }
            this.place_preview();
            if (Input.GetKeyDown(Inputs_manager.instance.store_key) && !this.from_storage)
            {
                Game_manager.instance.trade_from_storage(this.tetrimino_id);
                Destroy(this.preview);
                Destroy(this.gameObject);
            }
        }
    }
}
