using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
	[Range(0.5f,5f)][SerializeField] float projectileSpeed = 5f;
	[SerializeField] float damage = 50f;
	

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{	
		Health health = otherCollider.GetComponent<Health>();	
		Attacker attacker = otherCollider.GetComponent<Attacker>();
		

		if(attacker && health)
		{
			
			health.DealDamage(damage);	
			Destroy(gameObject);
		}	
	}

	

}
