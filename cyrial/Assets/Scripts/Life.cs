using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {
    public float life = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            Time.timeScale = 1;
            Application.LoadLevel("main");
        }
	}
    public void Decrease()
    {
        life--;
        if (life == 0) {
            Death();
        }
    }
    public void Death()
    {
        Time.timeScale = 0;
		guiText.text = "DEATH";
        guiText.enabled = true;
    }
	public void Clear()
	{
		Time.timeScale = 0;
		guiText.text = "CLEAR";
		guiText.enabled = true;
	}
}
