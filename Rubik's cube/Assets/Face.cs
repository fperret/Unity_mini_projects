using UnityEngine;
using System.Collections;

public class Face : MonoBehaviour {
    public GameObject   upper_left;
    public GameObject   up;
    public GameObject   upper_right;
    public GameObject   left;
    public GameObject   right;
    public GameObject   bottom_left;
    public GameObject   bottom;
    public GameObject   bottom_right;

    public void apply_parent()
    {
        upper_left.transform.parent = transform;
        up.transform.parent = transform;
        upper_right.transform.parent = transform;
        left.transform.parent = transform;
        right.transform.parent = transform;
        bottom_left.transform.parent = transform;
        bottom.transform.parent = transform;
        bottom_right.transform.parent = transform;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
