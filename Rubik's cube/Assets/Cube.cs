using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
    public enum e_face
    {
        UP,
        DOWN,
        FRONT,
        RIGHT,
        BACK,
        LEFT
    };

    /*
        0 = up (yellow)
        1 = down (white)
        2 = front (blue)
        3 = right (red)
        4 = back (green)
        5 = left (orange)

    */
    public Face[] faces = new Face[6];
    public Rotate[] rotates = new Rotate[6];
    private Face[] save_faces = new Face[6];

    void Awake()
    {
        for (int i = 0; i < 6; ++i)
        {
            save_faces[i] = faces[i];
        }
    }

    private void copy_face(Face src, GameObject[] dst)
    {
        dst[0] = src.upper_left;
        dst[1] = src.up;
        dst[2] = src.upper_right;
        dst[3] = src.left;
        dst[4] = src.right;
        dst[5] = src.bottom_left;
        dst[6] = src.bottom;
        dst[7] = src.bottom_right;
    }

    private void same_face_rotation(Face face, GameObject[] tmp)
    {
        face.upper_left = tmp[5];
        face.up = tmp[3];
        face.upper_right = tmp[0];
        face.left = tmp[6];
        face.right = tmp[1];
        face.bottom_left = tmp[7];
        face.bottom = tmp[4];
        face.bottom_right = tmp[2];
    }

    public void rotate_up(GameObject[] tmp_face)
    {
        // FRONT
        faces[2].upper_left = tmp_face[7];
        faces[2].up = tmp_face[4];
        faces[2].upper_right = tmp_face[2];
        // RIGHT
        faces[3].upper_left = tmp_face[2];
        faces[3].up = tmp_face[1];
        faces[3].upper_right = tmp_face[0];
        // BACK
        faces[4].upper_left = tmp_face[0];
        faces[4].up = tmp_face[3];
        faces[4].upper_right = tmp_face[5];
        // LEFT
        faces[5].upper_left = tmp_face[5];
        faces[5].up = tmp_face[6];
        faces[5].upper_right = tmp_face[7];

    }

    public void rotate_down(GameObject[] tmp_face)
    {
        // FRONT
        faces[2].bottom_left = tmp_face[5];
        faces[2].bottom = tmp_face[3];
        faces[2].bottom_right = tmp_face[0];
        // RIGHT
        faces[3].bottom_left = tmp_face[0];
        faces[3].bottom = tmp_face[1];
        faces[3].bottom_right = tmp_face[2];
        // BACK
        faces[4].bottom_left = tmp_face[2];
        faces[4].bottom = tmp_face[4];
        faces[4].bottom_right = tmp_face[7];
        // LEFT
        faces[5].bottom_left = tmp_face[7];
        faces[5].bottom = tmp_face[6];
        faces[5].bottom_right = tmp_face[5];
    }

    public void rotate_front(GameObject[] tmp_face)
    {
        // UP
        faces[0].bottom_left = tmp_face[5];
        faces[0].bottom = tmp_face[3];
        faces[0].bottom_right = tmp_face[0];
       // DOWN
        faces[1].upper_left = tmp_face[7];
        faces[1].up = tmp_face[4];
        faces[1].upper_right = tmp_face[2];
        // RIGHT
        faces[3].upper_left = tmp_face[0];
        faces[3].left = tmp_face[1];
        faces[3].bottom_left = tmp_face[2];
        // LEFT
        faces[5].upper_right = tmp_face[5];
        faces[5].right = tmp_face[6];
        faces[5].bottom_right = tmp_face[7];
    }

    public void rotate_right(GameObject[] tmp_face)
    {
        // UP
        faces[0].upper_right = tmp_face[0];
        faces[0].right = tmp_face[3];
        faces[0].bottom_right = tmp_face[5];
        // DOWN
        faces[1].upper_right = tmp_face[7];
        faces[1].right = tmp_face[4];
        faces[1].bottom_right = tmp_face[2];
        // FRONT
        faces[2].upper_right = tmp_face[5];
        faces[2].right = tmp_face[6];
        faces[2].bottom_right = tmp_face[7];
        // BACK
        faces[4].upper_left = tmp_face[0];
        faces[4].left = tmp_face[1]; 
        faces[4].bottom_left = tmp_face[2];
    }

    public void rotate_back(GameObject[] tmp_face)
    {
        // UP
        faces[0].upper_left = tmp_face[0];
        faces[0].up = tmp_face[3];
        faces[0].upper_right = tmp_face[5];
        // DOWN
        faces[1].bottom_left = tmp_face[2];
        faces[1].bottom = tmp_face[4];
        faces[1].bottom_right = tmp_face[7];
        // RIGHT
        faces[3].upper_right = tmp_face[5];
        faces[3].right = tmp_face[6];
        faces[3].bottom_right = tmp_face[7];
        // LEFT
        faces[5].upper_left = tmp_face[0];
        faces[5].left = tmp_face[1];
        faces[5].bottom_left = tmp_face[2];
    }

    public void rotate_left(GameObject[] tmp_face)
    {
        // UP
        faces[0].upper_left = tmp_face[5];
        faces[0].left = tmp_face[3];
        faces[0].bottom_left = tmp_face[0];
        // DOWN
        faces[1].upper_left = tmp_face[2];
        faces[1].left = tmp_face[4];
        faces[1].bottom_left = tmp_face[7];
        // BACK
        faces[4].upper_right = tmp_face[5];
        faces[4].right = tmp_face[6];
        faces[4].bottom_right = tmp_face[7];
        // FRONT
        faces[2].upper_left = tmp_face[0];
        faces[2].left = tmp_face[1];
        faces[2].bottom_left = tmp_face[2];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.rotate_dispatch(e_face.UP, false);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.rotate_dispatch(e_face.DOWN, false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            this.rotate_dispatch(e_face.FRONT, false);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.rotate_dispatch(e_face.RIGHT, false);
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            this.rotate_dispatch(e_face.BACK, false);
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            this.rotate_dispatch(e_face.LEFT, false);
        }

        else if (Input.GetKeyDown(KeyCode.I))
        {
            this.rotate_dispatch(e_face.UP, true);
        }

        else if (Input.GetKeyDown(KeyCode.K))
        {
            this.rotate_dispatch(e_face.DOWN, true);
        }

        else if (Input.GetKeyDown(KeyCode.U))
        {
            this.rotate_dispatch(e_face.FRONT, true);
        }

        else if (Input.GetKeyDown(KeyCode.O))
        {
            this.rotate_dispatch(e_face.RIGHT, true);
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            this.rotate_dispatch(e_face.BACK, true);
        }

        else if (Input.GetKeyDown(KeyCode.J))
        {
            this.rotate_dispatch(e_face.LEFT, true);
        }
    }

    private void rotate_dispatch(e_face face, bool reverse)
    {
        GameObject[] tmp_face = new GameObject[8];

        for (int i = ((reverse) ? 3 : 1) ; i != 0; i--)
        {
            copy_face(faces[(int)face], tmp_face);
            switch (face)
            {
                case e_face.UP:
                    this.rotate_up(tmp_face);
                    break;

                case e_face.DOWN:
                    this.rotate_down(tmp_face);
                    break;

                case e_face.FRONT:
                    this.rotate_front(tmp_face);
                    break;

                case e_face.RIGHT:
                    this.rotate_right(tmp_face);
                    break;

                case e_face.BACK:
                    this.rotate_back(tmp_face);
                    break;

                case e_face.LEFT:
                    this.rotate_left(tmp_face);
                    break;
            }
            same_face_rotation(faces[(int)face], tmp_face);
            faces[(int)face].apply_parent();
            rotates[(int)face].rotate();
        }
    }
}