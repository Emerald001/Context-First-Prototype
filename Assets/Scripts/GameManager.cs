using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //huilen
    public List<GameObject> Levels = new();

    public LevelManager LevelManager;

    void Start() {
        LevelManager = new(this, Levels);


    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            LevelManager.LoadLevel("Level 1");
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            LevelManager.LoadLevel("Level 2");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            LevelManager.LoadLevel("Level 3");
        }
    }
}