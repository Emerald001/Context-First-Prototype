using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCollectible : MonoBehaviour, IInteractable
{
    public ScriptableObject scriptableObject;

    public NoteBook noteBook;
    public int CollectiblesFound;
    public int index2;
    public void Start()
    {
        //noteBook = GetComponent<NoteBook>();
        CollectiblesFound = 0;
        index2 = 0;
    }
    public void Interact()
    {
        noteBook.testlist.CollectiblesList.Add(new Page());
        CollectiblesFound++;
        if(CollectiblesFound <= 6)
        {
            //noteBook.CollectiblesList.Add(scriptableObject);
            int index = noteBook.testlist.CollectiblesList.Count - 1;

            noteBook.testlist.CollectiblesList[index].PageList = new List<ScriptableObject>();
            noteBook.testlist.CollectiblesList[index2].PageList.Add(scriptableObject);

            Debug.Log(noteBook.testlist.CollectiblesList[index].PageList.Count);
            noteBook.AddCollectibleToNoteBook(scriptableObject);
            Debug.Log("INTERACT");

            if(CollectiblesFound == 6)
            {
                ResetList();
            }

        }
    }

    public void ResetList()
    {
        CollectiblesFound = 0;
        noteBook.testlist.CollectiblesList.Add(new Page());
        index2++;

    }
}
