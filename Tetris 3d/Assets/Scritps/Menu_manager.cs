using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_manager : MonoBehaviour {

    public GameObject controls_menu;
    public GameObject audio_menu;
    public GameObject menu_canvas;

    public void resume_game()
    {
        menu_canvas.SetActive(false);
        Time.timeScale = 1;
        Game_manager.instance.pause_from_menu(false);
    }
    
    public void controls_switch()
    {
        controls_menu.SetActive(!controls_menu.activeSelf);
        this.enabled = !controls_menu.activeSelf;
    }

    public void audio_switch()
    {
        audio_menu.SetActive(!audio_menu.activeSelf);
        this.enabled = !audio_menu.activeSelf;
    }

	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(Inputs_manager.instance.menu_key))
        {
            if (!menu_canvas.activeSelf)
            {
                menu_canvas.SetActive(true);
                Time.timeScale = 0;
                Game_manager.instance.pause_from_menu(true);
            }
            else
            {
                menu_canvas.SetActive(false);
                Time.timeScale = 1;
                Game_manager.instance.pause_from_menu(false);
            }
        }
	}
}
