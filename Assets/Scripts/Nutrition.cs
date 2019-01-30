using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrition : MonoBehaviour {

    private bool isBeatable;
    public Vector4 col;
	//public int gainHpPoint;
	public int nutrType;

    void Awake()
    {
		if(nutrType == 0) //相同颜色
		{
			col = new Vector4(1f- Random.value*0.8f, 1f- Random.value*0.2f, 1f-Random.value*0.2f, 1f);
        	this.GetComponent<Renderer>().material.color = col;
		}else{ //不同颜色
			col = new Vector4(1f- Random.value*0.2f, 1f- Random.value*0.8f, 1f-Random.value*0.8f, 1f);
        	this.GetComponent<Renderer>().material.color = col;
		}
        
    }

    void OnCollisionEnter2D(Collision2D c)
    {
		print("nutrition is colliding " + c.transform.tag);
        if(c.transform.tag == "Player")
        {
            Destroy(this.gameObject, 0.3f);
        }
    }

	public int GetGainPoint(int s)
	{
		switch (s)
				{
					case 1:
						return 3;
						
					case 2:
						if(nutrType == 0){
							return 3;
						}else{
							return 6;
						}
						
					case 3:
						if(nutrType == 0){
							return 1;
						}else{
							return 2;
						}
					case 4:
						return 5;
				}
				return 0;
	}

}
