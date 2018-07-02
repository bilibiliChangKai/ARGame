using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Vuforia;

public class collider_army : MonoBehaviour {





    

    private Animator _animator;
    
    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        
        _animator.SetBool("walk", false);
        _animator.SetBool("attack", false);
    }

    // Update is called once per frame
    void Update()
    {
      


    }




    // 碰撞开始
    void OnCollisionEnter(Collision collision)
    {
       
        print("OnCollisionEnter");
        //GameObject rootObj = GameObject.Find("pic");
       
        //VirtualButtonBehaviour[] vbs = rootObj.GetComponentsInChildren<VirtualButtonBehaviour>();
        
        _animator.SetBool("walk", false);
        _animator.SetBool("attack", true);
        if (this.GetComponent<move_up>())
        {
            Destroy(this.GetComponent<move_up>());
        }
        if(this.GetComponent<move_down>())
               {
            Destroy(this.GetComponent<move_down>());
        }
        //Destroy(this.gameObject);
    }

    // 碰撞结束
    void OnCollisionExit(Collision collision)
    {
        _animator.SetBool("attack", false);
        _animator.SetBool("walk", true);
    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision)
    {

    }

}

