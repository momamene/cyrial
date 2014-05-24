using UnityEngine;
using System.Collections;

public class AttackerState : MonoBehaviour {
    public enum Location
    {
        LEFT,
        RIGHT
    }
    public Location location;
    public enum GunPosition
    {
        MIDDLE,
        TOP
    }
    public GunPosition gunPosition;
    public Sprite middle;
    public Sprite top;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Beat()
    {
        if (Random.Range(0, 2) == 0) {
            gunPosition = GunPosition.MIDDLE;
            GetComponent<SpriteRenderer>().sprite = middle;
        }
        else {
            gunPosition = GunPosition.TOP;
            GetComponent<SpriteRenderer>().sprite = top;
        }
        GetComponent<Gun>().Shoot();
    }
}
