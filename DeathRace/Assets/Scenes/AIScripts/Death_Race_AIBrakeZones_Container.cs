﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Death_Race_AIBrakeZones_Container : MonoBehaviour {
	
	public List<Transform> brakeZones = new List<Transform>();		

	void OnDrawGizmos() {
		
		for(int i = 0; i < brakeZones.Count; i ++){

			Gizmos.matrix = brakeZones[i].transform.localToWorldMatrix;
			Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.25f);
			Vector3 colliderBounds = brakeZones[i].GetComponent<BoxCollider>().size;

			Gizmos.DrawCube(Vector3.zero, colliderBounds);

		}
		
	}
	
}
