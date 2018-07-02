using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_down : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // transform.Rotate(new Vector3(0, 180, 0));
    }
	
	// Update is called once per frame
	void Update () {
        float MoveSpeed = -0.25f;
        Vector3 transformValue = new Vector3(0, 0, MoveSpeed);
        transformValue = transformValue * Time.deltaTime;
        transform.Translate(transformValue, Space.World);
    }
}
