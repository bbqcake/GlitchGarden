using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
	[SerializeField] GameObject projectile;
	[SerializeField] GameObject gun;
	AttackerSpawner myLanespawner;
	Animator animator;
	GameObject projectileParent;

	const string PROJECTILE_PARENT_NAME = "Projectiles";

	// Use this for initialization
	void Start () 
	{
		SetLaneSpawner();
		animator = GetComponent<Animator>();
		CreateProjectileParent();
	}

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

		if(!projectileParent)
		{
			projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
		}
    }

    // Update is called once per frame
    void Update () 
	{
		if(IsAttackerInLane())
		{			
			animator.SetBool("IsAttacking", true);
		}
		else
		{			
			animator.SetBool("IsAttacking", false);
		}
	}

	private void SetLaneSpawner()
	{
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

		foreach(AttackerSpawner spawner in spawners)
		{
			bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon); // close to 0. // TODO work out top lanes are always attacking

			if(IsCloseEnough)
			{
				myLanespawner = spawner;
			}
		}
	}

	private bool IsAttackerInLane()
	{
		if(myLanespawner.transform.childCount <= 0)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public void Fire()
	{
		GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject; // we turn it into gameobject so we can parent it to others
		newProjectile.transform.parent = projectileParent.transform;
	}
}
