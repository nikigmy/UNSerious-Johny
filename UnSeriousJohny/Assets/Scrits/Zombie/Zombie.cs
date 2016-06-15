using UnityEngine;
using System.Collections;
using Assets;

public class Zombie : MonoBehaviour
{
    public AudioClip DeathSound;
    private AudioSource audio;
    private NavMeshAgent nav;
    private GameObject player;
    private Animator animator;
    private int Health = 100;
    public int Damage = 10;
    private bool attacking;
    private float distance;
    private int attackCounter;
    private Animator anim;
    private bool dead;
    private int deleteCounter = 0;
	void Start ()
	{
	    audio = GetComponent<AudioSource>();
	    anim = GetComponent<Animator>();
        anim.Play("walk",0, Random.Range(0.0f, 2f));
	    attackCounter = 0;
	    attacking = false;
	    nav = GetComponent<NavMeshAgent>();
	    animator = GetComponent<Animator>();
        player = GameObject.Find("Character");

    }
	void Update ()
	{
	    if (Soldier.Paused)
	    {
            anim.speed = 0;
            nav.Stop();
	        audio.mute = true;
	        return;
	    }
	    if (!dead)
	    {
	        audio.mute = false;
	        anim.speed = 1;
	        nav.Resume();
	        distance = Vector3.Distance(transform.position, this.player.transform.position);
	        if (distance <= 1.5)
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

	        if (Health <= 0)
	        {
	            anim.SetTrigger("Died");
	            dead = true;
	            StartCoroutine(DeleteZombie(5));
	        }
	        attackCounter++;
	    }
	    else
	    {
	        audio.clip = DeathSound;
	        audio.loop = false;
            audio.Play();
            nav.Stop();
        }
	}

    IEnumerator DeleteZombie(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
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
