using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject room;
	public GameObject player;
	private Vector3 center;

	public bool isEnabled = true;

	// Use this for initialization
	void Start () {
		if (!isEnabled)
			return;
		Transform[] wallsT = room.GetComponentsInChildren<Transform> ();
		float[][] wallsV = new float[3][];

		//if 2 transforms have 2 matching components, put them together
		for (int i = 0; i < wallsT.Length-1; i++) {
			for (int j = i+1; j < wallsT.Length; j++) {
				bool xMatch = (wallsT [i].position.x == wallsT [j].position.x);
				bool yMatch = (wallsT [i].position.y == wallsT [j].position.y);
				bool zMatch = (wallsT [i].position.z == wallsT [j].position.z);

				//I want to explicitly sort here
				if(yMatch && zMatch) //x case
					wallsV[0] = new float[2] {wallsT[i].position.x, wallsT[j].position.x};
				else if(xMatch && zMatch) //y case
					wallsV[1] = new float[2] {wallsT[i].position.y, wallsT[j].position.y};
				else if(xMatch && yMatch) //z case
					wallsV[2] = new float[2] {wallsT[i].position.z, wallsT[j].position.z};
			}
		}

		//wallsV is now set up, time to find the center point;
		center = new Vector3((wallsV[0][0] + wallsV[0][1])/2, (wallsV[1][0] + wallsV[1][1])/2, (wallsV[2][0] + wallsV[2][1])/2);
		this.transform.position = center;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isEnabled)
			return;
		this.transform.LookAt (player.transform.position);
	}
}