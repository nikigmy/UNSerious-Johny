using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public GameObject bullet;
    private Transform bulletDispenser;
    private int wait;

    void Start()
    {
        bulletDispenser = transform.GetChild(0);
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && wait > 5)
        {
            Instantiate(bullet,bulletDispenser.position, transform.rotation);
            wait = 0;
        }
        wait++;
    }
}
