using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToClues : MonoBehaviour
{
    public int numberOfMissions = 3;
    public GameObject cluePrefab;
    public GameObject clueSpawnLocation;

    public List<Clue> firstMission = new List<Clue>();
    public List<Clue> secondMission = new List<Clue>();
    public List<Clue> thirdMission = new List<Clue>();

    public int CluePage;
    

    private NoteBook notebook; 

    // Start is called before the first frame update
    void Start()
    {
        notebook = GetComponent<NoteBook>();   
    }

    // Update is called once per frame
    void Update()
    {
        CluePage = notebook.currentPage;
    }

    public void ShowClues()
    {
        notebook.ResetPage();
        
        if (notebook.currentPage == 0){
            Debug.Log("Going to  first clue");
            foreach (Clue clues in firstMission){

                cluePrefab.GetComponent<InventorySlot>().ClueScriptableObject = clues;
                var tmp = Instantiate(cluePrefab, clueSpawnLocation.transform);
                notebook.prefabList.Add(tmp);
                }
        }
        if (notebook.currentPage == -1 && numberOfMissions >= 2){
            Debug.Log("Going to  middle clue");
            foreach (Clue clues in secondMission){
                cluePrefab.GetComponent<InventorySlot>().ClueScriptableObject = clues;
                var tmp = Instantiate(cluePrefab, clueSpawnLocation.transform);
                notebook.prefabList.Add(tmp);
            }
        }
        if (notebook.currentPage == -2 && numberOfMissions >= 2) {
            Debug.Log("Going to  third clue");
            foreach (Clue clues in thirdMission) {
                cluePrefab.GetComponent<InventorySlot>().ClueScriptableObject = clues;
                var tmp = Instantiate(cluePrefab, clueSpawnLocation.transform);
                notebook.prefabList.Add(tmp);
            }
        }
    }


}
