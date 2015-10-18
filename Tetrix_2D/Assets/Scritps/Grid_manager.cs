using UnityEngine;
using System.Collections;

public class Grid_manager : MonoBehaviour {

    public int  [,]grid = new int[22, 12];
    public static Grid_manager instance;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 22; ++i)
        {
            for (int j = 0; j < 12; ++j)
            {
                this.grid[i, j] = 0;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
