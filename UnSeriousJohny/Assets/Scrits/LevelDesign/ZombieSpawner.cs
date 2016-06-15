using UnityEngine;
using System.Collections;
using Assets;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject Zombie;
    public int InitialSpawn = 0;
    public int TotalCount = 0;
    public float SpawnDelayInSeconds = 1;
    public int ZombiesInOneSpawn = 1;
    private int spawned;
    private bool passed;
    public float Proximity;
    private int oldTotalCount;
    private bool endless;
    public int ZombiesLeft { get { return TotalCount - spawned; } }

    void Start()
    {
        endless = false;
        passed = false;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, Soldier.Character.transform.position) <= Proximity && !passed)
        {
            spawned = 0;
            for (int i = 0; i < InitialSpawn; i++)
            {
                Instantiate(Zombie, transform.position, transform.rotation);
            }
            StartCoroutine(Spawn());
            passed = true;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!endless)
            {
                oldTotalCount = TotalCount;
                TotalCount = 0;
                if (spawned >= oldTotalCount)
                {
                    StartCoroutine(Spawn());
                }
                endless = true;
            }
            else
            {
                TotalCount = oldTotalCount;
                endless = false;
            }
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (spawned >= TotalCount && TotalCount != 0)
                break;
            yield return new WaitForSeconds(SpawnDelayInSeconds);
            if (Soldier.Paused)
            {
                for (int i = 0; i < ZombiesInOneSpawn; i++)
                {
                    Instantiate(Zombie, transform.position, transform.rotation);
                    spawned++;
                }
            }
        }
    }
}
