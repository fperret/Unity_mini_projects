using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayVolume : MonoBehaviour
{
    public float volume = 0.0f;

    public void set_volume(float value)
    {
        volume = value;
    }

	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Text>().text = (Mathf.RoundToInt(this.volume * 100)).ToString();
	}
}
