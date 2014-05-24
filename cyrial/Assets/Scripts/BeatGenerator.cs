using UnityEngine;
using System.Collections;

public class BeatGenerator : MonoBehaviour {
    public float ORIGINAL_BPM = 133.33f;
	// Use this for initialization
    public float GetTimeDelta()
    {
        return 60.0f / ORIGINAL_BPM / GetComponent<AudioSource>().pitch;
    }
    IEnumerator Timeflow(float timedelta)
    {
        yield return new WaitForSeconds(timedelta);
        BeatReceiver[] receivers = FindObjectsOfType<BeatReceiver>();
        for (int i = 0; i < receivers.Length; i++) {
            receivers[i].SendMessage("Beat");
        }
        //GameObject ga = (GameObject)Instantiate(Resources.Load("Prefab/es108"));
        //Destroy(ga, 0.1f);
        FindObjectOfType<Score>().Increase();
        StartCoroutine(Timeflow(GetTimeDelta()));
    }
	void Start () {
        StartCoroutine(Timeflow(GetTimeDelta() / 2.0f));
	}
}
