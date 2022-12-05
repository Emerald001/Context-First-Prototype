using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


}
