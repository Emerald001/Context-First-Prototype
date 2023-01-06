using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueHolder : MonoBehaviour
{
    public List<Clue> ClueList = new List<Clue>();
    public GameObject CluePrefab;
    //public Transform PrefabSpawnLocation;

    public void Start()
    {
        foreach (Clue clue in ClueList)
        {
            Instantiate(CluePrefab, gameObject.transform);
        }
    }
}
