using UnityEngine;
using System.Collections;

public class EvaderState : MonoBehaviour {
    public Sprite idleSprite;
    public Sprite crouchSprite;
    public Sprite jumpSprite;
    public Vector2 idleColliderSize = new Vector2(0.25f, 0.56f);
    public Vector2 idleColliderCenter = new Vector2(0, 0);
    public Vector2 crouchColliderSize = new Vector2(0.25f, 0.36f);
    public Vector2 crouchColliderCenter = new Vector2(0, -0.11f);
    public Vector2 jumpColliderSize = new Vector2(0.25f, 0.3f);
    public Vector2 jumpColliderCenter = new Vector2(0, 15f);
    public enum State
    {
        IDLE,
        CROUCH,
        JUMP
    }
    public State state;
    // Use this for initialization
	void Start () {
	
	}
    IEnumerator Idlize()
    {
        yield return new WaitForSeconds(FindObjectOfType<BeatGenerator>().GetTimeDelta() / 2.0f);
        state = State.IDLE;
        GetComponent<SpriteRenderer>().sprite = idleSprite;
        GetComponent<BoxCollider2D>().size = idleColliderSize;
        GetComponent<BoxCollider2D>().center = idleColliderCenter;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            state = State.CROUCH;
            GetComponent<SpriteRenderer>().sprite = crouchSprite;
            GetComponent<BoxCollider2D>().size = crouchColliderSize;
            GetComponent<BoxCollider2D>().center = crouchColliderCenter;
            StartCoroutine(Idlize());
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            state = State.JUMP;
            GetComponent<SpriteRenderer>().sprite = jumpSprite;
            GetComponent<BoxCollider2D>().size = jumpColliderSize;
            GetComponent<BoxCollider2D>().center = jumpColliderCenter;
            StartCoroutine(Idlize());
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<Life>().Decrease();
    }
}
