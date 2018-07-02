using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject screenParent;
	public GameObject scoreParent;
	public UnityEngine.UI.Text scoreText;

	// Use this for initialization
	void Start () {
		screenParent.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowEnd(int soldier)
	{
		screenParent.SetActive (true);

		scoreText.text = soldier.ToString ();
		scoreText.enabled = true;

		Animator animator = GetComponent<Animator> ();

		if (animator) {
			animator.Play ("GameOverShow");
		}

		//StartCoroutine (ShowWinCoroutine (starCount));
	}

	public void OnDoneClicked()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("demo");
	}
}
