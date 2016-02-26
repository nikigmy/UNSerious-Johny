using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;
    public int ShotsPerSecond = 1;
    public bool Silencer;
    AudioSource Audio;
    Transform ShootingPositionWithoutSilencer;
    Transform ShootingPositionWithSilencer;
    private bool IsSilencerActive;
    int shotCounter;
    void Start () 
    {
        if(Silencer)
        {
            IsSilencerActive = true;
            ShootingPositionWithSilencer = transform.GetChild(1);
        }
        ShootingPositionWithoutSilencer = transform.GetChild(0);
        Audio = GetComponent<AudioSource>();
        shotCounter = 0;
	}
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Silencer)
        {
            IsSilencerActive = !IsSilencerActive;
            transform.GetChild(2).GetChild(0).transform.gameObject.SetActive(IsSilencerActive);
        }
    }
	void FixedUpdate ()
    {
        if (shotCounter > 60 / ShotsPerSecond)
        {
            if (Input.GetMouseButton(0))
            {
                if (Silencer && IsSilencerActive)
                {
                    Instantiate(Bullet, ShootingPositionWithSilencer.position, ShootingPositionWithSilencer.rotation);
                }
                else
                {
                    Instantiate(Bullet, ShootingPositionWithoutSilencer.position, ShootingPositionWithoutSilencer.rotation);
                    Audio.Play();
                }
            }
            shotCounter = 0;
        }
        shotCounter++;
	}
}
