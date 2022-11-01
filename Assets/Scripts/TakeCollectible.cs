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
        noteBook.CollectiblesList.Add(scriptableObject);
        noteBook.AddCollectibleToNoteBook(scriptableObject);
        Debug.Log("INTERACT");
    }
}
