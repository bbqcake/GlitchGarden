using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour 
{
	[SerializeField] int starCost = 100;

	
	public void AddStars(int amount) // using this so we can get it in the animation
	{
		FindObjectOfType<StarDisplay>().AddStars(amount);
	}

	public int GetStarCost()
	{
		return starCost;
	}
}
