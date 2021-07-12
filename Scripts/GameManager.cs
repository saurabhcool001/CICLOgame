using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerScript playObj;
    public SpawnScript spawnObj;

    public Camera mainCam;
    public GameObject _MainMenuActivity;
    public GameObject _GameElementsActivity;
    public GameObject _GameOverActivity;
    //public GameObject _SpawnerScript;






    private void Start()
    {
        //Time.timeScale = 0;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void OnMainMenuPlayButton()
    {
        mainCam.GetComponent<Rotater>().enabled = true;
    }

    public void CloseMainMenuActivity()
    {
        _MainMenuActivity.SetActive(false);
    }

    public void OnGameOverEvent()
    {
        _MainMenuActivity.SetActive(false);
        _GameElementsActivity.SetActive(false);
        _GameOverActivity.SetActive(true);
    }

    public void OnRetry()
    {
        spawnObj.nextTimeToSpawn = 1.0f;
        spawnObj.timeLeft = 3.0f;
        spawnObj.isGameover = false;

        _MainMenuActivity.SetActive(false);
        _GameElementsActivity.SetActive(true);
        _GameOverActivity.SetActive(false);   
    }

    

    public void GoToMainMenu()
    {
        _MainMenuActivity.SetActive(true);
        _GameElementsActivity.SetActive(false);
        _GameOverActivity.SetActive(false);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DestroyCircles()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("circles");

        foreach (GameObject g in go)
        {
            Destroy(g);
        }
    }

}
