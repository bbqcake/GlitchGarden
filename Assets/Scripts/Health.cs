using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{
	[SerializeField] float health = 100f;
	[SerializeField] GameObject deathVFX;
	

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void DealDamage(float damage)
	{
		health -= damage;

		if(health <= 0)
		{
			TriggerDeathVFX();
			Destroy(gameObject);
		}		
	}	


	private void TriggerDeathVFX()
	{
		if(!deathVFX) {	return;	}
		GameObject deathVFXObject = Instantiate(deathVFX, transform.position + new Vector3(-1f,0f,0f), transform.rotation); // TODO clean up vector3
		Destroy(deathVFXObject, deathVFXObject.GetComponent<ParticleSystem>().main.startLifetime.constantMax);
	}



}
