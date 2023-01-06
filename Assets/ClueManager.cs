using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public int currentCluePage;
    public int numberOfPages;
    public bool CollectibleActive;
    public CollectibleManager collectibleManager;

    private void OnEnable()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCluePage = 0;
        numberOfPages = transform.childCount;
        CollectibleActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNextCluePage()
    {
        if(currentCluePage != numberOfPages -1)
        {
            currentCluePage++;
            gameObject.transform.GetChild(currentCluePage).gameObject.SetActive(true);
            gameObject.transform.GetChild(currentCluePage -1).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(currentCluePage).gameObject.SetActive(false);
            SwitchToCollectible();
        }
        
    }

    public void GoToPrevCluePage()
    {
        if (currentCluePage > 0 && CollectibleActive == false)
        {
            currentCluePage--;
            gameObject.transform.GetChild(currentCluePage).gameObject.SetActive(true);
            gameObject.transform.GetChild(currentCluePage + 1).gameObject.SetActive(false);
        }
        if(CollectibleActive == true)
        {
            collectibleManager.GoToPrevCollectiblePage();
        }
    }

    public void SwitchToCollectible()
    {
        collectibleManager.gameObject.SetActive(true);
        if(CollectibleActive == true)
        {

            Debug.Log("CLUE");
            collectibleManager.GoToNextCollectiblePage();
        }
        CollectibleActive = true;
    }
}
