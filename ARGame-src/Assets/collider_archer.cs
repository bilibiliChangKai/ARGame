using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_archer : MonoBehaviour {
    private Animator _animator;
    // Use this for initialization
    void Start () {
        _animator = this.GetComponent<Animator>();

        _animator.SetBool("dead", false);
        _animator.SetBool("isattacked", false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {

        print("OnCollisionEnter");
     

        
        _animator.SetBool("isattacked", true);
        //Destroy(this.gameObject);
    }
    // 碰撞结束
    void OnCollisionExit(Collision collision)
    {
        _animator.SetBool("isattacked", false);
        
    }
}
