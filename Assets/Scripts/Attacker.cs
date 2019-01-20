using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour 
{
	//[Range(0f, 5f)][SerializeField] float walkSpeed = 1f;
	// Use this for initialization

	float currentSpeed = 1f;	
	GameObject currentTarget;
	
	void Update ()
	{
		transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
		UpdateAnimationState();
	}

	void Awake()
	{
		FindObjectOfType<LevelController>().AttackerSpawned();
	}

	void OnDestroy()
	{
		LevelController levelController = FindObjectOfType<LevelController>();
		if(levelController == null) {return;}
		levelController.AttackerKilled();
	}

	private void UpdateAnimationState()
	{
		if(!currentTarget)
		{
			GetComponent<Animator>().SetBool("IsAttacking", false);
		}
	}

	public void SetMovementSpeed(float speed)
	{
		currentSpeed = speed;
	}

	public void Attack(GameObject target)
	{
		GetComponent<Animator>().SetBool("IsAttacking", true);
		
		currentTarget = target;
	}

	public void StrikeCurrentTarget(float damage)
	{
		if(!currentTarget) {return;}

		Health health = currentTarget.GetComponent<Health>();

		if(health)
		{
			health.DealDamage(damage);		
						
		}

	}	
}
