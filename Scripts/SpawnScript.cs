using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{
    public float spawnRate = 1f;
    public GameObject hexPrefab;
    public float nextTimeToSpawn = 0f;
    public float timeLeft = 6.0f;
    public TextMeshProUGUI startText; // used for showing countdown from 3, 2, 1 
    public bool isGameover = false;


    [Header("Script References")]
    public GameManager gm;

    void Start()
    {
       // gameObject.GetComponent<CanvasGroup>().alpha
    }

 


    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");

        if (timeLeft < 0 && !isGameover)
        {
            gm.CloseMainMenuActivity();
            gm.OnMainMenuPlayButton();

            if (Time.time >= nextTimeToSpawn)
            {
                Instantiate(hexPrefab, Vector3.zero, Quaternion.identity);
                nextTimeToSpawn = Time.time + 0.5f / spawnRate;
            }
        }
        else
        {
        
        }
    }
}
