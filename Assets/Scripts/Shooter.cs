using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
	[SerializeField] GameObject projectile;
	[SerializeField] GameObject gun;
	AttackerSpawner myLanespawner;

	// Use this for initialization
	void Start () 
	{
		SetLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(IsAttackerInLane())
		{
			Debug.Log("Shoot pew pew");
			// TODO change animation state to shooting
		}
		else
		{
			Debug.Log("Sit and wait");
		}
	}

	private void SetLaneSpawner()
	{
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

		foreach(AttackerSpawner spawner in spawners)
		{
			bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon); // close to 0.

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
		Instantiate(projectile, gun.transform.position, Quaternion.identity);
	}
}
