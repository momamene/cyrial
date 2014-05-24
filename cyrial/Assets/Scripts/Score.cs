using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
    public int score = 0;
    public void Increase()
    {
        score++;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        guiText.text = "SCORE : " + score.ToString();
    }
}
