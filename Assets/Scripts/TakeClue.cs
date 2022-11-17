using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeClue : MonoBehaviour, IInteractable
{
    public ScriptableObject scriptableObject;
    public NoteBook noteBook;

    public bool ClueFound = false;

    public void Interact()
    {
        noteBook.ToggleClueFound(scriptableObject);
        ClueFound = true;
    }
}
