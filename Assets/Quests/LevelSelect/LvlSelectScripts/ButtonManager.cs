using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    bool BriefActive;
    public GameObject brief;
    public void OpenBrief() 
    {
        if (BriefActive == false)
        {
            brief.SetActive(true);
            BriefActive = true;
        }

        else if (BriefActive == true)
        {
            brief.SetActive(false);
            BriefActive = false;
        }
    }

    public void EndLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
