using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemFollow : MonoBehaviour {	
	void Update () {
        Vector3 playerPos = GameObject.Find("Player").transform.position;

        transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z + 0.1f);
	}
}
