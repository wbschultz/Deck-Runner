using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBase : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector3 mouseOffset;
    Transform _parent;

    // Start is called before the first frame update
    void Awake()
    {
        _parent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        mouseOffset = transform.position - mousePos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + mouseOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = _parent;
        transform.localPosition = Vector3.zero;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
