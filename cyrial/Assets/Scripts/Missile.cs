using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
    }
    public Direction direction;
    public float speedScale = 0.65f;
    private float duration = 1.0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, duration);
	}
	
    public float GetSpeed()
    {
        return speedScale * FindObjectOfType<BeatGenerator>().GetTimeDelta();
    }

	// Update is called once per frame
	void Update () {
        float speed = GetSpeed();
        switch (direction) {
            case Direction.LEFT:
                transform.position += new Vector3(-speed, 0, 0);
                break;
            case Direction.RIGHT:
                transform.position += new Vector3(speed, 0, 0);
                break;
            case Direction.UP:
                transform.position += new Vector3(0, -speed, 0);
                break;
            case Direction.DOWN:
                transform.position += new Vector3(0, speed, 0);
                break;
        }
	}
}
