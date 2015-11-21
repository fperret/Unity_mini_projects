using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Input_button : MonoBehaviour {

    private bool is_on = false;
    private Button  button;
    Color normal;
    Color pressed;

    void Awake ()
    {
        this.button = this.GetComponent<Button>();
        this.normal = this.button.colors.normalColor;
        this.pressed = this.button.colors.pressedColor;
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


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
