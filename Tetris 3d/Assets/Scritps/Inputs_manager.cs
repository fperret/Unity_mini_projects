using UnityEngine;
using System.Collections;

public class Inputs_manager : MonoBehaviour {

    public KeyCode left_key;
    public KeyCode right_key;
    public KeyCode rotate_key;
    public KeyCode mute_key;
    public KeyCode drop_key;
    public KeyCode fall_key;
    
    public void set_left_key (KeyCode value)
    {
        this.left_key = value;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
