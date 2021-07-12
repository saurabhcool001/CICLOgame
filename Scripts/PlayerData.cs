using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int playerIndex = 0;

    void Update()
    {
        
    }


    public void SetDefaultHighScore()
    {
        PlayerPrefs.SetInt("currentUserScore", 0);
    }

    public void SetHighScore(int _theScore)
    {
        PlayerPrefs.SetInt("currentUserScore", _theScore); 
    }



    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("currentUserScore"); 
    }


    //Use with cautions, it'll delete everything including highscores.
    void ResetEverything()
    {
        PlayerPrefs.DeleteAll();
    }


    public void SetOldPlayerInstructions()
    {
        PlayerPrefs.SetInt("onetimekey", 1);
        playerIndex = 1;
    }

    public void SetNewPlayerInstructions()
    {
        PlayerPrefs.SetInt("onetimekey", 0);
        playerIndex = 0;
    }

    public int GetPlayerIndexInstructions()
    {
        return PlayerPrefs.GetInt("onetimekey");
    }
}
