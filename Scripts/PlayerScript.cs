using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreTex, afterGameOverScoreTex;

    public float moveSpeed = 400f;
    public float moveSpeedMob = 400f;
    public float movement = 0f;
    public int userScore = 0;
    public AudioSource scoreFX;
    public Animator score_anim;

    int dynamicLevelCap = 500;


    [Header("Script References")]
    public GameManager gm;
    public SpawnScript spaws;
    public PlayerData playerDataObject;

    public GoogleMobileAdsDemoScript ads;

    void Start()
    {
        Debug.LogWarning(playerDataObject.GetHighScore());
        scoreTex.text = "Max. Score: " + playerDataObject.GetHighScore().ToString();
    }

    private void Update()
    {
        //Android
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, -4f * Time.fixedDeltaTime * -moveSpeedMob);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                transform.RotateAround(Vector3.zero, Vector3.back, 4f * Time.fixedDeltaTime * +moveSpeedMob);
            }
        }

        //UnityEditor
        if (Input.GetKey(KeyCode.A))
        {

                transform.RotateAround(Vector3.zero, Vector3.forward, -1f * Time.fixedDeltaTime * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(Vector3.zero, Vector3.back, 1f * Time.fixedDeltaTime * +moveSpeed);
        }
    }


    public void LevelCapping()
    {
        if (userScore % dynamicLevelCap == 0)
        {
            spaws.spawnRate += 0.05f;
            dynamicLevelCap += 500;
        }
    }

    public void SetHighScoreOnGameOver()
    {

        afterGameOverScoreTex.text = "You Scored: " + userScore.ToString();

        if(userScore > playerDataObject.GetHighScore())
        {
            scoreTex.text = "Max. Score: " + userScore.ToString();
            playerDataObject.SetHighScore(userScore);   
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("scoreHitbox"))
        {
           
            userScore += 100;
            scoreTex.text = "Max. Score: " + userScore.ToString();
            afterGameOverScoreTex.text = "You Scored: " + userScore.ToString();
            LevelCapping();
            scoreFX.Play();
            score_anim.Play("max_score_ding");
        }

        else
        {
            SetHighScoreOnGameOver();
            spaws.isGameover = true;
            gm.DestroyCircles();
            gm.OnGameOverEvent();
            gm.mainCam.GetComponent<Rotater>().enabled = false;
            //CheckMinScoreAndLoadAdvertisement();
        }


        
    }


    public void NotCheckMinScoreAndLoadAdvertisement()
    {
        if(userScore > 300)
        {
            ads.ShowInterstitial();
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
