using UnityEngine;
using System.Collections;

public class Lose_zone : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Main ball")
        {
            Game_manager.instance.lose_life();
        }
        else
            Destroy(other.gameObject);
    }
}
