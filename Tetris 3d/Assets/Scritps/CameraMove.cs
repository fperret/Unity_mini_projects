using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public GameObject positions_holder;

    private Transform[] positions;

    public void Awake()
    {
        positions = positions_holder.GetComponentsInChildren<Transform>();
    }

	// Update is called once per frame
	void Update ()
    {
        switch (Game_manager.instance.current_face)
        {
            case Constants.FRONT:
                this.transform.position = positions[1].position;
                this.transform.rotation = positions[1].rotation;
                break;

            case Constants.LEFT:
                this.transform.position = positions[2].position;
                this.transform.rotation = positions[2].rotation;
                break;

            case Constants.BACK:
                this.transform.position = positions[3].position;
                this.transform.rotation = positions[3].rotation;
               break;

            case Constants.RIGHT:
                this.transform.position = positions[4].position;
                this.transform.rotation = positions[4].rotation;
              break;

            case Constants.UP:
                this.transform.position = positions[5].position;
                this.transform.rotation = positions[5].rotation;
                break;

            default:
             break;
        }	
	}
}
