using UnityEngine;
using UnityEngine.UI;

// /!\ It is important to give the right name to the correct gameobjects

public class Input_button : MonoBehaviour {

    private bool is_on = false;
    private Button  button;
    private Text text;
    private Color normal;
    private Color pressed;
    
    void Awake ()
    {
        this.button = this.GetComponent<Button>();
        this.text = GetComponentInChildren<Text>();
        this.normal = this.button.colors.normalColor;
        this.pressed = this.button.colors.pressedColor;
    }

    void Start()
    {
        text.text = Inputs_manager.instance.getter_dispatch(this.name).ToString();
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
                    if (Inputs_manager.instance.is_keycode_valid(key))
                    {
                        Inputs_manager.instance.setter_dispatch(this.name, key);
                        text.text = key.ToString();                        
                    }
                    this.button_clicked();
                    break;
                }
            }
        }
	}
}
