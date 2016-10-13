using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMotion : MonoBehaviour {

	public delegate void MotionHandler();
	public static MotionHandler ChangeDirection;
	public static MotionHandler StartSprint;
	public static MotionHandler ResetSprint;

	//Variables for basic motion
	public float speed;
	private Vector3 tempPos;
	private Vector3 initPos;
	private Animator anim;

	// Variables for jump control
	private bool isJumping = false;
	private JumpScript jumpScript;

	// Use this for initialization
	void Start () {
		CameraMotion.ResetAll += ResetPos;

		anim = GetComponent<Animator> ();
		initPos = transform.position;
		jumpScript = GetComponent<JumpScript> ();

		StartCoroutine (GetComponent<Sprint> ().RefillSprint ());
	}

	// Update is called once per frame
	void Update () {
		//Left-Right motion control
		ChangeDirection();
		transform.Translate (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0);

		if (!Input.GetKey ("left") && !Input.GetKey("right")) {
			anim.SetBool ("IsRunning", false);
		} else {
			anim.SetBool ("IsRunning", true);
		}

		//Jump control
		if (Input.GetKeyDown (KeyCode.Space) && jumpScript.enabled == true)
		{
			if (!isJumping) {
				jumpScript.Hop ();
				isJumping = true;
			} else {
				jumpScript.Hop2 ();
				isJumping = false;
				jumpScript.enabled = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			StartSprint ();
		} else if (Input.GetKeyUp (KeyCode.LeftShift)) {
			ResetSprint ();
		}
	}

	//Re-enables jumping after hitting the ground
	void OnCollisionStay()
	{
		isJumping = false;
		jumpScript.enabled = true;
	}

	//Reset to beginning
	void ResetPos()
	{
		transform.position = initPos;
	}
}
