using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject InteractText;

    private Vector3 origin, direction;
    private bool interactionHit;
    private float currentHitDistance;
    [SerializeField] private float sphereRadius;
    [SerializeField] private int InteractReach = 10;
    private RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        CheckInteractable();
    }

    private void CheckInteractable()
    {

        origin = transform.position;
        direction = transform.forward;

        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, InteractReach))
        {
            currentHitDistance = hit.distance;
            interactionHit = true;

            if (hit.collider.gameObject.GetComponentInParent<IInteractable>() != null)
            {
                Debug.Log("You've hit something interactable!");
                InteractText.gameObject.SetActive(true);

                InteractWith();
            }
        }
        else
        {
            Debug.Log("Nothing!");
            InteractText.gameObject.SetActive(false);
            interactionHit = false;
        }



    }

    private void InteractWith()
    {
        if (interactionHit == true && Input.GetKeyDown(KeyCode.E))
        {
            hit.collider.gameObject.GetComponentInParent<IInteractable>().Interact();
        }
    }
}
