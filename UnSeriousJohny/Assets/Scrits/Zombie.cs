using UnityEngine;
using System.Collections;
using Assets;

public class Zombie : MonoBehaviour
{
    private NavMeshAgent nav;
    private GameObject player;
    private Animator animator;
    private int Health = 100;
    public int Damage = 10;
    private bool attacking;
    private float distance;
    private int attackCounter;
	void Start ()
	{
	    attackCounter = 0;
	    attacking = false;
	    nav = GetComponent<NavMeshAgent>();
	    animator = GetComponent<Animator>();
	    player = GameObject.Find("Character");

	}
	void Update ()
	{
	    distance = Vector3.Distance(transform.position, this.player.transform.position);
        if (distance <= 2)
        {
            if (!attacking)
            {
                nav.Stop();
                attacking = true;
                Attacked();
                attackCounter = 0;
            }
            this.animator.SetBool("Attacking", true);
            this.animator.SetBool("Walking", false);
            transform.LookAt(player.transform);
            if (attackCounter >= 43)
            {
                Attacked();
                attackCounter = 0;
            }
        }
        else
        {
            if (attacking)
                attacking = false;
            this.animator.SetBool("Attacking", false);
            this.animator.SetBool("Walking", true);
            this.nav.SetDestination(player.transform.position);
        }
        if(Health <= 0)
            Destroy(gameObject);
	    attackCounter++;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {
            Bullet currentBullet = col.GetComponentInParent<Bullet>();
            Health -= currentBullet.Damage;
            Destroy(col.gameObject);
        }
    }

    void Attacked()
    {
        Soldier.Character.DealDamage(Damage);
    }
}
