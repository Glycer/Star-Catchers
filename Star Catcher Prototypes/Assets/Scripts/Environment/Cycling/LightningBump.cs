using UnityEngine;
using System.Collections;

public class LightningBump : MonoBehaviour {

	const float X_PUSH = -800;
	const float Y_PUSH = 300;

	private Vector3 zeroVelocity = new Vector3(0, 0, 0);
	private Vector3 effectPos = new Vector3 (0, 0, -1);
	private Vector3 bumpForce = new Vector3 (X_PUSH, Y_PUSH, 0);
	private GameObject effect;

	void OnTriggerEnter(Collider _col)
	{
		Rigidbody _colBody = _col.transform.GetComponent<Rigidbody>();
		FlipChar _colFacing = _col.transform.GetComponent<FlipChar> ();

		//Disable player jumping
		//_col.transform.GetComponent<JumpScript>().enabled = false;

		//Generate electrocution effect on player
		effect = Instantiate (Resources.Load("2D/Effects/ElectrocuteEffect")) as GameObject;
		effect.transform.SetParent(_col.transform);
		effect.transform.localPosition = effectPos;

		//Push player away
		bumpForce.x = _colFacing.facingX * X_PUSH;
		_colBody.velocity = zeroVelocity;
		_colBody.AddForce (bumpForce);
	}
}