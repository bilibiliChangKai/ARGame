using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour {
    public  GameObject player;
    GameObject player1, player2;
    private bool has_1, has_2, has_3;
    private GameObject archer;
    private Animator _animator;
    private Animator archer_animator;
    double player_blood;
    double archer_blood;
    double revive_time;
    bool hasarcher;
    double player_dead_time;
    double archer_dead_time;
    int end;
    static int turn;
    // Use this for initialization
    private void Awake()
    {
       
    }
    void Start () {

        player = GameObject.Find("player");
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        archer = GameObject.Find("archer");
        has_1 = has_2 = has_3 = true;
        end = 3;
        turn = 0;
        /*
         * 读入代码，修改has1,2,3;
         * */
        if (PlayerPrefs.GetInt("level0") == 0)
        {
            has_1 = false;
        }
        else
        {
            has_1 = true;
        }
        if (PlayerPrefs.GetInt("level1") == 0)
        {
            has_2 = false;
        }
        else
        {
            has_2 = true;
        }
        if (PlayerPrefs.GetInt("level2") == 0)
        {
            has_3 = false;
        }
        else
        {
            has_3 = true;
        }


        if (!has_3)
        {
            end = 2;
            if (!has_2)
                end = 1;
        }
        //player.SetActive(false);
        player1.active = (false);
        player2.active = (false);
        if (has_1)
            turn = 1;
        if (!has_1 && has_2)
            turn = 2;
        if (!has_1 && !has_2 && has_3)
            turn = 3;
        archer.active = true;
        archer_animator = archer.GetComponent<Animator>();
        _animator = player.GetComponent<Animator>();
        player_blood = 30;
        revive_time = 60;
        hasarcher = true;
        archer_blood = 10;
        player_dead_time = 0.6;
        archer_dead_time = 0.6;
        _animator.SetBool("walk", false);
        _animator.SetBool("attack", false);
    }
	
	// Update is called once per frame
	void Update () {
        print("last:" + revive_time.ToString());
        if (!hasarcher)
            revive_time -= 0.05;
        if (hasarcher)
            player_blood -= 0.01;
        if (_animator.GetBool("attack")) { }
        if (revive_time <= 0)
        {
            hasarcher = true;
            archer_blood = 10;
            revive_time = 60;
            archer_dead_time = 0.6;
            archer.active = true;
            archer_animator.SetBool("dead", false);
            archer_animator.SetBool("isattacked", false);
        }
        if (archer_animator.GetBool("isattacked"))
        {
            archer_blood -= 0.08;
            print("get a attack");
        }
        if (archer_blood <= 0)
        {
           
            
            hasarcher = false;
            archer_animator.SetBool("dead", true);
            _animator.SetBool("attack", false);
            _animator.SetBool("walk", false);
        }
        if (_animator.GetBool("attack")&&!archer_animator.GetBool("isattacked"))
        {
            player_blood -= 0.05;
        }
        if (_animator.GetBool("dead"))
        {
            player_dead_time -= 0.01;
        }
        if (archer_animator.GetBool("dead"))
        {
            archer_dead_time -= 0.01;
        }
        if (player_blood <= 0)
        {
            _animator.SetBool("attack", false);
            _animator.SetBool("walk", false);
            _animator.SetBool("dead", true);
            
            //this.gameObject.SetActive(false);
        }
        if (player_dead_time <= 0)
        {
            player.active=false;
            if (end == turn)
                Lose_the_game();
            if (turn==1&&has_2)
            {
                player = player1;
                player.active=true;
                player_dead_time = 0.6;
                _animator = player.GetComponent<Animator>();
                player_blood = 30;
                turn=2;
            }
          else if(turn == 2 && has_3)
            {
                player =player2;
                player.active = true;
                player_dead_time = 0.6;
                _animator = player.GetComponent<Animator>();
                player_blood = 30;
                turn =3;
            }
        }
        if (archer_dead_time <= 0)
        {
            archer.active=false;
        }
    }
    void Lose_the_game()
    {
        print("lose the game");
        SceneManager.LoadScene("defeat");
    }
    public static int Get_turn()
    {
        return turn;
    }
}
