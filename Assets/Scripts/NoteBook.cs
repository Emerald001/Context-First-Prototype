using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBook : MonoBehaviour
{
    public GameObject prefab;
    public Transform NoteBookCollectibleParent;
    public Transform ToggleParent;
    public bool BookActive;
    public CollectiblePagesList NoteBookList = new CollectiblePagesList();
    public List<Page> CurrentPageList = new List<Page>();
    public List<GameObject> prefabList = new List<GameObject>();

    public int currentPage;
    private bool BookCreated;
    private GameObject TempPrefab;
    public int CollectiblesFound;
    private int index2;

    //public List<ScriptableObject> CollectiblesList = new List<ScriptableObject>();
    // Start is called before the first frame update
    void Start()
    {
        ToggleParent.gameObject.SetActive(false);
        currentPage = 0;
        BookActive = false;
        prefabList = new List<GameObject>();

        NoteBookList.CollectiblesList.Add(new Page());
        NoteBookList.CollectiblesList[0].PageList = new List<ScriptableObject>();

        CollectiblesFound = 0;
        index2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && BookActive == false)
        {
            ToggleParent.gameObject.SetActive(true);
            UpdatePages();
            BookActive = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && BookActive == true)
        {
            ToggleParent.gameObject.SetActive(false);
            UpdatePages();
            BookActive = false;
        }
    }

    public void AddCollectibleToNoteBook(ScriptableObject objectToAdd)
    {
        CurrentPageList.Clear();
        CurrentPageList.Add(NoteBookList.CollectiblesList[0]);
        prefab.GetComponent<CollectibleDisplay>().collectible = (Collectible)objectToAdd;
        Instantiate(prefab, NoteBookCollectibleParent);
    }

    public void UpdatePages()
    {

        foreach (GameObject prefabItem in prefabList)
        {
            Destroy(prefabItem);
        }

        prefabList.RemoveAll(GameObject => GameObject == null);
        prefabList.Clear();
        CurrentPageList.Clear();

        if(prefabList.Count == 0)
        {
            CurrentPageList.Add(NoteBookList.CollectiblesList[currentPage]);

            foreach (Collectible item in CurrentPageList[0].PageList)
            {
                prefab.GetComponent<CollectibleDisplay>().collectible = (Collectible)item;
                TempPrefab = Instantiate(prefab, NoteBookCollectibleParent);
                prefabList.Add(TempPrefab);
            }
        }
    }

    public void ManageCollectibles(ScriptableObject scriptableObject)
    {
        CollectiblesFound++;

        if (CollectiblesFound <= 6)
        {
            int index = NoteBookList.CollectiblesList.Count - 1;
            NoteBookList.CollectiblesList[index].PageList.Add(scriptableObject);

            if (CollectiblesFound >= 6)
            {
                ResetList();
            }
        }
    }

    public void ResetList()
    {
        CollectiblesFound = 0;
        NoteBookList.CollectiblesList.Add(new Page());
        index2++;
        NoteBookList.CollectiblesList[index2].PageList = new List<ScriptableObject>();
    }


    public void PageRight()
    {
        Debug.Log(NoteBookList.CollectiblesList.Count);
        if(currentPage < NoteBookList.CollectiblesList.Count -1)
        {   
            currentPage++;
            UpdatePages();
        }

    }

    public void PageLeft()
    {
        if(currentPage > 0)
        {
            currentPage--;
            UpdatePages();

        }
    }
}
