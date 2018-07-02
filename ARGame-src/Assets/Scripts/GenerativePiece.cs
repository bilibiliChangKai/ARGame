using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativePiece : MonoBehaviour {

    private GamePiece piece;

    void Awake()
    {
        piece = GetComponent<GamePiece>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Generate(float time, float delay = 0)
    {
        StartCoroutine(GenerateCoroutine(time, delay));
    }

    private IEnumerator GenerateCoroutine(float time, float delay)
    {
        Vector4 startColor = new Vector4(1, 1, 1, 0);
        Vector4 endColor = new Vector4(1, 1, 1, 1);
        piece.GetComponentInChildren<SpriteRenderer>().material.color = startColor
            ;
        if (delay != 0)
        {
            yield return new WaitForSeconds(delay);
        }

        for (float t = 0; t <= 1 * time; t += Time.deltaTime)
        {
            piece.GetComponentInChildren<SpriteRenderer>().material.color = Vector4.Lerp(startColor, endColor, t / time);
            yield return 0;
        }

        piece.GetComponentInChildren<SpriteRenderer>().material.color = endColor;
    }
}
