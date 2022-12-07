using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{
    public Canvas endcanvas;
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
            endcanvas.gameObject.SetActive(true);
            Debug.Log("YOU WIN");
        }
    }
}
