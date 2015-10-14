using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

    private SpriteRenderer _sprite_r;
	// Use this for initialization
	void Start ()
    {
        ((Rigidbody2D)GetComponent(typeof(Rigidbody2D))).AddForce(Vector2.down * 8, ForceMode2D.Impulse);
        if (Random.value > 0.5f)
        {
            this.name = "Sticky ball";
            ((SpriteRenderer)GetComponent(typeof(SpriteRenderer))).color = Color.gray;
        }
        else
        {
            this.name = "Free ball";
            ((SpriteRenderer)GetComponent(typeof(SpriteRenderer))).color = Color.red;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            Game_manager.instance.apply_bonus(this.name);
            Destroy(this.gameObject);
        }
    }
}
