using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBook : MonoBehaviour
{
    public GameObject Collectibleprefab;
    public GameObject CluePrefab;
    public GameObject CodexPrefab;
    public Transform NoteBookCollectibleParent;
    public Transform NoteBookClueParent;
    public Transform NoteBookCodexParent;
    public Transform ToggleParent;

    public int codexPages;
    public int collectiblesPages;

    public int codexPageNumber;
    public int collectiblePageNumber;
    public bool clueActive = false;
    [HideInInspector] public bool BookActive;

    public CollectiblePagesList NoteBookCollectiblesList = new CollectiblePagesList();
    public List<TakeClue> NoteBookClueList = new List<TakeClue>();
    public CodexPageList NoteBookCodexList = new CodexPageList();
    
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
        NoteBookCodexParent.gameObject.SetActive(false);
        ToggleParent.gameObject.SetActive(false);
        currentPage = 0;
        BookActive = false;
        prefabList = new List<GameObject>();
        NoteBookCollectiblesList.CollectiblesList.Add(new Page());
        NoteBookCollectiblesList.CollectiblesList[0].PageList = new List<ScriptableObject>();

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
        codexPages = NoteBookCodexList.CodexList.Count;
        collectiblesPages = NoteBookCollectiblesList.CollectiblesList.Count;
       
        if (Input.GetKeyDown(KeyCode.Escape) && BookActive == false)
        {
            ToggleParent.gameObject.SetActive(true);
            ResetPage();
            GoToCollectibles();
            BookActive = true;
            collectiblePageNumber = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && BookActive == true)
        {
            ToggleParent.gameObject.SetActive(false);
            //UpdatePages();
            BookActive = false;
        }
    }


    //Clears everything from the page, and adds the items from the current page
    public void ResetPage()
    {
            foreach (GameObject prefabItem in prefabList){
                Destroy(prefabItem);
            }

            prefabList.RemoveAll(GameObject => GameObject == null);
            prefabList.Clear();
            CurrentPageList.Clear();
    }
    public void GoToCollectibles()
    {
            NoteBookCollectibleParent.gameObject.SetActive(true);
            NoteBookClueParent.gameObject.SetActive(false);
            NoteBookCodexParent.gameObject.SetActive(false);



            CurrentPageList.Add(NoteBookCollectiblesList.CollectiblesList[currentPage]);

            foreach (Collectible item in CurrentPageList[0].PageList)
            {
                Collectibleprefab.GetComponent<CollectibleDisplay>().collectible = (Collectible)item;
                TempPrefab = Instantiate(Collectibleprefab, NoteBookCollectibleParent);
                prefabList.Add(TempPrefab);
            }
        
    }
    public void ToggleClueFound(ScriptableObject clueding)
    {
        //clueding.

    }

    public void GoToCluePage()
    {
        NoteBookCollectibleParent.gameObject.SetActive(false);
        NoteBookClueParent.gameObject.SetActive(true);
        NoteBookCodexParent.gameObject.SetActive(false);

        foreach (TakeClue clue in NoteBookClueList)
        {
            Clue ClueToAdd = (Clue)clue.scriptableObject;
            CluePrefab.GetComponent<InventorySlot>().ClueScriptableObject = ClueToAdd;
            CluePrefab.GetComponent<InventorySlot>().Clue.SetActive(true);
            TempPrefab = Instantiate(CluePrefab, NoteBookClueParent);
            prefabList.Add(TempPrefab);

            if (clue.ClueFound == true)
            {
                CluePrefab.GetComponent<InventorySlot>().Clue.SetActive(true);
            }
        }
    }

    public void GoToCodex()
    {
        NoteBookCollectibleParent.gameObject.SetActive(false);
        NoteBookClueParent.gameObject.SetActive(false);
        NoteBookCodexParent.gameObject.SetActive(true);

        foreach (GameObject prefabItem in prefabList)
        {
            Destroy(prefabItem);
        }

        prefabList.RemoveAll(GameObject => GameObject == null);
        prefabList.Clear();
        CurrentPageList.Clear();

        CurrentPageList.Add(NoteBookCodexList.CodexList[currentPage - NoteBookCollectiblesList.CollectiblesList.Count -1]);
        foreach (Codex item in CurrentPageList[0].PageList)
        {
            CodexPrefab.GetComponent<CodexDisplay>().codex = item;
            TempPrefab = Instantiate(CodexPrefab, NoteBookCodexParent);
            prefabList.Add(TempPrefab);
            Debug.Log("Adding prefab codex");
        }
    }

    //Puts all Collectibles in lists of 6 and makes a new page at every 7th item
    public void ManageCollectibles(ScriptableObject scriptableObject)
    {
        CollectiblesFound++;

        if (CollectiblesFound <= 6)
        {
            int index = NoteBookCollectiblesList.CollectiblesList.Count - 1;
            NoteBookCollectiblesList.CollectiblesList[index].PageList.Add(scriptableObject);

            if (CollectiblesFound >= 6)
            {
                ResetList();
            }
        }
    }


    //Makes the new page for the 7th collectible
    public void ResetList()
    {
        CollectiblesFound = 0;
        NoteBookCollectiblesList.CollectiblesList.Add(new Page());
        index2++;
        NoteBookCollectiblesList.CollectiblesList[index2].PageList = new List<ScriptableObject>();
    }

    //Page buttons
    public void PageRight()
    {
        ResetPage();

        if (collectiblePageNumber < collectiblesPages && collectiblesPages != 1)
        {
            collectiblePageNumber++;
            currentPage++;
            Debug.Log("Page right going to Collectibles");
            GoToCollectibles();
        }
        else if(collectiblePageNumber == collectiblesPages && clueActive == false)
        {
            clueActive = true;
            collectiblePageNumber++;
            currentPage++;
            Debug.Log("Page right going to Clue");
            GoToCluePage();
        }
        else if(codexPageNumber != codexPages)
        {
            clueActive = false;
            currentPage++;
            Debug.Log("Page right going to Codex");
            GoToCodex();
            codexPageNumber++;
        }
        if(codexPageNumber == codexPages)
        {
            Debug.Log("END");
        }
    }

    public void PageLeft()
    {
        if (codexPageNumber > 1)
        {
            Debug.Log("Codex, left");
            codexPageNumber--;

            ResetPage();
            currentPage--;
            GoToCodex();
        }
        else if(codexPageNumber == 1)
        {
            clueActive = true;
            codexPageNumber--;
            collectiblePageNumber--;

            ResetPage();
            currentPage--;
            Debug.Log("Page left going to clue");
            GoToCluePage();
        }
        else if(collectiblePageNumber <= collectiblesPages && currentPage >=1)
        {
            clueActive = false;
            collectiblePageNumber--;
            ResetPage();
            currentPage--;
            Debug.Log("Page left going to collectibles");
            if(currentPage == 0)
            {
                collectiblePageNumber = 1;
            }
            GoToCollectibles();
        }
    }
}
