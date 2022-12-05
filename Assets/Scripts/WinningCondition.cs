using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{
    public List<GameObject> CorrectAnswers = new List<GameObject>();
    private NoteBook noteBook;

    void Start()
    {
        noteBook = GetComponent<NoteBook>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CorrectAnswers.Count >= noteBook.NoteBookClueList.Count)
        {
            Debug.Log("YOU WIN");
        }
    }
}
