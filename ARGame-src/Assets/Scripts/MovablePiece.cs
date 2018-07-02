using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MovablePiece : MonoBehaviour {

	private GamePiece piece;
	private IEnumerator moveCoroutine;
    private IEnumerator bezierMoveCoroutine;

    void Awake() {
		piece = GetComponent<GamePiece> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(int newX, int newY, float time, float delay = 0)
	{
		if (moveCoroutine != null) {
			StopCoroutine (moveCoroutine);
		}

		moveCoroutine = MoveCoroutine (newX, newY, time, delay);
		StartCoroutine (moveCoroutine);
	}

    public IEnumerator MoveCoroutine(int newX, int newY, float time, float delay)
	{
        piece.X = newX;
		piece.Y = newY;

		Vector3 startPos = transform.position;
		Vector3 endPos = piece.GridRef.GetWorldPosition (newX, newY);

        if (delay != 0)
        {
            yield return new WaitForSeconds(delay);
        }

        for (float t = 0; t <= 1 * time; t += Time.deltaTime) {
			piece.transform.position = Vector3.Lerp (startPos, endPos, t / time);
			yield return 0;
		}
        

		piece.transform.position = piece.GridRef.GetWorldPosition (newX, newY);
	}

    public void BezierMove(Vector3 target, List<Vector3> vectors, float time, float delay = 0)
    {
        if (bezierMoveCoroutine != null)
        {
            StopCoroutine(bezierMoveCoroutine);
        }

        bezierMoveCoroutine = BezierMoveCoroutine(target, vectors, time, delay);
        StartCoroutine(bezierMoveCoroutine);
    }

    public IEnumerator BezierMoveCoroutine(Vector3 target, List<Vector3> vectors, float time, float delay)
    {
        Vector3 begin = piece.transform.position;

        if (delay != 0)
        {
            yield return new WaitForSeconds(delay);
        }

        for (float i = 0; i <= 1 * time; i += Time.deltaTime)
        {
            float t = i > time ? 1 : i / time;
            float _t = 1 - t;
            piece.transform.position = begin * Mathf.Pow(_t, 3) + 3 * vectors[0] * Mathf.Pow(_t, 2) * t
                + 3 * vectors[1] * _t * Mathf.Pow(t, 2) + target * Mathf.Pow(t, 3);
            yield return 0;
        }


        piece.transform.position = target;
    }
}
