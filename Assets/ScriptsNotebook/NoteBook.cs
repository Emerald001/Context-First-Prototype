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

    public int collectiblesPages;
    [HideInInspector] public int codexPages;
    [HideInInspector] public int maxPages;
    [HideInInspector] public int ClueTreshhold;
    [HideInInspector] public int codexPageNumber;
    [HideInInspector] public int collectiblePageNumber;
    [HideInInspector] public bool clueActive = false;
    [HideInInspector] public bool BookActive;
    [HideInInspector] public int CollectiblesFound;

    public CodexPageList NoteBookCodexList = new CodexPageList();
    [HideInInspector] public CollectiblePagesList NoteBookCollectiblesList = new CollectiblePagesList();
    [HideInInspector] public List<TakeClue> NoteBookClueList = new List<TakeClue>();

    [HideInInspector] public List<Page> CurrentPageList = new List<Page>();
    public List<GameObject> prefabList = new List<GameObject>();
    [HideInInspector] public List<GameObject> ClueListPrefab = new List<GameObject>();

    public int currentPage;
    private GameObject TempPrefab;
    private int index2;
    private bool CluesMade = false;
    private bool max;
    private GoToClues goToClues;
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
        goToClues = GetComponent<GoToClues>();

        TakeClue[] FindClues = FindObjectsOfType<TakeClue>();
        foreach (TakeClue clue in FindClues){
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
        maxPages = codexPages + collectiblesPages;
        ClueTreshhold = codexPages - 1;

        ActivateBook();
    }

    public void ActivateBook()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && BookActive == false){
            currentPage = 0;
            codexPageNumber = 0;
            collectiblePageNumber = 0;
            ToggleParent.gameObject.SetActive(true);
            ResetPage();
            GoToCluePage();
            BookActive = true;
            //collectiblePageNumber = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && BookActive == true){
            ToggleParent.gameObject.SetActive(false);
            ResetPage();
            //UpdatePages();
            BookActive = false;
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && BookActive == true){
            PageLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && BookActive == true){
            PageRight();
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

            if(CollectiblesFound > 0){
                CurrentPageList.Add(NoteBookCollectiblesList.CollectiblesList[currentPage -1]);
                foreach (Collectible item in CurrentPageList[0].PageList){
                    Collectibleprefab.GetComponent<CollectibleDisplay>().collectible = (Collectible)item;
                    TempPrefab = Instantiate(Collectibleprefab, NoteBookCollectibleParent);
                    prefabList.Add(TempPrefab);
                }
            }
    }
   
    public void GoToCluePage()
    {
        
        NoteBookCollectibleParent.gameObject.SetActive(false);
        NoteBookClueParent.gameObject.SetActive(true);
        NoteBookCodexParent.gameObject.SetActive(false);
        goToClues.ShowClues();

        
        //if (ClueListPrefab.Count != NoteBookClueList.Count){
        //    foreach (TakeClue clue in NoteBookClueList){
        //        Clue ClueToAdd = (Clue)clue.scriptableObject;
        //        CluePrefab.GetComponent<InventorySlot>().ClueScriptableObject = ClueToAdd;
        //        TempPrefab = Instantiate(CluePrefab, NoteBookClueParent);
        //        ClueListPrefab.Add(TempPrefab);
        //    }
        //}
    }

    public void GoToCodex()
    {
        NoteBookCollectibleParent.gameObject.SetActive(false);
        NoteBookClueParent.gameObject.SetActive(false);
        NoteBookCodexParent.gameObject.SetActive(true);

        foreach (GameObject prefabItem in prefabList){
            Destroy(prefabItem);
        }

        prefabList.RemoveAll(GameObject => GameObject == null);
        prefabList.Clear();
        CurrentPageList.Clear();

        CurrentPageList.Add(NoteBookCodexList.CodexList[currentPage - NoteBookCollectiblesList.CollectiblesList.Count -1]);
        foreach (Codex item in CurrentPageList[0].PageList){
            CodexPrefab.GetComponent<CodexDisplay>().codex = item;
            TempPrefab = Instantiate(CodexPrefab, NoteBookCodexParent);
            prefabList.Add(TempPrefab);
            //Debug.Log("Adding prefab codex");
        }
    }

    //Puts all Collectibles in lists of 6 and makes a new page at every 7th item
    public void ManageCollectibles(ScriptableObject scriptableObject)
    {
        CollectiblesFound++;

        if (CollectiblesFound <= 6){
            int index = NoteBookCollectiblesList.CollectiblesList.Count - 1;
            NoteBookCollectiblesList.CollectiblesList[index].PageList.Add(scriptableObject);

            if (CollectiblesFound >= 6){
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
        if(currentPage < 0)
        {
            ResetPage();
            currentPage++;
            GoToCluePage();
        }
        else if(currentPage == 0){
            ResetPage();
            codexPageNumber = 0;
            collectiblePageNumber++;
            currentPage++;
            Debug.Log("Page right going to Collectibles");
            GoToCollectibles();
            max = false;
        }
        else if(currentPage >= 1 && collectiblePageNumber < collectiblesPages)
        {
            ResetPage();
            codexPageNumber = 0;
            collectiblePageNumber++;
            currentPage++;
            Debug.Log("Page right going to Collectibles");
            GoToCollectibles();
            max = false;
        }
        else if (collectiblePageNumber == collectiblesPages && max == false){
            clueActive = false;
            ResetPage();
            currentPage++;
            Debug.Log("Page right going to Codex");
            GoToCodex();
            codexPageNumber++;
            max = false;
        }
        if (codexPageNumber == codexPages){
            max = true;
            Debug.Log("END");
        }
    }

    public void PageLeft()
    {
        if(currentPage <= 0)
        {
            ResetPage();
            currentPage--;
            GoToCluePage();
        }
        if(currentPage > 0){
            if (codexPageNumber > 1)
            {
                ResetPage();
                Debug.Log("Codex, left");
                codexPageNumber--;

                currentPage--;
                GoToCodex();
            }
            else if (codexPageNumber == 1 && collectiblePageNumber > 0)
            {
                ResetPage();
                clueActive = false;
                collectiblePageNumber--;
                currentPage--;
                Debug.Log("Page left going to collectibles");
                GoToCollectibles();
            }
            else if (currentPage == 1){
                ResetPage();
                clueActive = true;
                codexPageNumber--;
                collectiblePageNumber--;

                currentPage--;
                Debug.Log("Page left going to clue");
                GoToCluePage();
                collectiblePageNumber = 0;
                codexPageNumber = 0;
            }
        }
    }

    public void ClueBookmark()
    {
        currentPage = 0;
        codexPageNumber = 0;
        collectiblePageNumber = 0;
        ResetPage();
        GoToCluePage();
    }
    public void CollectiblesBookmark()
    {
        currentPage = 1;
        collectiblePageNumber = 1;
        codexPageNumber = 0;
        clueActive = false;
        ResetPage();
        GoToCollectibles();

    }
    public void CodexBookmark()
    {
        currentPage = collectiblesPages + 1;
        codexPageNumber = 1;
        collectiblePageNumber = collectiblesPages;
        clueActive = false;
        ResetPage();
        GoToCodex();
    }
}
