using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public Grid grid;
	public HUD hud;

	protected int currentSoldier;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void GameEnd()
	{
		grid.GameOver ();
		StartCoroutine (WaitForGridFill ());
	}

	public virtual void OnMove()
	{

	}

	public virtual void OnPieceClicked(GamePiece piece)
	{
        currentSoldier++;
	}

    public virtual void OnPieceCleared(GamePiece piece)
    {
    }

    protected virtual IEnumerator WaitForGridFill()
	{
		while (grid.IsFilling) {
			yield return 0;
		}

		hud.OnGameEnd (currentSoldier);
	}
}
