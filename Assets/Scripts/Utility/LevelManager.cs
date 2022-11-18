using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{
    public GameManager owner;

    public Dictionary<string, GameObject> Levels = new();
    private GameObject currentLevel;

    public LevelManager(GameManager owner, List<GameObject> levels) {
        this.owner = owner;

        for (int i = 0; i < levels.Count; i++) {
            Levels.Add("Level " + (i + 1).ToString(), levels[i]);
        }
    }

    void OnUpdate() {
        
    }

    public void LoadLevel(string ID) {
        if (!Levels.ContainsKey(ID))
            return;
        
        if (currentLevel)
            UnloadLevel();

        currentLevel = GameObject.Instantiate(Levels[ID]);
    }

    void UnloadLevel() {
        GameObject.Destroy(currentLevel);
    }
}