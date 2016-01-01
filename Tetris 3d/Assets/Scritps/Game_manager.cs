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
    public bool game_pause;
    private bool menu_pause;
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
        this.lines = 0;
        this.score = 0;
        this.game_pause = false;
        this.menu_pause = false;
        this.storage = -1;
        this.current_face = -1;
    }

	// Use this for initialization
	void Start ()
    {
	}

    // Update is called once per frame
    void Update()
    {
        if (!menu_pause)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (!game_pause)
                {
                    Time.timeScale = 0;
                    this.game_pause = true;
                }
                else
                {
                    Time.timeScale = 1;
                    this.game_pause = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.F) && !game_pause)
            {
                this.change_face();
            }
        }
	}

    private void change_face()
    {
        if (this.current_face == Constants.RIGHT)
            this.current_face = Constants.FRONT;
        else
            this.current_face++;
        // Passer directement par un attribut ?
        Grid_manager.instance.current.rotate_change_face(this.current_face);
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
        Vector3 spawn_position = new Vector3(0, 23, 0);

        if (this.current_face == Constants.RIGHT)
            this.current_face = Constants.FRONT;
        else
            this.current_face++;
        Grid_manager.instance.check_whole_face();
        if (this.current_face == Constants.FRONT || this.current_face == Constants.BACK)
        {
            spawn_position.x = 5;
            spawn_position.z = Random.Range(0, 13);
        }
        else
        {
            spawn_position.x = Random.Range(0, 13);
            spawn_position.z = 5;
        }
        Instantiate(this.tetriminos[incoming_id[0]], spawn_position, Quaternion.identity);
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

    public void exit_game()
    {
        PlayerPrefs_manager.instance.save_input_prefs();
        Application.Quit();
    }

    public void pause_from_menu(bool state)
    {
        menu_pause = state;
        game_pause = state;
    }
}
