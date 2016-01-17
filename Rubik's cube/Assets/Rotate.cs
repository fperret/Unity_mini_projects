using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public Cube.e_face face;
    public Transform target;

    private float last_call;
	// Use this for initialization
	void Start () {
        last_call = 0.0f;
	
	}

    public void rotate()
    {
        switch (face)
        {
            case Cube.e_face.UP:
                transform.RotateAround(target.position, target.transform.up, 90);
                break;

            case Cube.e_face.DOWN:
                transform.RotateAround(target.position, target.transform.up, -90);
                break;

            case Cube.e_face.FRONT:
                transform.RotateAround(target.position, target.transform.right, 90);
                break;

            case Cube.e_face.RIGHT:
                transform.RotateAround(target.position, target.transform.forward, 90);
                break;

            case Cube.e_face.BACK:
                transform.RotateAround(target.position, target.transform.right, -90);
                break;

            case Cube.e_face.LEFT:
                transform.RotateAround(target.position, target.transform.forward, -90);
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update() {
     /*   if (last_call > 1)
        {
            switch (face)
            {
                case e_face.FRONT:
                    transform.RotateAround(target.position, target.transform.right, 45);
                    break;

                case e_face.BACK:
                    transform.RotateAround(target.position, target.transform.right, -45);
                    break;

                default:
                    break;
            }
            last_call = 0.0f; ;
        }*/
        last_call += Time.deltaTime;
        //transform.Rotate(Vector3.left, 2);
	
	}
}
