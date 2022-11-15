using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBook : MonoBehaviour
{
    public GameObject Collectibleprefab;
    public GameObject CluePrefab;
    public Transform NoteBookCollectibleParent;
    public Transform NoteBookClueParent;
    public Transform ToggleParent;

    [HideInInspector] public bool BookActive;
    public CollectiblePagesList NoteBookList = new CollectiblePagesList();
    
    public List<TakeClue> NoteBookClueList = new List<TakeClue>();
    
    public List<Page> CurrentPageList = new List<Page>();
    public List<GameObject> prefabList = new List<GameObject>();


    public int currentPage;
    private GameObject TempPrefab;
    public int CollectiblesFound;
    private int index2;

    // Start is called before the first frame update
    void Start()
    {
        NoteBookClueParent.gameObject.SetActive(false);
        ToggleParent.gameObject.SetActive(false);
        currentPage = 0;
        BookActive = false;
        prefabList = new List<GameObject>();
        NoteBookList.CollectiblesList.Add(new Page());
        NoteBookList.CollectiblesList[0].PageList = new List<ScriptableObject>();

        TakeClue[] FindClues = FindObjectsOfType<TakeClue>();
        foreach (TakeClue clue in FindClues)
        {
            NoteBookClueList.Add(clue);
        }
        CollectiblesFound = 0;
        index2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(NoteBookList.CollectiblesList.Count);
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


    //Clears everything from the page, and adds the items from the current page
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
                Collectibleprefab.GetComponent<CollectibleDisplay>().collectible = (Collectible)item;
                TempPrefab = Instantiate(Collectibleprefab, NoteBookCollectibleParent);
                prefabList.Add(TempPrefab);
            }
        }
    }

    public void GoToCluePage()
    {
        NoteBookClueParent.gameObject.SetActive(true);

        foreach (GameObject prefabItem in prefabList)
        {
            Destroy(prefabItem);
        }

        prefabList.RemoveAll(GameObject => GameObject == null);
        prefabList.Clear();
        CurrentPageList.Clear();

        foreach (TakeClue clue in NoteBookClueList)
        {
            Clue ClueToAdd = (Clue)clue.scriptableObject;
            CluePrefab.GetComponent<InventorySlot>().ClueScriptableObject = ClueToAdd;
            TempPrefab = Instantiate(CluePrefab, NoteBookClueParent);
            prefabList.Add(TempPrefab);
        }
    }

    //Puts all Collectibles in lists of 6 and makes a new page at every 7th item
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

    //Page buttons
    public void PageRight()
    {
        if(currentPage < NoteBookList.CollectiblesList.Count -1)
        {   
            currentPage++;
            UpdatePages();
        }
        else
        {
            currentPage++;
            Debug.Log("CLUEEEE");
            GoToCluePage();
        }
    }

    public void PageLeft()
    {
        if(currentPage > 0)
        {
            currentPage--;
            UpdatePages();
            NoteBookClueParent.gameObject.SetActive(false);
        }
    }
}
