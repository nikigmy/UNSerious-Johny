using UnityEngine;
using System.Collections;

public class FinalSpawner: MonoBehaviour
{
    public GameObject Zombie;
    public void FuckHim()
    {
        Debug.Log("2");
        for (int i = 0; i < PlayerPrefs.GetInt("ZombiesLeft"); i++)
        {
            Instantiate(Zombie, transform.position, transform.rotation);
        }
        PlayerPrefs.SetInt("ZombiesLeft", 0);

    }
}
