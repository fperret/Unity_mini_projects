using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Button_set_text : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start ()
    {
        this.text = GetComponentInChildren<Text>();
        set_text_content(Inputs_manager.instance.getter_dispatch(this.name));
	}

    public void set_text_content(KeyCode value)
    {
        text.text = value.ToString();
    }
}
