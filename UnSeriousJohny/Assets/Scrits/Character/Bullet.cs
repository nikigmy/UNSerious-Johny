using UnityEngine;
using System.Collections;
using Assets;

public class Bullet : MonoBehaviour
{
    public int Range = 0;
    public float Speed = 10;
    public int Damage;
    private int counter = 0;
    void Update()
    {
        if (Soldier.Paused) return;
        transform.Translate(Vector3.forward * Speed);
        if (counter > Range)
            Destroy(gameObject);
        else
            counter++;

    }
}
