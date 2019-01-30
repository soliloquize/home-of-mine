using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Swing : MonoBehaviour {

	Vector3 startPos;
	Vector3 curPos;

void Start(){
 startPos = this.transform.localPosition;
 InvokeRepeating("SwingA", Random.value, 10f);

}

void SwingA(){
	Vector3 moveTo = new Vector3(Random.value,Random.value,0)*5f;
	curPos = this.transform.localPosition;
	transform.DOMove(startPos+moveTo, 10f, false);
	//this.transform.localPosition = Vector3.Lerp (transform.localPosition, startPos+moveTo, (Random.value+1f)*Time.deltaTime);

}

}
