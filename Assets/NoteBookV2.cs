using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookV2 : MonoBehaviour
{
    public Transform ToggleParent;
    public ClueManager clueManager;
    [HideInInspector] public bool BookActive = false;

    // Start is called before the first frame update
    void Start()
    {
        ToggleParent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActivateBook();
    }

    public void ActivateBook()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && BookActive == false)
        {
            ToggleParent.gameObject.SetActive(true);
            BookActive = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && BookActive == true)
        {
            ToggleParent.gameObject.SetActive(false);
            BookActive = false;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && BookActive == true)
        {
            PageLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && BookActive == true)
        {
            PageRight();
        }
    }

    public void PageRight()
    {
        clueManager.GoToNextCluePage();
    }

    public void PageLeft()
    {
        clueManager.GoToPrevCluePage();
    }
}
