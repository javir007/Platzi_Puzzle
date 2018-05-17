using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject finalPortal;
    public GameObject player;
    public Transform spawnPoint;

    public bool playerMovement = true;


    public AudioClip[] collectableClips;

    private int points = 0;
    private int itemAmnt = 0;
    private int playerLifes = 3;
    private bool stopMovement = false;
    private int itemsPerLevel = 3;
    private int highScore;

    private AudioSource sound;

	private void Awake()
	{
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
	}

    public bool StopMovement{
        get { return stopMovement; }
    }

	// Use this for initialization
	void Start () {
        SpawnPlayer();
        highScore = PlayerPrefs.GetInt("Score", 0);
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(itemsPerLevel == itemAmnt){
            EnablePortal(true);
        }
	}

    public void PickItem(){
        points += 10;
        itemAmnt++;

    }

    public void PickCoin(){
        points += 5;
        sound.PlayOneShot(collectableClips[0]);
    }


    public void LoseLife(){
        if(playerLifes > 1){
            playerLifes--;
            KillPlayer();
            Invoke("SpawnPlayer", 1f);
        }else{
            playerLifes = 0;
            FinishGame();
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

    public void LevelCompleted(){
        PlayerMove(false);
        if(points>highScore){
            PlayerPrefs.SetInt("Score", points);
            highScore = points;
        }
        print("La puntuacion maxima es: " + highScore);
        Invoke("LoadScene", 5f);
    }

    public void PlayAgain(){
        LoadScene();
    }

    public void LoadScene(){
        SceneManager.LoadScene(0);
    }

    public void FinishGame(){
        KillPlayer();
        stopMovement = true;
    }


}
