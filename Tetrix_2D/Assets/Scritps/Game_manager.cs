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
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void update_score(int add)
    {
        this.score += add;
        this.text_score.text = "Score : " + this.score.ToString();
    }

    public void update_lines(int add)
    {
        this.lines += add;
        this.text_lines.text = "Lines : " + this.lines.ToString();
        this.text_level.text = "Level : " + (this.lines / 10).ToString();
    }

    public void give_new_tetrimino()
    {
        // Changer pour avoir une liste des prochains et prendre le plus au dessus
        Instantiate(this.tetriminos[(int)Random.Range(0, 7)], new Vector3(5, 21, 0), Quaternion.identity);
    }
}
