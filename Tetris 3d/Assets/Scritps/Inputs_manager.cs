﻿using UnityEngine;
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
    public KeyCode menu_key;
    
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
        load_inputs_from_playerprefs();
    }

    public bool is_keycode_valid(KeyCode value)
    {
        // Should pop a warning window
        if (value == move_left_key ||
            value == move_right_key ||
            value == rotate_key ||
            value == mute_key ||
            value == drop_key ||
            value == fall_key ||
            value == store_key ||
            value == KeyCode.Escape)
        {
            return (false);
        }
        return (true);
    }

    public KeyCode getter_dispatch(string s_key)
    {
        switch (s_key)
        {
            case "Move left":
                return (move_left_key);

            case "Move right":
                return (move_right_key);

            case "Rotate":
                return (rotate_key);

            case "Mute":
                return (mute_key);

            case "Drop":
                return (drop_key);

            case "Fall":
                return (fall_key);

            case "Store":
                return (store_key);

            default:
                return (KeyCode.None);
       }
    }

    public void setter_dispatch(string s_key, KeyCode value)
    {
        switch (s_key)
        {
            case "Move left":
                set_move_left_key(value);
                break;

            case "Move right":
                set_move_right_key(value);
                break;

            case "Rotate":
                set_rotate_key(value);
                break;

            case "Mute":
                set_mute_key(value);
                break;

            case "Drop":
                set_drop_key(value);
                break;

            case "Fall":
                set_fall_key(value);
                break;

            case "Store":
                set_store_key(value);
                break;

            default:
                break;
        }
    }

    private void load_inputs_from_playerprefs()
    {
        string tmp;

        if ((tmp = PlayerPrefs.GetString("move_left_key")) != "")
            set_move_left_key((KeyCode)System.Enum.Parse(typeof(KeyCode), tmp));
        else
            set_move_left_key(KeyCode.Q);

        if ((tmp = PlayerPrefs.GetString("move_right_key")) != "")
            set_move_right_key((KeyCode)System.Enum.Parse(typeof(KeyCode), tmp));
        else
            set_move_right_key(KeyCode.D);

        if ((tmp = PlayerPrefs.GetString("rotate_key")) != "")
            set_rotate_key((KeyCode)System.Enum.Parse(typeof(KeyCode), tmp));
        else
            set_rotate_key(KeyCode.R);

        if ((tmp = PlayerPrefs.GetString("mute_key")) != "")
            set_mute_key((KeyCode)System.Enum.Parse(typeof(KeyCode), tmp));
        else
            set_mute_key(KeyCode.M);

        if ((tmp = PlayerPrefs.GetString("drop_key")) != "")
            set_drop_key((KeyCode)System.Enum.Parse(typeof(KeyCode), tmp));
        else
            set_drop_key(KeyCode.Space);

        if ((tmp = PlayerPrefs.GetString("fall_key")) != "")
            set_fall_key((KeyCode)System.Enum.Parse(typeof(KeyCode), tmp));
        else
            set_fall_key(KeyCode.T);

        if ((tmp = PlayerPrefs.GetString("store_key")) != "")
            set_store_key((KeyCode)System.Enum.Parse(typeof(KeyCode), tmp));
        else
            set_store_key(KeyCode.Return);

        menu_key = KeyCode.Escape;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
