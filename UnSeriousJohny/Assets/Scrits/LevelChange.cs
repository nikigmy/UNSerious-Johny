using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{

    public string Scene;
    public bool FinalLevel;
    private bool triedToFuckHim;

    void Start()
    {
        triedToFuckHim = false;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Soldier")
        {
            if (!FinalLevel)
            {
                int zombiesLeft;
                zombiesLeft = PlayerPrefs.HasKey("ZombiesLeft") ? PlayerPrefs.GetInt("ZombiesLeft") : 0;
                GameObject[] spawners = GameObject.FindGameObjectsWithTag("ZombieSpawner");
                zombiesLeft += GameObject.FindGameObjectsWithTag("Zombie").Length + spawners.Sum(spawner => spawner.GetComponent<ZombieSpawner>().ZombiesLeft);
                PlayerPrefs.SetInt("ZombiesLeft",zombiesLeft);
                SceneManager.LoadScene(Scene);
            }
            else
            {
                if (PlayerPrefs.GetInt("ZombiesLeft") == 0 && GameObject.FindGameObjectsWithTag("Zombie").Length == 0)
                    SceneManager.LoadScene("Win");
                else
                {
                    if (!triedToFuckHim)
                    {
                        Debug.Log("1");
                        triedToFuckHim = true;
                        GameObject.FindGameObjectWithTag("FinalSpawner").GetComponent<FinalSpawner>().FuckHim();
                    }
                }
            }
        }
    }
}
