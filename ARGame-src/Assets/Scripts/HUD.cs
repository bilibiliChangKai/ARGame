using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public Level level;
	public GameOver gameOver;

	public UnityEngine.UI.Text remainingText;
	public UnityEngine.UI.Text []soldierText;

    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetSoldier(int level, int score)
	{
        soldierText[level].text = score.ToString ();
	}

	public void SetRemaining(int remaining)
	{
		remainingText.text = remaining.ToString ();
	}

	public void SetRemaining(string remaining)
	{
		remainingText.text = remaining;
	}

	public void OnGameEnd(int soldier)
	{
		gameOver.ShowEnd (soldier);
	}
}
