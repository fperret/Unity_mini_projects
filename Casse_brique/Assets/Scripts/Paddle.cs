using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    public float        speed;
    public bool         has_ball;

    private Rigidbody2D _body;
    private SpriteRenderer _sprite_r;

	// Use this for initialization
	void Start ()
    {
        this._body = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        this._sprite_r = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        this.has_ball = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.transform.position.x >= 0 && this.transform.position.x <= 31)
            this._sprite_r.enabled = true;
        else
            this._sprite_r.enabled = false;

        if (Input.GetKey(KeyCode.RightArrow))
            this._body.velocity = new Vector2(5 * this.speed, 0);
        else if (Input.GetKey(KeyCode.LeftArrow))
            this._body.velocity = new Vector2(-5 * this.speed, 0);
        else
            this._body.velocity = new Vector2(0, 0);
        if (this.transform.position.x <= -31)
            this.transform.position = new Vector2(55.36f, this.transform.position.y);
        else if (this.transform.position.x >= 56)
            this.transform.position = new Vector2(-30, this.transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Ball")
        {
            if (Game_manager.instance.sticky_shot > 0)
            {
                hit.gameObject.GetComponent<Ball>().init();
                Game_manager.instance.sticky_shot--;
            }
        }
    }
}
