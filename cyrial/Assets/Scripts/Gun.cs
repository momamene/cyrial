using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public Vector3 middlemuzzle;
    public Vector3 topmuzzle;
    public GameObject missileRoot;
    public float missileSpeed = 0.65f;
    public void Shoot()
    {
        AttackerState character_state = GetComponent<AttackerState>();
        GameObject missile = null;
        switch(character_state.gunPosition) {
            case AttackerState.GunPosition.MIDDLE:
                missile = (GameObject)Instantiate(missileRoot, transform.position + middlemuzzle, Quaternion.identity);
                break;
            case AttackerState.GunPosition.TOP:
                missile = (GameObject)Instantiate(missileRoot, transform.position + topmuzzle, Quaternion.identity);
                break;
        }
        missile.GetComponent<Missile>().speedScale = missileSpeed;
        switch (character_state.location) {
            case AttackerState.Location.LEFT:
                missile.GetComponent<Missile>().direction = Missile.Direction.RIGHT;
                break;
            case AttackerState.Location.RIGHT:
                missile.GetComponent<Missile>().direction = Missile.Direction.LEFT;
                break;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(middlemuzzle, 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(topmuzzle, 0.1f);
    }
}
