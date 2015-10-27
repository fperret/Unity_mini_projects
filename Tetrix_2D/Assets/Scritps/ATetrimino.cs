using UnityEngine;
using System.Collections;

abstract public class ATetrimino : MonoBehaviour
{
    public int[,] blocks;
    // 0 = lowest children
    public GameObject[] children_blocks;
    public GameObject preview;
    protected int index_leftmost;
    protected int index_rightmost;

    public int tetrimino_id;
    public int current_form;
    public bool from_storage;
    // Passer par un script différent pour les input et le set disable ?
    private bool is_controlled;
    private float time_call;

    public abstract void set_form(int form);

    private void build_form()
    {
        int k = 0;
        Transform[] preview_blocks = this.preview.GetComponentsInChildren<Transform>();
        for (int i = 0; i < blocks.GetLength(0); ++i)
        {
            for (int j = 0; j < blocks.GetLength(1); ++j)
            {
                if (blocks[i, j] == 1)
                {
                    this.children_blocks[k].transform.position = new Vector3(this.transform.position.x + j, this.transform.position.y + i, 0);
                    preview_blocks[k + 1].localPosition = this.children_blocks[k].transform.localPosition;
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
        this.set_form(0);
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

    public void Update()
    {
        if (this.is_controlled && !Game_manager.instance.pause)
        {
            this.time_call += Time.deltaTime;
            if (this.time_call >= 0.08f)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    if (this.children_blocks[this.index_rightmost].transform.position.x < 12 && Grid_manager.instance.is_right_free())
                        this.transform.position += Vector3.right;
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    if (this.children_blocks[this.index_leftmost].transform.position.x > 0 && Grid_manager.instance.is_left_free())
                        this.transform.position += Vector3.left;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    this.fall();
                }
                this.time_call = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.rotate();
            }
            if  (Input.GetKeyDown(KeyCode.Z))
            {
                this.instant_drop();
            }
            this.place_preview();
            if (Input.GetKeyDown(KeyCode.Return) && !this.from_storage)
            {
                Game_manager.instance.trade_from_storage(this.tetrimino_id);
                Destroy(this.preview);
                Destroy(this.gameObject);
            }
        }
    }
}
