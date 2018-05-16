using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private int points = 0;
    private int itemAmnt = 0;
    private int playerLifes = 3;

	private void Awake()
	{
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PickItem(){
        points += 10;
        itemAmnt++;

    }

    public void LoseLife(){
        if(playerLifes > 1){
            playerLifes--;
        }else{
            playerLifes = 0;
        }

    }

}
