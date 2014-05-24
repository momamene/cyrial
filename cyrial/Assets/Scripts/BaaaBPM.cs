using UnityEngine;
using System.Collections;

public class BaaaBPM : MonoBehaviour {

    IEnumerator First()
    {
        yield return new WaitForSeconds(12.0f);
        Time.timeScale = 0.15625f;
        Missile[] missiles = FindObjectsOfType<Missile>();
        for (int i = 0; i < missiles.Length; i++) {
            Destroy(missiles[i].gameObject, 0.0f);
        }
        StartCoroutine(Second());
    }
    IEnumerator Second()
    {
        yield return new WaitForSeconds(0.46875f);
        Time.timeScale = 1;
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(First());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
