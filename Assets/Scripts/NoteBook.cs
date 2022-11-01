using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBook : MonoBehaviour
{
    //public GameObject prefab;
    public Transform NoteBookCollectibleParent;
    private bool toggleBool;



    public List<ScriptableObject> CollectiblesList = new List<ScriptableObject>();
    // Start is called before the first frame update
    void Start()
    {
        NoteBookCollectibleParent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleBool = !toggleBool;
            NoteBookCollectibleParent.gameObject.SetActive(toggleBool);
        }

    }

    public void AddCollectibleToNoteBook(ScriptableObject objectToAdd)
    {
        //prefab.GetComponent<CollectibleDisplay>().collectible = (Collectible)objectToAdd;
        //Instantiate(prefab, NoteBookCollectibleParent);
        
    }

    public void CreateBook()
    {

    }
}
