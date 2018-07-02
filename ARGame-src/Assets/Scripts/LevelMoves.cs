using UnityEngine;
using System.Collections;

public class LevelMoves : Level {

	public int numMoves;
    public int levelsnum;

	private int movesUsed = 0;
    private int[] levelSoldier;

	// Use this for initialization
	void Start () {
        levelSoldier = new int[levelsnum];
        for (int i = 0; i < levelsnum; i++)
        {
            levelSoldier[i] = 0;
            hud.SetSoldier(i, 0);
            // 设置缓存
            PlayerPrefs.SetInt("level" + i, 0);
        }
		hud.SetRemaining (numMoves);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnPieceClicked(GamePiece piece)
    {
        base.OnPieceClicked(piece);
        // 获得信息，并加上相应的士兵数量
        int level = (int)piece.GetComponent<ColorPiece>().Color;
        PlayerPrefs.SetInt("level" + level, ++levelSoldier[level]);
        hud.SetSoldier(level, levelSoldier[level]);
    }

    public override void OnMove ()
	{
		movesUsed++;

		hud.SetRemaining (numMoves - movesUsed);

		if (numMoves - movesUsed == 0) {
            GameEnd();
		}
	}
}
