using UnityEngine;
using System.Collections;

public class FinalSpawner: MonoBehaviour
{
    public GameObject Zombie;
    public void FuckHim()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("ZombiesLeft"); i++)
        {
            Instantiate(Zombie, transform.position, transform.rotation);
        }
        PlayerPrefs.SetInt("ZombiesLeft", 0);

    }
}
