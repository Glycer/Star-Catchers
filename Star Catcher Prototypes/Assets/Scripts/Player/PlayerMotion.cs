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
		LevelTimer.EndLevel += Unsubscribe;

		anim = GetComponent<Animator> ();
		initPos = transform.position;
		jumpScript = GetComponent<JumpScript> ();

		StartCoroutine (GetComponent<Sprint> ().RefillSprint ());
	}

	// Update is called once per frame
	void Update () {
		//Left-Right motion control
		if (ChangeDirection != null)
			ChangeDirection();

		RunControl ();
		JumpControl ();
		SprintControl ();
	}

	//Re-enables jumping after hitting the ground
	void OnCollisionEnter()
	{
		isJumping = false;
		jumpScript.enabled = true;
	}

	//Reset to beginning
	void ResetPos()
	{
		transform.position = initPos;
	}

	//Funtions for each motion control, as tied to different key inputs, to run in Update
	void RunControl()
	{
		//transform.Translate (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0);

		if (Input.GetKey ("left")) {
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		} else if (Input.GetKey ("right")) {
			transform.Translate (speed * Time.deltaTime, 0, 0);
		}

		if (!Input.GetKey ("left") && !Input.GetKey("right")) {
			anim.SetBool ("IsRunning", false);
		} else {
			anim.SetBool ("IsRunning", true);
		}
	}

	void JumpControl()
	{
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
	}

	void SprintControl()
	{
		if (/*GetComponent<Sprint>().canSprint == true &&*/ Input.GetKeyDown (KeyCode.LeftShift)) {
			StartSprint ();
		} else if (Input.GetKeyUp (KeyCode.LeftShift)) {
			ResetSprint ();
		}
	}

	void Unsubscribe()
	{
		CameraMotion.ResetAll -= ResetPos;
	}
}
