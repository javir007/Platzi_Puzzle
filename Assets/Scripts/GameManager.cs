using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject finalPortal;
    public GameObject player;
    public Transform spawnPoint;

    private bool playerMovement = true;

    private int points = 0;
    private int itemAmnt = 0;
    private int playerLifes = 3;
    private bool stopMovement = false;


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
        SpawnPlayer();
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
            KillPlayer();
            Invoke("SpawnPlayer", 1f);
        }else{
            playerLifes = 0;
        }

    }

    public void EnablePortal(bool isEnable){
        finalPortal.SetActive(isEnable);
        stopMovement = isEnable;
    }

    public void PlayerMove(bool canMove){
        playerMovement = canMove;
    }

    public void SpawnPlayer(){
        player.SetActive(true);
        PlayerMove(true);
        player.transform.position = spawnPoint.position;
    }

    public void KillPlayer(){
        PlayerMove(false);
        player.SetActive(false);
    }


}
