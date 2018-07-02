using UnityEngine;
using System.Collections;

public class ScaleablePiece : MonoBehaviour {

	private GamePiece piece;
	private IEnumerator scaleCoroutine;

	void Awake() {
		piece = GetComponent<GamePiece> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Scale(float newScale, float time, float delay = 0)
	{
		if (scaleCoroutine != null) {
			StopCoroutine (scaleCoroutine);
		}

		scaleCoroutine = ScaleCoroutine (newScale, time, delay);
		StartCoroutine (scaleCoroutine);
	}

	public IEnumerator ScaleCoroutine(float newScale, float time, float delay)
	{
		Vector3 startScale = transform.localScale;
        Vector3 endScale = new Vector3(newScale, newScale, 1);

        if (delay != 0)
        {
            yield return new WaitForSeconds(delay);
        }

        for (float t = 0; t <= 1 * time; t += Time.deltaTime) {
			piece.transform.localScale = Vector3.Lerp (startScale, endScale, t / time);
			yield return 0;
		}

        piece.transform.localScale = endScale;
    }
}
