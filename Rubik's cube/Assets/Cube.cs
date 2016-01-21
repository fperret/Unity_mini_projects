using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;


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
	private float timer;
	private string[] cmds_input;
	private string[] cmds_solve;
	private int index;
	private bool	trigger_shuffle;
	private bool 	trigger_solve;
	private bool	shuffled;
	private bool	solved;
	private bool	recording;

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
        if (Input.GetKeyDown(KeyCode.W))
			this.rotate_dispatch(e_face.UP, false, false);
        else if (Input.GetKeyDown(KeyCode.S))
			this.rotate_dispatch(e_face.DOWN, false, false);
        if (Input.GetKeyDown (KeyCode.Q)) {
			this.rotate_dispatch (e_face.FRONT, false, false);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			this.rotate_dispatch (e_face.RIGHT, false, false);
		} else if (Input.GetKeyDown (KeyCode.E)) {
			this.rotate_dispatch (e_face.BACK, false, false);
		} else if (Input.GetKeyDown (KeyCode.A)) {
			this.rotate_dispatch (e_face.LEFT, false, false);
		} else if (Input.GetKeyDown (KeyCode.I)) {
			this.rotate_dispatch (e_face.UP, true, false);
		} else if (Input.GetKeyDown (KeyCode.K)) {
			this.rotate_dispatch (e_face.DOWN, true, false);
		} else if (Input.GetKeyDown (KeyCode.U)) {
			this.rotate_dispatch (e_face.FRONT, true, false);
		} else if (Input.GetKeyDown (KeyCode.O)) {
			this.rotate_dispatch (e_face.BACK, true, false);
		} else if (Input.GetKeyDown (KeyCode.L)) {
			this.rotate_dispatch (e_face.RIGHT, true, false);
		} else if (Input.GetKeyDown (KeyCode.J)) {
			this.rotate_dispatch (e_face.LEFT, true, false);
		} else if (Input.GetKeyDown (KeyCode.Space) && !shuffled) {
			this.trigger_shuffle = true;
			shuffled = true;
		} else if (Input.GetKeyDown (KeyCode.Space) && shuffled && !trigger_shuffle && !solved) {
			this.trigger_solve = true;
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		} else if (Input.GetKeyDown (KeyCode.R)) {
			recording = !recording;
		}
		if (trigger_shuffle) {
			timer += Time.deltaTime;
			if (timer > 0.2f) {
				process_cmd (cmds_input);
				if (index < (cmds_input.Length - 1))
					index++;
				else {
					trigger_shuffle = false;
					index = 0;
				}
				timer = 0.0f;
			}
		} else if (trigger_solve) {
			timer += Time.deltaTime;
			if (timer > 0.2f) {
				process_cmd (cmds_solve);
				if (index < (cmds_solve.Length - 1))
					index++;
				else {
					solved = true;
					trigger_solve = false;
				}
				timer = 0.0f;
			}
		}
    }

    private void rotate_dispatch(e_face face, bool reverse, bool double_move)
    {
        GameObject[] tmp_face = new GameObject[8];

		int repeat = 1;
		if (double_move)
			repeat = 2;
		else if (reverse)
			repeat = 3;
		using (StreamWriter sw = new StreamWriter("unity.txt", true))
		       {
			for (int i = repeat; i != 0; i--) {
				copy_face (faces [(int)face], tmp_face);
				
				switch (face) {
					case e_face.UP:
						if (recording)
							sw.Write(" U");
						this.rotate_up (tmp_face);
						break;

					case e_face.DOWN:
						if (recording)
							sw.Write (" D");
						this.rotate_down (tmp_face);
						break;

					case e_face.FRONT:
						if (recording)
							sw.Write (" F");
						this.rotate_front (tmp_face);
						break;

					case e_face.RIGHT:
						if (recording)
							sw.Write (" R");
						this.rotate_right (tmp_face);
						break;

					case e_face.BACK:
						if (recording)
							sw.Write (" B");
						this.rotate_back (tmp_face);
						break;

					case e_face.LEFT:
					if (recording)
							sw.Write (" L");
						this.rotate_left (tmp_face);
						break;
				}
				same_face_rotation (faces [(int)face], tmp_face);
				faces [(int)face].apply_parent ();
				rotates [(int)face].rotate ();
			}
		}
    }

	private void process_cmd(string []cmds)
	{
		if (cmds[index].Length >= 1)
		{
			bool reverse = false;
			bool double_move = false;
			if (cmds[index].Length > 1)
			{
				if (cmds[index][1] == '\'')
					reverse = true;
				else if (cmds[index][1] == '2')
					double_move = true;

			}
			switch (cmds[index][0])
			{
			case 'U':
				rotate_dispatch (e_face.UP, reverse, double_move);
				break;
			case 'D':
				rotate_dispatch (e_face.DOWN, reverse, double_move);
				break;
			case 'F':
				rotate_dispatch (e_face.FRONT, reverse, double_move);
				break;
			case 'R':
				rotate_dispatch (e_face.RIGHT, reverse, double_move);
				break;
			case 'B':
				rotate_dispatch (e_face.BACK, reverse, double_move);
				break;
			case 'L':
				rotate_dispatch (e_face.LEFT, reverse, double_move);
				break;
			default:
				break;
			}
		}
	}
	
	private void load_cmd()
	{
		try
		{
			string			line;
			StreamReader	reader = new StreamReader("solution.txt", Encoding.Default);

			using (reader)
			{
				line = reader.ReadLine ();
				// Read first line
				if (line != null)
				{
					this.cmds_input = line.Split (' ');
				}
				line = reader.ReadLine ();
				// Read second line
				if (line != null)
				{
					this.cmds_solve = line.Split (' ');
				}
				reader.Close();
			}
		}
		catch (IOException e)
		{
			Debug.Log ("error file");
			Debug.Log (e.ToString());
		}
	}

	void Start()
	{
		trigger_shuffle = false;
		trigger_solve = false;
		shuffled = false;
		solved = false;
		recording = false;
		load_cmd ();
		timer = 0.0f;
		index = 0;
	}
}