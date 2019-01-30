using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    public Color defultColor;
    public int curPlayerStage = 1;
    public int maxHp;
    public int curHp;
    public Transform playerObject;
    public Rigidbody2D playerRib;
    public StageController stageController;


	// Use this for initialization
	void Awake () {
        playerObject.GetComponent<Renderer>().material.color = defultColor;
        playerRib = GetComponent<Rigidbody2D>();

        stageController.ChangeStage();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W))
            {
                playerObject.transform.up = Vector3.Lerp(transform.up, new Vector3(0f, 1f, 0f), 0.2f);
                playerRib.AddForce(transform.up*moveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerObject.transform.up = Vector3.Lerp(transform.up, new Vector3(0f, -1f, 0f), 0.2f);
                playerRib.AddForce(-transform.up*moveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerObject.transform.up = Vector3.Lerp(transform.up, new Vector3(1f, 0f, 0f), 0.2f);
                playerRib.AddForce(-transform.right*moveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerObject.transform.up = Vector3.Lerp(transform.up, new Vector3(-1f, 0f, 0f), 0.2f);
                playerRib.AddForce(transform.right*moveSpeed);
            }
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        print("is colliding"+ c.transform.tag);
        if (c.transform.tag == "Spike")
        {
            if(curPlayerStage == 3)
            {

            }else if (curPlayerStage == 4)
            {

            }
        }
        if(c.transform.tag == "Home")
        {
            if(curPlayerStage == 3){

            }else if (curPlayerStage == 4){

            }
        }
        if(c.transform.tag == "Nutrition")
        {
            if(curPlayerStage == 1){
                PlayerGainMaxHp(c.transform.GetComponent<Nutrition>().GetGainPoint(curPlayerStage));
                stageController.ScoreCurStage();
            }
            else if (curPlayerStage == 2 && c.transform.GetComponent<Nutrition>().nutrType == 1){
                PlayerGainMaxHp(c.transform.GetComponent<Nutrition>().GetGainPoint(curPlayerStage));
                stageController.ScoreCurStage(); 
            }
            //print("is colliding nutrition");
            PlayerGainHp(c.transform.GetComponent<Nutrition>().GetGainPoint(curPlayerStage));
            ChangePlayerColor(c.transform.GetComponent<Renderer>().material.color);
        }

    }

    void ChangePlayerColor(Color c){
        Color curC = playerObject.transform.GetComponent<Renderer>().material.color;
        playerObject.transform.GetComponent<Renderer>().material.color = Color.Lerp(curC, c, 0.2f);
    }
    public void PlayerDropHp(int d)
    {
        if(curHp - d > 0){
            curHp = curHp - d;
        }
        else{
            print("GAME OVER!!!");
        }
    }

    public void PlayerGainHp(int g)
    {
        if(curHp + g >= maxHp){
            curHp = maxHp;
        }else{
            curHp = curHp + g;
            float p = g/curHp;
            Vector3 newScale = new Vector3(transform.localScale.x * p, transform.localScale.y * p, 1f);
            transform.DOScale(newScale, 0.2f);
        }
    }

    public void PlayerGainMaxHp(int m)
    {
        print("max up is "+ maxHp+", m is "+ m);
        maxHp = maxHp + m;
        float a = m, b = maxHp;
        float p = 1+ a/b;
        print("max up is "+ maxHp+", m is "+ m+", and p is"+p);
        Vector3 newScale = new Vector3(transform.localScale.x * p, transform.localScale.y * p, 1f);
        transform.DOScale(newScale, 0.2f);
    }

    public void ChangePlayerStage(int s)
    {
        int curStage = s;
        switch (curStage)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:
                Debug.Log("stage 5");
                break;
        }
    }
}
