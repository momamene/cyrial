using UnityEngine;
using System.Collections;

public class BaaaBPM : MonoBehaviour {

    IEnumerator First()
    {
        yield return new WaitForSeconds(12.0f);
        Time.timeScale = 0.15625f;
        StartCoroutine(Second());
    }
    IEnumerator Second()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
        FindObjectOfType<Gun>().missileSpeed *= 1.5f;
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(First());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
