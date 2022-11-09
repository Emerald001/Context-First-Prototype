using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OpenMissionPromptCanvas(GameObject canvas)
    {
        Time.timeScale = 1;
        canvas.SetActive(true);
    }
    public void BackToMain(GameObject brief)
    {
        Time.timeScale = 1;
        brief.SetActive(false);
    }

}
