using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// /!\ It is important to give the right name to the correct gameobjects

public class Input_button : MonoBehaviour {

    private bool is_on = false;
    private Button  button;
    private Color normal;
    private Color pressed;
    private Dictionary<string, System.Action<KeyCode> > setter_dispatch = new Dictionary<string, System.Action<KeyCode> >();
    
    void Awake ()
    {
        this.button = this.GetComponent<Button>();
        this.normal = this.button.colors.normalColor;
        this.pressed = this.button.colors.pressedColor;
    }

    void Start ()
    {
        this.setter_dispatch["Move left"] = (value) => Inputs_manager.instance.set_move_left_key(value);
        this.setter_dispatch["Move right"] = (value) => Inputs_manager.instance.set_move_right_key(value);
        this.setter_dispatch["Rotate"] = (value) => Inputs_manager.instance.set_rotate_key(value);
        this.setter_dispatch["Mute"] = (value) => Inputs_manager.instance.set_mute_key(value);
        this.setter_dispatch["Drop"] = (value) => Inputs_manager.instance.set_drop_key(value);
        this.setter_dispatch["Fall"] = (value) => Inputs_manager.instance.set_fall_key(value);
        this.setter_dispatch["Store"] = (value) => Inputs_manager.instance.set_store_key(value);
    }

    public void button_clicked ()
    {
        this.is_on = !this.is_on;
        if (this.is_on)
        {
            this.GetComponent<Image>().color = this.pressed;
        }
        else
        {
            this.GetComponent<Image>().color = this.normal;
        }
    }


	void Update ()
    {
	    if (this.is_on)
        {
            // Tests GetKeyDown for all possible KeyCode
            foreach(KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    this.setter_dispatch[this.name](key);
                    this.button_clicked();
                    break;
                }
            }
        }
	}
}
