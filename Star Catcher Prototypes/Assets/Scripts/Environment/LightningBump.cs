using UnityEngine;
using System.Collections;

public class LightningBump : MonoBehaviour {

	private Vector3 zeroVelocity = new Vector3(0, 0, 0);
	private Vector3 effectPos = new Vector3 (0, 0, -1);
	private Vector3 bumpForce = new Vector3 (500, 300, 0);
	//private float xPush = -1000;
	private GameObject effect;

	void OnCollisionEnter(Collision _col)
	{
		Rigidbody _colBody = _col.transform.GetComponent<Rigidbody>();

		effect = Instantiate (Resources.Load("2D/Effects/ElectrocuteEffect")) as GameObject;
		effect.transform.SetParent(_col.transform);
		effect.transform.localPosition = effectPos;

		//bumpForce.x = _colBody.velocity.x * xPush;
		_colBody.velocity = zeroVelocity;
		_colBody.AddForce (bumpForce);
	}
}