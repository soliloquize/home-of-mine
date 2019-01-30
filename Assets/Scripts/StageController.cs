using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

	public Transform changeStagePnl;
	public int curstage = 1;
	public GameObject[] stages;
	public int[] stageCount;
	int score = 0;

	public Transform nutrition;
	public Transform otherPlayer;
	public Transform enemySpike;

	public SoundEffectManager sound;

	public void PlayChangeStageAnim(){

	}

	public void ScoreCurStage(){
		if(score >= stageCount[curstage-1]){
			ChangeStage();
			score = 0;
		}else{
			score++;
		}
		print("current score is "+score);
	}

	public void ChangeStage(){
		curstage = curstage +1 ;
		switch(curstage)
		{
			case 1:
				stages[0].gameObject.SetActive(true);
				sound.SwitchMusic(0);
				break;
			case 2:
				stages[0].gameObject.SetActive(false);
				stages[1].gameObject.SetActive(true);
				sound.SwitchMusic(1);
				break;
			case 3:
				stages[1].gameObject.SetActive(false);
				stages[2].gameObject.SetActive(true);
				sound.SwitchMusic(2);
				break;
			case 4:
				stages[2].gameObject.SetActive(false);
				stages[3].gameObject.SetActive(true);
				sound.SwitchMusic(3);
				break;
			case 5:
				stages[3].gameObject.SetActive(false);
				stages[4].gameObject.SetActive(true);
				sound.SwitchMusic(4);
				break;
		}
	}


}
