using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour 
{
	[SerializeField]GameObject winLabel;
	[SerializeField]float waitToLoad = 4f;
	[SerializeField]GameObject loseLabel;
	int numberOfAttackers = 0;
	bool levelTimerFinished = false;

	// Use this for initialization
	void Start () 
	{
		winLabel.SetActive(false);
		loseLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void AttackerSpawned()
	{
		numberOfAttackers++;
	}

		public void AttackerKilled()
	{
		numberOfAttackers--;

		if(numberOfAttackers <= 0 && levelTimerFinished == true)
		{
			StartCoroutine(HandleWinCondition());		
		}		
	}

	IEnumerator HandleWinCondition()
	{
		winLabel.SetActive(true);
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(waitToLoad);
		FindObjectOfType<LevelLoader>().LoadNextScene();
	}

	public void LevelTimerFinished()
	{
		levelTimerFinished = true;
		StopSpawners();
	}

	private void StopSpawners()
	{
		AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
		foreach (AttackerSpawner spawner in spawnerArray)
		{
			spawner.StopSpawning();
		}
	}

	public void HandleLoseCondition()
	{		
		loseLabel.SetActive(true);
		Time.timeScale = 0;
	}
}

