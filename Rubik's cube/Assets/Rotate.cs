using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public Cube.e_face face;
    public Transform target;

	// Use this for initialization
	void Start () {
	}

    public void rotate()
    {
        switch (face)
        {
            case Cube.e_face.UP:
				transform.RotateAround(target.position, target.transform.up, 90f);
                break;

            case Cube.e_face.DOWN:
				transform.RotateAround(target.position, target.transform.up, -90f);
                break;

            case Cube.e_face.FRONT:
				transform.RotateAround(target.position, target.transform.right, 90f);
                break;

            case Cube.e_face.RIGHT:
				transform.RotateAround(target.position, target.transform.forward, 90f);
                break;

            case Cube.e_face.BACK:
				transform.RotateAround(target.position, target.transform.right, -90f);
                break;

            case Cube.e_face.LEFT:
				transform.RotateAround(target.position, target.transform.forward, -90f);
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update() {
	}
}
