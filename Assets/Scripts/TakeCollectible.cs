using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCollectible : MonoBehaviour, IInteractable
{
    public ScriptableObject scriptableObject;

    public NoteBook noteBook;

    public void Start()
    {
        //noteBook = GetComponent<NoteBook>();
    }
    public void Interact()
    {
        //noteBook.CollectiblesList.Add(scriptableObject);
        noteBook.testlist.CollectiblesList.Add(new Page());
        int index = noteBook.testlist.CollectiblesList.Count - 1;

        noteBook.testlist.CollectiblesList[index].PageList = new List<ScriptableObject>();
        noteBook.testlist.CollectiblesList[index].PageList.Add(scriptableObject);

        //noteBook.AddCollectibleToNoteBook(scriptableObject);
        Debug.Log("INTERACT");
    }
}
