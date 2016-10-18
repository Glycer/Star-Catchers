using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SectionData : MonoBehaviour {
	#region Maya Section Lengths
	/* These are the lengths of the different pieces:
	 * 		Chasm: 61
	 * 		Flat: 44
	 * 		Floating: 44
	 * 		Island: 58(L)/57(S)
	 * 		PlateauLeft: 43(L)/44(S)
	 * 		PlateauMiddle: 41(L)/42(S)
	 * 		SlopeDown: 49(L)/48(S)
	 * 		SlopeUp: 49
	 * 
	 * 		L = Lumpy	S = Smooth
	 * */
	#endregion

	public static Action<SectionData> SectionCycle;
	public bool canCycle;
	public bool canCycleInit;

	public int length;

	private Vector3 resetPos;

	void Start()
	{
		CameraMotion.ResetAll += ResetFloor;
		resetPos = transform.position;

		if (canCycle) {
			SectionCycle (this);
		}
	}

	void ResetFloor()
	{
		transform.position = resetPos;

		if (canCycleInit == false) {
			canCycle = false;
		} else {
			canCycle = true;
		}

		if (canCycle) {
			SectionCycle (this);
		}
	}
}