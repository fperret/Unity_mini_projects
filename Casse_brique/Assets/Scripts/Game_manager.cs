using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game_manager : MonoBehaviour
{
    public List<Paddle> paddles;
    public Ball ball;
    public GameObject bonus_ball;
    public static Game_manager instance;
    public Text Lives_text;
    public Text Score_text;
    public GameObject Win_text;
    public GameObject Lose_text;
    public int lives;
    public int bricks;
    public int sticky_shot;
    public int free_ball;
    public int score;


    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        this.sticky_shot = 0;
        this.free_ball = 0;
        this.Lives_text.text = "Lives left : " + this.lives.ToString();
        this.score = 0;
        this.Score_text.text = this.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Paddle paddle_elem in paddles)
        {
            if (paddle_elem.transform.position.x >= 0 && paddle_elem.transform.position.x <= 30)
            {
                if (this.ball.paddle_stuck)
                    this.ball.paddle = paddle_elem;
                if (this.free_ball > 0 && (paddle_elem.has_ball == false))
                {
                    GameObject tmp = (GameObject)Instantiate(bonus_ball, paddle_elem.transform.position, Quaternion.identity);
                    tmp.GetComponent<Ball>().paddle = paddle_elem;
                    paddle_elem.has_ball = true;
                    this.free_ball--;
                }
            }
        }
        if (this.bricks == 0)
        {
            this.Win_text.SetActive(true);
            this.Win_text.transform.position = new Vector3(Random.Range(300, 1700), Random.Range(0, 1000));
            StartCoroutine("timed_exit");
        }
    }

    public void lose_life()
    {
        this.lives -= 1;
        if (this.lives < 0)
        {
            this.Lose_text.SetActive(true);
            StartCoroutine("timed_exit");
        }
        this.Lives_text.text = "Lives left : " + this.lives.ToString();
        this.sticky_shot = 0;
        this.free_ball = 0;
        this.ball.init();
    }

    public void apply_bonus(string bonus)
    {
        this.score += 50;
        this.Score_text.text = score.ToString();
        if (bonus == "Sticky ball")
        {
            this.sticky_shot = 5;
            this.free_ball = 0;
        }
        else
        {
            this.free_ball = 3;
            this.sticky_shot = 0;
        }
    }

    public void brick_destroy()
    {
        this.bricks--;
        this.score += 10;
        this.Score_text.text = score.ToString();
    }

    IEnumerator timed_exit()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}
