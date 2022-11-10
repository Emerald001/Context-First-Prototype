using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public Transform CanvasTransform;

    Vector3 offset;
    CanvasGroup canvasGroup;
    public string destinationTag = "DropArea";
    float x;
    float y;
    float z;
    Vector3 pos;
    RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        x = Random.Range(1100, 1400);
        y = Random.Range(-150, -900);
        z = 2;
        pos = new Vector3(x, y, z);
        rectTransform.position = pos;
    }
    void Awake()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
            gameObject.AddComponent<CanvasGroup>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();

    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begind drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(CanvasTransform);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DRAGGING");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = transform.position - Input.mousePosition;
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("Begind drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(CanvasTransform);
        transform.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RaycastResult raycastResult = eventData.pointerCurrentRaycast;
        if (raycastResult.gameObject?.tag == destinationTag)
        {
            transform.position = raycastResult.gameObject.transform.position;
        }
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
    }
}
