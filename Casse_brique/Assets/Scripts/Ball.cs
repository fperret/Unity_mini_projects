using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public Paddle   paddle;
    public bool        paddle_stuck;

    private Rigidbody2D _body;

	// Use this for initialization
	void Start ()
    {
        this._body = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        this.paddle_stuck = true;
        this.init();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.paddle_stuck)
        {
            this.paddle.has_ball = true;
            this.transform.position = new Vector3(paddle.transform.position.x + 1.2f, paddle.transform.position.y + 0.92f, 0);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this._body.AddForce(new Vector2(15, 10), ForceMode2D.Impulse);
                this.paddle_stuck = false;
                this.paddle.has_ball = false;
            }
        }
	}

    public void init()
    {
        this.paddle_stuck = true;
        this._body.velocity = Vector2.zero;
    }
}
