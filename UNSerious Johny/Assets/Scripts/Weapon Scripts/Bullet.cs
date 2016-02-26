using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int Speed;
    public int Range;
    private int CurrentFrame;
	void Start () {
        CurrentFrame = 0;
	}
	void FixedUpdate () {
        if (CurrentFrame == Range)
            Destroy(gameObject);
        else CurrentFrame++;
        transform.Translate(Vector3.forward);
        
	}
}
