using UnityEngine;
using System.Collections;

public class Game_manager : MonoBehaviour
{
    public static Game_manager instance;
    public GameObject[] tetriminos;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void give_new_tetrimino()
    {
        // Changer pour avoir une liste des prochains et prendre le plus au dessus
        Instantiate(this.tetriminos[(int)Random.Range(0, 7)], new Vector3(5, 2, 0), Quaternion.identity);
    }
}
