using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

	bool spawn = true;
	[SerializeField] float minSpawnDelay = 1f;
	[SerializeField] float maxSpawnDelay = 5f;
	[SerializeField] Attacker[] attackerPrefabArray;
	

	// Use this for initialization
	IEnumerator Start ()
	{
		while (spawn)
		{		
			yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
			SpawnAttacker();
		}		
	}

	public void StopSpawning()
	{
		spawn = false;
	}

	private void SpawnAttacker()
	{
		var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
		Spawn(attackerPrefabArray[attackerIndex]);
	}
	
	private void Spawn(Attacker myAttacker)
	{
		Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
		newAttacker.transform.parent = transform; // spawns within spawner
	}

	


	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
