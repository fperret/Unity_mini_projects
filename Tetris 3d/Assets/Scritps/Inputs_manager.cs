using UnityEngine;
using System.Collections;

public class Inputs_manager : MonoBehaviour {

    public static Inputs_manager instance;
    public KeyCode move_left_key;
    public KeyCode move_right_key;
    public KeyCode rotate_key;
    public KeyCode mute_key;
    public KeyCode drop_key;
    public KeyCode fall_key;
    public KeyCode store_key;
    
    public void set_move_left_key (KeyCode value)
    {
        this.move_left_key = value;
    }

    public void set_move_right_key (KeyCode value)
    {
        this.move_right_key = value;
    }

    public void set_rotate_key (KeyCode value)
    {
        this.rotate_key = value;
    }

    public void set_mute_key (KeyCode value)
    {
        this.mute_key = value;
    }

    public void set_drop_key (KeyCode value)
    {
        this.drop_key = value;
    }

    public void set_fall_key (KeyCode value)
    {
        this.fall_key = value;
    }

    public void set_store_key (KeyCode value)
    {
        this.store_key = value;
    }

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
