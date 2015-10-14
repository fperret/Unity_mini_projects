using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public GameObject particle;
    public GameObject bonus;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Ball")
        {
            Game_manager.instance.brick_destroy();
            Instantiate(particle, this.transform.position, Quaternion.identity);
            if (Random.Range(0f, 10f) >= 8)
                Instantiate(bonus, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
