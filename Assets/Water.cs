using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject respawnPoint;
    

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = respawnPoint.transform.position;
        
    }
}
