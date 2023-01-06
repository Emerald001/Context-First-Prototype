using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public int currentCollectiblePage;
    public int numberOfPages;
    public ClueManager clueManager;
    public CodexManager Codex;

    private void OnEnable()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("TEST");
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCollectiblePage = 0;
        numberOfPages = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToNextCollectiblePage()
    {
        if (currentCollectiblePage != numberOfPages - 1)
        {
            Debug.Log("OI2");

            currentCollectiblePage++;
            gameObject.transform.GetChild(currentCollectiblePage).gameObject.SetActive(true);
            gameObject.transform.GetChild(currentCollectiblePage - 1).gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("OI");
        }
    }

    public void GoToPrevCollectiblePage()
    {
        if(currentCollectiblePage > 0)
        {
            currentCollectiblePage--;
            gameObject.transform.GetChild(currentCollectiblePage).gameObject.SetActive(true);
            gameObject.transform.GetChild(currentCollectiblePage + 1).gameObject.SetActive(false);
        }
        else
        {
            clueManager.CollectibleActive = false;
            clueManager.gameObject.transform.GetChild(clueManager.numberOfPages -1).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }


}
