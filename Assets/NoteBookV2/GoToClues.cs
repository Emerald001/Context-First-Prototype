using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToClues : MonoBehaviour
{
    public int numberOfMissions = 3;
    public GameObject clueQuestionPrefab;
    public GameObject clueAnserPrefab;
    public GameObject clueSpawnLocation;

    public List<Clue> firstMission = new List<Clue>();
    public List<Clue> secondMission = new List<Clue>();
    public List<Clue> thirdMission = new List<Clue>();
    public List<ScriptableObject> firstMissionAnswers = new List<ScriptableObject>();
    public List<ScriptableObject> secondMissionAnswers = new List<ScriptableObject>();
    public List<ScriptableObject> thirdMissionAnswers = new List<ScriptableObject>();
    public List<GameObject> objects = new List<GameObject>();

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
        RemoveAnswers();
        if (notebook.currentPage == 0){
            Debug.Log("Going to  first clue");
            foreach (Clue clues in firstMission){

                clueQuestionPrefab.GetComponent<InventorySlot>().ClueScriptableObject = clues;
                var tmp = Instantiate(clueQuestionPrefab, clueSpawnLocation.transform);
                notebook.prefabList.Add(tmp);
            }
            foreach(ScriptableObject clueAns in firstMissionAnswers)
            {
                clueAnserPrefab.GetComponent<ClueAnswer>().ClueScriptableObject = (Clue)clueAns;
                clueAnserPrefab.GetComponent<DragableItem>().clue = (Clue)clueAns;
                GameObject tmp = Instantiate(clueAnserPrefab, clueSpawnLocation.transform);
                objects.Add(tmp);
            }
        }
        if (notebook.currentPage == -1 && numberOfMissions >= 2){
            Debug.Log("Going to  middle clue");
            foreach (Clue clues in secondMission){
                clueQuestionPrefab.GetComponent<InventorySlot>().ClueScriptableObject = clues;
                var tmp = Instantiate(clueQuestionPrefab, clueSpawnLocation.transform);
                notebook.prefabList.Add(tmp);
            }
            foreach (ScriptableObject clueAns in secondMissionAnswers)
            {
                clueAnserPrefab.GetComponent<ClueAnswer>().ClueScriptableObject = (Clue)clueAns;
                clueAnserPrefab.GetComponent<DragableItem>().clue = (Clue)clueAns;
                GameObject tmp = Instantiate(clueAnserPrefab, clueSpawnLocation.transform);
                objects.Add(tmp);
            }
        }
        if (notebook.currentPage == -2 && numberOfMissions >= 2) {
            Debug.Log("Going to  third clue");
            foreach (Clue clues in thirdMission) {
                clueQuestionPrefab.GetComponent<InventorySlot>().ClueScriptableObject = clues;
                var tmp = Instantiate(clueQuestionPrefab, clueSpawnLocation.transform);
                notebook.prefabList.Add(tmp);
            }
            foreach (ScriptableObject clueAns in thirdMissionAnswers)
            {
                clueAnserPrefab.GetComponent<ClueAnswer>().ClueScriptableObject = (Clue)clueAns;
                clueAnserPrefab.GetComponent<DragableItem>().clue = (Clue)clueAns;
                GameObject tmp = Instantiate(clueAnserPrefab, clueSpawnLocation.transform);
                objects.Add(tmp);
            }
        }
    }

    public void RemoveAnswers()
    {
        foreach (ScriptableObject clueAns in firstMissionAnswers)
        {
            //Destroy(clueAns);
        }
        foreach (ScriptableObject clueAns in secondMissionAnswers)
        {

        }
        foreach (ScriptableObject clueAns in thirdMissionAnswers)
        {

        }
        foreach (GameObject clueAns in objects)
        {
            clueAns.SetActive(false);
            //Destroy(clueAns);
        }

    }

}
