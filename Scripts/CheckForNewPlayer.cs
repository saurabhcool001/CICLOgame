using UnityEngine;



public class CheckForNewPlayer : MonoBehaviour
{

    public GameObject realBtn, unrealInstructionBtn;

    [Header("Script References")]
    
    public PlayerData pd;


    private void Awake()
    {


        if(pd.GetPlayerIndexInstructions() == 1)
        {
            realBtn.SetActive(true);
            unrealInstructionBtn.SetActive(false);
        }

        if(pd.GetPlayerIndexInstructions() == 0)
        {
            realBtn.SetActive(false);
            unrealInstructionBtn.SetActive(true);
        }

    }



}
