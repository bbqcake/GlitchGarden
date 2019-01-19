using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour 
{

	[Tooltip("Level time in seconds")][SerializeField] float levelTime = 10f;
	bool triggeredLevelFinished = false;

	
	
	void Update ()
	{
		if (triggeredLevelFinished)
		{
		 	return; // once we are done it stops running the rest of the stuff in the update
		}
		GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

		bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

		if(timerFinished)
		{
			FindObjectOfType<LevelController>().LevelTimerFinished();
			triggeredLevelFinished = true;
		}
	}


}
