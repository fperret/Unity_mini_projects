using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_manager : MonoBehaviour {

    public GameObject controls_menu;
    public GameObject audio_menu;
    public GameObject menu_canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(Inputs_manager.instance.menu_key))
        {
            menu_canvas.SetActive(!menu_canvas.activeSelf);
        }
	}
}
