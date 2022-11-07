using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Page
{
    public List<ScriptableObject> PageList;
}

[System.Serializable]
public class CollectiblePagesList
{
    public List<Page> CollectiblesList;
}
