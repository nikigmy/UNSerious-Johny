using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    int GunCount;
    int CurrentGun;
    
    void Start()
    {
        CurrentGun = 0;
        GunCount = transform.childCount;
        for (int i = 1; i < GunCount; i++)
        {
            transform.GetChild(i).active = false;
        }
    }
	void Update () 
    {
        //if(Input.GetMouseButtonDown(1))
        //{
        //    transform.GetChild(CurrentGun).active = false;
        //    if (CurrentGun == GunCount - 1)
        //        CurrentGun = 0;
        //    else CurrentGun++;
        //    transform.GetChild(CurrentGun).active = true;
            
        //}
	}
}
