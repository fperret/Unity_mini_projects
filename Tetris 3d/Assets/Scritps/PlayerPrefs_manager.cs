using UnityEngine;
using System.Collections;

public class PlayerPrefs_manager : MonoBehaviour {

    public static PlayerPrefs_manager instance;

    void Awake()
    {
        instance = this;
    }

    public void save_input_prefs()
    {
        PlayerPrefs.SetString("move_left_key", Inputs_manager.instance.move_left_key.ToString());
        PlayerPrefs.SetString("move_right_key", Inputs_manager.instance.move_right_key.ToString());
        PlayerPrefs.SetString("rotate_key", Inputs_manager.instance.rotate_key.ToString());
        PlayerPrefs.SetString("mute_key", Inputs_manager.instance.mute_key.ToString());
        PlayerPrefs.SetString("drop_key", Inputs_manager.instance.drop_key.ToString());
        PlayerPrefs.SetString("fall_key", Inputs_manager.instance.fall_key.ToString());
        PlayerPrefs.SetString("store_key", Inputs_manager.instance.store_key.ToString());
    }
}
