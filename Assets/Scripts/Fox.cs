using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour 
{

	// Use this for initialization
	

		private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		GameObject otherObject = otherCollider.gameObject;

		// if gravestone jump
		if(otherObject.GetComponent<Gravestone>())
		{
			GetComponent<Animator>().SetTrigger("JumpTrigger");
		}

		else if(otherObject.GetComponent<Defender>())
		{
			GetComponent<Attacker>().Attack(otherObject);
		}
	}
}

