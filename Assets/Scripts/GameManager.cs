using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioManager a;

    private void Start()
    {
        audioManager.Init();
        a.Init();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            audioManager.PlayLoopedAudio("JEMUDR", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            a.PlayAudio("A");
        }
    }
}
