using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_manager : MonoBehaviour
{
    public static Game_manager instance;
    public GameObject[] tetriminos;
    public Text text_lines;
    public Text text_level;
    public Text text_score;
    public int level;
    public bool pause;
    public int storage;

    private int lines;
    private int score;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        this.lines = 0;
        this.score = 0;
        this.pause = false;
        this.storage = -1;
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
        // Changer pour avoir une liste des prochains et prendre le plus au dessus
        Instantiate(this.tetriminos[(int)Random.Range(0, 7)], new Vector3(5, 23, 0), Quaternion.identity);
    }

    public void give_from_storage()
    {
        if (this.storage == -1)
            Instantiate(this.tetriminos[(int)Random.Range(0, 7)], new Vector3(5, 23, 0), Quaternion.identity);
        else
            Instantiate(this.tetriminos[this.storage - 1], new Vector3(5, 23, 0), Quaternion.identity);
    }

    public void game_over()
    {
        Time.timeScale = 0;
    }
}
