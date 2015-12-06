using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_manager : MonoBehaviour
{
    public static Game_manager instance;
    public GameObject[] tetriminos = new GameObject[7];
    public GameObject[] incoming_tetriminos = new GameObject[4];
    public GameObject stored;
    public Text text_lines;
    public Text text_level;
    public Text text_score;
    public int level;
    public bool pause;
    public int storage;
    public int current_face;

    private int[] incoming_id = new int[4];
    private int lines;
    private int score;
    private IntShuffleBag shuffle_bag = new IntShuffleBag(7);

    void Awake()
    {
        instance = this;
        for (int i = 0; i < 7; ++i)
            this.shuffle_bag.Add(i, 1);
        for (int k = 0; k < 4; ++k)
        {
            incoming_id[k] = this.shuffle_bag.Next();
        }
    }

	// Use this for initialization
	void Start ()
    {
        this.lines = 0;
        this.score = 0;
        this.pause = false;
        this.storage = -1;
        this.current_face = Constants.FRONT;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pause)
            {
                Time.timeScale = 0;
                this.pause = true;
            }
            else
            {
                Time.timeScale = 1;
                this.pause = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.change_face();
        }
	}

    private void change_face()
    {
        if (this.current_face == Constants.RIGHT)
            this.current_face = Constants.FRONT;
        else
            this.current_face++;
    }

    public void update_score(int add)
    {
        this.score += add * (this.level + 1);
        this.text_score.text = "Score : " + this.score.ToString();
    }

    public void update_lines(int add)
    {
        this.lines += add;
        this.level = (this.lines / 10);
        this.text_lines.text = "Lines : " + this.lines.ToString();
        this.text_level.text = "Level : " + this.level.ToString();
    }

    public void give_new_tetrimino()
    {
        Instantiate(this.tetriminos[incoming_id[0]], new Vector3(5, 23, 0), Quaternion.identity);
        for (int k = 0; k < 3; ++k)
        {
            incoming_id[k] = incoming_id[k + 1];
            Destroy(incoming_tetriminos[k]);
            incoming_tetriminos[k] = (GameObject) Instantiate(this.tetriminos[incoming_id[k + 1]].GetComponent<ATetrimino>().preview, incoming_tetriminos[k].transform.position, Quaternion.identity);
        }
        incoming_id[3] = this.shuffle_bag.Next();
        Destroy(incoming_tetriminos[3]);
        incoming_tetriminos[3] = (GameObject) Instantiate(this.tetriminos[incoming_id[3]].GetComponent<ATetrimino>().preview, incoming_tetriminos[3].transform.position, Quaternion.identity);
    }

    public void trade_from_storage(int id)
    {
        if (this.storage == -1)
        {
            this.give_new_tetrimino();
        }
        else
        {
            GameObject new_tetrimino = (GameObject)Instantiate(this.tetriminos[this.storage], new Vector3(5, 23, 0), Quaternion.identity);
            new_tetrimino.GetComponent<ATetrimino>().from_storage = true;
            Destroy(this.stored);
        }
        this.storage = id;
        this.stored = (GameObject)Instantiate(this.tetriminos[id].GetComponent<ATetrimino>().preview, this.stored.transform.position, Quaternion.identity);
    }

    public void game_over()
    {
        Time.timeScale = 0;
    }
}
