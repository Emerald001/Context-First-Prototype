using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBook : MonoBehaviour
{
    public GameObject prefab;
    public Transform NoteBookCollectibleParent;
    public Transform ToggleParent;
    private bool toggleBool;
    public CollectiblePagesList NoteBookList = new CollectiblePagesList();
    public List<Page> CurrentPageList = new List<Page>();

    public int currentPage;
    private bool BookCreated;

    //public List<ScriptableObject> CollectiblesList = new List<ScriptableObject>();
    // Start is called before the first frame update
    void Start()
    {
        ToggleParent.gameObject.SetActive(false);
        currentPage = 0;
        BookCreated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleBool = !toggleBool;
            ToggleParent.gameObject.SetActive(toggleBool);

            if(BookCreated == false)
            {
                CurrentPageList.Add(NoteBookList.CollectiblesList[0]);
                BookCreated = true;
                
            }
        }

    }

    public void AddCollectibleToNoteBook(ScriptableObject objectToAdd)
    {

        for (int i = 0; i < CurrentPageList.Count; i++)
        {
            prefab.GetComponent<CollectibleDisplay>().collectible = (Collectible)objectToAdd;
            Instantiate(prefab, NoteBookCollectibleParent);
        }

    }

    public void PageRight()
    {
        currentPage++;
        CurrentPageList.Clear();
    }

    public void PageLeft()
    {
        currentPage--;
        CurrentPageList.Clear();
    }
}
