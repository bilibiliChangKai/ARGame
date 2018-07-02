using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class MyVBHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    private GameObject player, player1, player2;
    private Animator _animator;
    GameObject boss;
    Transform player_transform;
    Vector3 targetPos;
    bool turn = true;
    int old_turn;
    int the_turn=1;
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        
        switch (vb.VirtualButtonName)
        {
           

            case "VirtualButton_down":
                 old_turn = the_turn;
                the_turn = control.Get_turn();
                if (old_turn != the_turn)
                    turn = true;
                if (turn)
                {
                    turn = false;
                    if(player.active)
                    player.transform.Rotate(new Vector3(0, 180, 0));
                    if (player1.active)
                    player1.transform.Rotate(new Vector3(0, 180, 0));
                    if (player2.active)
                    player2.transform.Rotate(new Vector3(0, 180, 0));

                }
                

                    if (the_turn == 1&&!player.GetComponent<move_down>())
                {
                    player.AddComponent<move_down>();
                    player.GetComponent<Animator>().SetBool("walk", true);
                }
                if (the_turn == 2 && !player1.GetComponent<move_down>())
                {
                    player1.AddComponent<move_down>();
                    player1.GetComponent<Animator>().SetBool("walk", true);
                    print("into A 2");
                }
                if (the_turn == 3 && !player2.GetComponent<move_down>())
                {
                    player2.AddComponent<move_down>();
                    player2.GetComponent<Animator>().SetBool("walk", true);
                    print("into A 3");
                }
                //_animator.SetBool("walk", true);
                print("into A");
                break;
           
                
            case "VirtualButton_up":

                 old_turn = the_turn;
                the_turn = control.Get_turn();
                if (old_turn != the_turn)
                    turn = true;
                if (!turn)
                {
                    turn = true;
                    if (player.active)
                        player.transform.Rotate(new Vector3(0, 180, 0));
                    if (player1.active)
                        player1.transform.Rotate(new Vector3(0, 180, 0));
                    if (player2.active)
                        player2.transform.Rotate(new Vector3(0, 180, 0));
                }
                

                if (the_turn == 1 && !player.GetComponent<move_up>())
                {
                    player.AddComponent<move_up>();
                    player.GetComponent<Animator>().SetBool("walk", true);
                }
                if (the_turn == 2 && !player1.GetComponent<move_up>())
                {
                    player1.AddComponent<move_up>();
                    player1.GetComponent<Animator>().SetBool("walk", true);
                    print("into B 2");
                }
                if (the_turn == 3 && !player2.GetComponent<move_up>())
                {
                    player2.AddComponent<move_up>();
                    player2.GetComponent<Animator>().SetBool("walk", true);
                    print("into B 3");
                }
                //_animator.SetBool("walk", true);
                print("into B");
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
         

            case "VirtualButton_down":
                if (the_turn == 1 && player.GetComponent<move_down>())
                {
                    Destroy(player.GetComponent<move_down>());
                    player.GetComponent<Animator>().SetBool("walk", false);

                }
                if (the_turn == 2 && player1.GetComponent<move_down>())
                {
                    Destroy(player1.GetComponent<move_down>());
                    player1.GetComponent<Animator>().SetBool("walk", false);

                }
                if (the_turn == 3 && player2.GetComponent<move_down>())
                {
                    Destroy(player2.GetComponent<move_down>());
                    player2.GetComponent<Animator>().SetBool("walk", false);

                }
               
                break;
           

            case "VirtualButton_up":
                if (the_turn==1&&player.GetComponent<move_up>())
                {
                    Destroy(player.GetComponent<move_up>());
                    player.GetComponent<Animator>().SetBool("walk", false);

                }
                if (the_turn == 2 && player1.GetComponent<move_up>())
                {
                    Destroy(player1.GetComponent<move_up>());
                    player1.GetComponent<Animator>().SetBool("walk", false);

                }
                if (the_turn == 3 && player2.GetComponent<move_up>())
                {
                    Destroy(player2.GetComponent<move_up>());
                    player2.GetComponent<Animator>().SetBool("walk", false);

                }
                //_animator.SetBool("walk", false);
                break;
        }
    }

    // Use this for initialization  
    void Start()
    {
       
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }
        player = transform.Find("player").gameObject;
        player1 = transform.Find("player1").gameObject;
        player2 = transform.Find("player2").gameObject;
        //boss = transform.Find("WK_cavalry").gameObject;
        turn = true;
        _animator = player.GetComponent<Animator>();

    }

}