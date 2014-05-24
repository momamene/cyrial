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
    public float speed;
    private float duration = 3.0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, duration);
	}
	
    public float GetSpeed()
    {
        return Time.deltaTime * speed;
    }

	// Update is called once per frame
	void FixedUpdate () {
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
