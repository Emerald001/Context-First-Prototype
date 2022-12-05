using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    bool BookActive;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && BookActive == false)
        {
          //  ToggleParent.gameObject.SetActive(true);
            BookActive = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && BookActive == true)
        {
           // ToggleParent.gameObject.SetActive(false);
            //UpdatePages();
            BookActive = false;
        }
    }


}
