using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Cycler : MonoBehaviour {

	public static Action Cycle;

	const float FLOOR_DEPTH = -4f;
	const float INIT_DISTANCE = 27.6f;
	const float LENGTH_MULTIPLIER = .3f;

	public List<SectionData> cyclePieces;
	public SectionData forwardEdge;
	public SectionData defaultEdge;

	public List<GameObject> obstaclePrefabs;
	private Transform pastObstacles;

	private int rand;
	private Vector3 nextPos;
	private float distance = INIT_DISTANCE;

	// Use this for initialization
	void Start () {
		cyclePieces = new List<SectionData> ();
		SectionData.SectionCycle += CycleActionHandler;
		CameraMotion.ResetAll += ResetCycler;
		Cycle += CycleFront;

		nextPos.x = distance;
		nextPos.y = FLOOR_DEPTH;
	}

	private void CycleActionHandler(SectionData _secData)
	{
		cyclePieces.Add (_secData);
	}

	void OnTriggerEnter(Collider col)
	{
		//Delete superfluous objects, then cycle land
		pastObstacles = col.transform.FindChild("ObstacleSpawner");
		for (int i = 0; i < pastObstacles.childCount; i++) {
			pastObstacles.GetChild(i).GetComponent<SpawnObstacle>().CleanUp();
		}


		Cycle ();

		cyclePieces.Add(col.GetComponent<SectionData>());
	}

	void CycleFront()
	{
		//Set variables
		rand = UnityEngine.Random.Range (0, cyclePieces.Count);
		SectionData _newPiece = cyclePieces [rand];
		Transform obstacleSpawner = forwardEdge.transform.FindChild ("ObstacleSpawner");

		//Take the latest piece off the List
		cyclePieces.Remove (_newPiece);

		//Set new position, delete previous obstacles, and update forwardEdge
		distance = forwardEdge.length * LENGTH_MULTIPLIER;
		nextPos.x += distance;
		_newPiece.transform.position = nextPos;

		forwardEdge = _newPiece;

		//Spawn obstacles for the forward edge
		obstacleSpawner = forwardEdge.transform.FindChild ("ObstacleSpawner");
		for (int i = 0; i < obstacleSpawner.childCount; i++) {
			obstacleSpawner.GetChild (i).GetComponent<SpawnObstacle> ().Spawn (obstaclePrefabs);

		}
	}

	void ResetCycler()
	{
		//Clear the list and reset the 'next' position
		cyclePieces.Clear ();
		forwardEdge = defaultEdge;
		nextPos.x = INIT_DISTANCE;
	}
}