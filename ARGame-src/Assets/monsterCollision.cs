


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class monsterCollision : MonoBehaviour
{

    private Animator _animator;
    double blood;
    double time;
    int turn;
    private GameObject player,player1,player2;
    // Use this for initialization
    void Start()
    {
        blood = 100;
        time = 0.7;
        player = GameObject.Find("player");
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        _animator = this.GetComponent<Animator>();
        _animator.SetBool("combat", false);
        _animator.SetBool("dead", false);
    }

    // Update is called once per frame
    void Update()
    {
        turn = control.Get_turn();
        print("the turn:"+turn.ToString());
        if (_animator.GetBool("combat"))
        {
            blood -= 0.1;
        }
        if (_animator.GetBool("dead"))
        {
            time -= 0.01;
        }
        if (blood <= 0)
        {
            _animator.SetBool("combat", false);
            _animator.SetBool("dead", true);
        }
        if (time <= 0)
        {
            this.gameObject.SetActive(false);
            Win_the_game();
        }
        if (player.active&&player.GetComponent<Animator>().GetBool("dead"))
        {
            _animator.SetBool("combat", false);
            
        }
        if (player1.active && player1.GetComponent<Animator>().GetBool("dead"))
        {
            _animator.SetBool("combat", false);

        }
        if (player2.active && player2.GetComponent<Animator>().GetBool("dead"))
        {
            _animator.SetBool("combat", false);

        }
    }


    void Win_the_game()
    {
        print("win the game");
        SceneManager.LoadScene("victory");
    }

    // 碰撞开始
    void OnCollisionEnter(Collision collision)
    {
        
        print("OnCollisionEnter");
       
       // _animator.SetBool("walk", false);
        _animator.SetBool("combat", true);
        //Destroy(this.gameObject);
    }

    // 碰撞结束
    void OnCollisionExit(Collision collision)
    {
        _animator.SetBool("combat", false);
    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision)
    {

    }

}