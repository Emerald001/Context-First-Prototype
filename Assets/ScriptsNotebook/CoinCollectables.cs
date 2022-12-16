using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollectables : MonoBehaviour
{

    private int coinsFound;
    private int maxCoins;

    public TMP_Text textCoinsFound;
    // Start is called before the first frame update
    void Start()
    {
        Coin[] coinArray = FindObjectsOfType<Coin>();
        foreach (Coin coin in coinArray)
        {
            maxCoins++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        textCoinsFound.text = coinsFound.ToString() + " / "+ maxCoins.ToString() + " Coins Found" ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Coin>() != null)
        {
            coinsFound++;
            Debug.Log("I'VE FOUND " + coinsFound + " Coins out of " + maxCoins + " Coins");
            Destroy(other.gameObject);
        }
    }
}
