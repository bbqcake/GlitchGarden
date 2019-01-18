using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour 
{
	Defender defender;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnMouseDown()
	{		
		AttemptToPlaceDefenderAt(GetSquareClicked());		
	}

	public void SetSelectedDefender(Defender defenderToSelect)
	{
		defender = defenderToSelect;
	}

	private void AttemptToPlaceDefenderAt(Vector2 gridPos)
	{
		var StarDisplay = FindObjectOfType<StarDisplay>();
		int defenderCost = defender.GetStarCost();

		if(StarDisplay.HaveEnoughStars(defenderCost))
		{
			SpawnDefender(gridPos);
			StarDisplay.SpendStars(defenderCost);			
		}
	}

	private Vector2 GetSquareClicked()
	{
		Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

		Vector2 gridPos = snapToGrid(worldPos);
		return gridPos; // converting worldPos to Gridpos
	}

	private Vector2 snapToGrid(Vector2 rawWorldPos)
	{
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2(newX, newY);
	}

	private void SpawnDefender(Vector2 roundedPos)
	{
		Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
		Debug.Log(roundedPos);
	}
}
