using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeClue : MonoBehaviour, IInteractable
{
    public ScriptableObject scriptableObject;
    public GoToClues cluesScript;
    public GameObject DragableCluePrefab;
    public Transform DragDropPage;
    GameObject tmp;
    public bool ClueFound = false;

    public void Interact()
    {
        //noteBook.ToggleClueFound(scriptableObject);
        if(ClueFound == false)
        {
            //tmp = Instantiate(DragableCluePrefab, DragDropPage);
            //DragableCluePrefab.GetComponent<ClueAnswer>().ClueScriptableObject = (Clue)scriptableObject;
            //DragableCluePrefab.GetComponent<DragableItem>().clue = (Clue)scriptableObject;
            cluesScript.firstMissionAnswers.Add(scriptableObject);
            ClueFound = true;
        }
            
    }
}
