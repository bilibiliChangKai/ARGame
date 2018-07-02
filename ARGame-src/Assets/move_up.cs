using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_up : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float MoveSpeed = 0.25f;
        Vector3 transformValue = new Vector3(0, 0, MoveSpeed);
        transformValue = transformValue * Time.deltaTime;
        transform.Translate(transformValue, Space.World);
    }
}
