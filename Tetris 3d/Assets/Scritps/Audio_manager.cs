using UnityEngine;
using System.Collections;

public class Audio_manager : MonoBehaviour {

    public AudioSource audio_source;
    public AudioClip[] musics;

    private int current_music;
	// Use this for initialization
	void Start ()
    {
        this.current_music = -1;
        this.next_track();
	}
	
    private void next_track()
    {
        this.audio_source.Stop();

        this.current_music++;
        if (this.current_music == 2)
            this.audio_source.volume = 0.05f;
        else
            this.audio_source.volume = 0.1f;
        if (this.current_music > this.musics.Length - 1)
            this.current_music = 0;

        this.audio_source.clip = this.musics[this.current_music];
        this.audio_source.Play();
        Invoke("next_track", this.musics[this.current_music].length);
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (this.audio_source.isPlaying)
            {
                this.audio_source.Stop();
                CancelInvoke("next_track");
            }
            else
            {
                this.next_track();
            }
        }
	}
}
