using UnityEngine;
using System.Collections;

public interface IProblem {

	string equation { get; set; }
	int solution { get; set;}

	void ResetSolution();
	string Generate ();
}
