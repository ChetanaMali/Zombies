using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public GameObject[] zombies;                                     // Array of zombiees.

    public bool isRising = false;                                    //zombiees up.
    public bool isFalling = false;                                   //zombiees Down.

    private int activeZombiesIndex = 0;
    private Vector2 startPosition;

    public float rizeSpeed = 1f;

    private int zombieSmashed;
    private int liveRemaining;
    private bool gameOver;

    public UnityEngine.UI.Image life01;
    public UnityEngine.UI.Image life02;
    public UnityEngine.UI.Image life03;
    public Text scoreText;

    public UnityEngine.UI.Button gameOverButton;

    public int scoreThresholde = 5;

    void Start()
    {
        scoreText.text = zombieSmashed.ToString();
        zombieSmashed = 0;
        liveRemaining = 3;
        gameOver = false;
        pickNewZombie();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (isRising)
            {
                //zombiee goes upward.
                //zombies[activeZombiesIndex].transform.Translate(Vector2.up * Time.deltaTime * rizeSpeed);
                if (zombies[activeZombiesIndex].transform.position.y - startPosition.y >= 2.7f)  // 0-(-3)=3.  
                {
                    //when zombie is at upward side then it falls down. 
                    isRising = false;
                    isFalling = true;
                }
                else
                {
                    zombies[activeZombiesIndex].transform.Translate(Vector2.up * Time.deltaTime * rizeSpeed);
                }
            }
            else if (isFalling)
            {
                //zombiee goes Down.
                if (zombies[activeZombiesIndex].transform.position.y - startPosition.y <= 0)
                {
                    //When zombies are at down then it goes upward.
                    isRising = false;
                    isFalling = false;
                    liveRemaining--;
                    UpdateUILife();
                    

                }
                else
                {
                    zombies[activeZombiesIndex].transform.Translate(Vector2.down * Time.deltaTime * rizeSpeed);
                }
            }
            else
            {
                //Happening anything else.
                zombies[activeZombiesIndex].transform.position = startPosition;
                pickNewZombie();
            }
        }
        
    }

    private void UpdateUILife()
    {
        if (liveRemaining == 3)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(true);
            life03.gameObject.SetActive(true);             //all three hearts are enable.
        }
        else if (liveRemaining == 2)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(true);
            life03.gameObject.SetActive(false);            //last one heart is Disable
        }
        else if (liveRemaining == 1)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(false);
            life03.gameObject.SetActive(false);            // last two heart are Disable
        }
        if (liveRemaining == 0)
        {
            life01.gameObject.SetActive(false);
            life02.gameObject.SetActive(false);
            life03.gameObject.SetActive(false);            // GAME OVER...!
            gameOver = true;
            gameOverButton.gameObject.SetActive(true);        
        }
    }

    private void pickNewZombie() 
    {
        isRising = true;
        isFalling = false;
        activeZombiesIndex = UnityEngine.Random.Range(0, zombies.Length);    // variable for generate Random Number of zombiees between 0 and 6.
        startPosition = zombies[activeZombiesIndex].transform.position;
    }

    public void killEnemy()
    {
        zombieSmashed++;                                               //Write code for kill an Enemy.
        increaseSpawnSpeed();
        scoreText.text = zombieSmashed.ToString();
        zombies[activeZombiesIndex].transform.position = startPosition;
        pickNewZombie();
        //Debug.Log(zombieSmashed);

    }

    public void increaseSpawnSpeed()
    {
        if(zombieSmashed >= scoreThresholde)
        {
            /*
              scoreThreshould is increase by double when speed is increase by 0.5f.
             */
            rizeSpeed += 0.5f;
            scoreThresholde *= 2;   

        }
    }

    public void onRestart()
    { 
        //method for restart the game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //

        //Debug.Log("Restart Now...!");
    }

    public void 
        onMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
