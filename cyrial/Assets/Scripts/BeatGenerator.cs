using UnityEngine;
using System.Collections;

public class BeatGenerator : MonoBehaviour {
    public float ORIGINAL_BPM = 133.33f;
	public float offset = 0.05f;
	// Use this for initialization
    public float GetTimeDelta()
    {
        return 60.0f / ORIGINAL_BPM / GetComponent<AudioSource>().pitch;
    }

	void FixedUpdate() {

		if (Time.fixedTime == 0) {
			Time.fixedDeltaTime = offset;
			return;
		} else if (Time.fixedTime > 63.0f) {
			FindObjectOfType<Life>().Clear();
		}
		BeatReceiver[] receivers = FindObjectsOfType<BeatReceiver>();
		for (int i = 0; i < receivers.Length; i++) {
			receivers[i].SendMessage("Beat");
		}
		//GameObject ga = (GameObject)Instantiate(Resources.Load("Prefab/es108"));
		//Destroy(ga, 0.1f);
		FindObjectOfType<Score>().Increase();
		Time.fixedDeltaTime = GetTimeDelta ();
	}
}