using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHolder : MonoBehaviour
{
    public List<Collectible> CollectibleList = new List<Collectible>();
    public GameObject CollectiblePrefab;
    //public Transform PrefabSpawnLocation;

    public void Start()
    {
        foreach (Collectible coll in CollectibleList)
        {
            CollectiblePrefab.GetComponent<CollectibleDisplay>().collectible = coll;
            
            var tmp = Instantiate(CollectiblePrefab, gameObject.transform);
        }
    }
}
