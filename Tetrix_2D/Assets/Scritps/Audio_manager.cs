using UnityEngine;
using System.Collections;

public class Audio_manager : MonoBehaviour {

    public AudioSource audio_source;
    public AudioClip[] musics;

    private int current_music;
	// Use this for initialization
	void Start ()
    {
        this.current_music = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (!this.audio_source.isPlaying)
        {
            this.audio_source.clip = this.musics[this.current_music];
            this.audio_source.Play();
            this.current_music++;
        }
        if (this.current_music > this.musics.Length - 1)
            this.current_music = 0;
	}
}
