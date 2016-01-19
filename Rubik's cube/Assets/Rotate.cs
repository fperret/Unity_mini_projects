using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public Cube.e_face face;
    public Transform target;
	public float speed;
	public bool instant;

    public float last_call;
	private float goal;
	private float time_limit;
	private bool trigger;
	private bool reverse;
	// Use this for initialization
	void Start () {
        last_call = 0.0f;
	}

    public void rotate()
    {
        switch (face)
        {
            case Cube.e_face.UP:
			if (instant)
			transform.RotateAround(target.position, target.transform.up, 90f);
			else
			transform.RotateAround(target.position, target.transform.up, 90f * Time.deltaTime * speed);
                break;

            case Cube.e_face.DOWN:
			if (instant)
			transform.RotateAround(target.position, target.transform.up, -90f);
			else
			transform.RotateAround(target.position, target.transform.up, -90f * Time.deltaTime * speed);
                break;

            case Cube.e_face.FRONT:
			if (instant)
			transform.RotateAround(target.position, target.transform.right, 90f);
			else
			transform.RotateAround(target.position, target.transform.right, 90f * Time.deltaTime * speed);
                break;

            case Cube.e_face.RIGHT:
			if (instant)
			transform.RotateAround(target.position, target.transform.forward, 90f);
			else
			transform.RotateAround(target.position, target.transform.forward, 90f * Time.deltaTime * speed);
                break;

            case Cube.e_face.BACK:
			if (instant)
			transform.RotateAround(target.position, target.transform.right, -90f);
			else
			transform.RotateAround(target.position, target.transform.right, -90f * Time.deltaTime * speed);
                break;

            case Cube.e_face.LEFT:
			if (instant)
			transform.RotateAround(target.position, target.transform.forward, -90f);
			else
			transform.RotateAround(target.position, target.transform.forward, -90f * Time.deltaTime * speed);
                break;

            default:
                break;
        }
    }

	public void set_goal(bool reverse)
	{
		trigger = true;
		this.reverse = reverse;
		time_limit = (0.987f / speed) * ((reverse ? 3 : 1));
		switch (face) {
		case Cube.e_face.UP:
			//goal = this.transform.rotation.
			break;
		case Cube.e_face.DOWN:
			break;
		case Cube.e_face.FRONT:
			break;
		case Cube.e_face.RIGHT:
			break;
		case Cube.e_face.BACK:
			break;
		case Cube.e_face.LEFT:
			break;
		}
		if (instant)
			rotate ();
	}

    // Update is called once per frame
    void Update() {
		if (trigger && (!instant))
		{
			rotate();
			last_call += Time.deltaTime;
		}
		if (last_call >= (time_limit)) {
			trigger = false;
			reverse = false;
			last_call = 0.0f;
		}
	}
}
