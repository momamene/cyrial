using UnityEngine;
using System.Collections;

public class BeatGenerator : MonoBehaviour {
    public int ORIGINAL_BPM = 128;
	// Use this for initialization
    public float GetTimeDelta()
    {
        return 60.0f / (float)ORIGINAL_BPM / GetComponent<AudioSource>().pitch;
    }
    IEnumerator Timeflow(float timedelta)
    {
        yield return new WaitForSeconds(timedelta);
        BeatReceiver[] receivers = FindObjectsOfType<BeatReceiver>();
        for (int i = 0; i < receivers.Length; i++) {
            receivers[i].SendMessage("Beat");
        }
        StartCoroutine(Timeflow(GetTimeDelta()));
    }
	void Start () {
        StartCoroutine(Timeflow(GetTimeDelta()));
	}
}
