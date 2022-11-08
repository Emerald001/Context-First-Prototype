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
        noteBook.NoteBookList.CollectiblesList.Add(new Page());
        noteBook.NoteBookList.CollectiblesList[index2].PageList = new List<ScriptableObject>();
    }
    public void Interact()
    {
        CollectiblesFound++;
        if(CollectiblesFound <= 6)
        {
            int index = noteBook.NoteBookList.CollectiblesList.Count - 1;
            noteBook.NoteBookList.CollectiblesList[index].PageList.Add(scriptableObject);
            noteBook.AddCollectibleToNoteBook(scriptableObject);

            Debug.Log("INTERACT");
            Debug.Log("Index 1 = " + index);
            Debug.Log("Index 2 = " + index2);
            
            if(CollectiblesFound >= 6)
            {
                ResetList();
            }

        }
        
    }

    public void ResetList()
    {
        CollectiblesFound = 0;
        noteBook.NoteBookList.CollectiblesList.Add(new Page());
        index2++;
        noteBook.NoteBookList.CollectiblesList[index2].PageList = new List<ScriptableObject>();
    }
}
