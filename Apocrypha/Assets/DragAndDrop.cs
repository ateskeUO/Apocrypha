using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private float zPosition;
    private Vector3 offset;
    public Camera mainCamera;
    [SerializeField] private bool dragging;
    [SerializeField] private GameObject[] anchorPoints;
    [SerializeField] private GameObject[] anchorBoxes;
    [SerializeField] private GameObject center;
    [SerializeField] int pickupOffset;
    private Collider[] anchorColliders;
    [SerializeField] private bool inSlot;
    private bool validPosition;
    private Vector3 lastKnownPosition;
    private float initialHeight;

    [SerializeField]
    public UnityEvent OnBeginDrag;
    [SerializeField]
    public UnityEvent OnEndDrag;


    void Start()
    {
        mainCamera = Camera.main;
        initialHeight = transform.position.y;
        lastKnownPosition = transform.position;
    }

    void Update()
    {
        zPosition = mainCamera.WorldToScreenPoint(transform.position).z;

        if (dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPosition);
            transform.position = mainCamera.ScreenToWorldPoint(position + new Vector3(offset.x, offset.y));
        }

    }

    void OnMouseDown()
    {
        if (!dragging)
        {
            BeginDrag();
        }
    }

    void OnMouseUp()
    {
        EndDrag();

    }

    public void BeginDrag()
    {
        inSlot = false;
        lastKnownPosition = transform.position;
        OnBeginDrag.Invoke();
        dragging = true;
        offset = mainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
        transform.position += new Vector3(0, pickupOffset, 0);
    }

    public void EndDrag()
    {

        OnEndDrag.Invoke();
        dragging = false;
        
        for(int i = 0; i < anchorBoxes.Length; i++)
        {
            if (anchorBoxes[i].GetComponent<Collider>().bounds.Contains(center.transform.position))
            {
                transform.position = anchorPoints[i].transform.position;
                Debug.Log("Object is in Rectangle: " + i);
                inSlot = true;

            }
        }

        if (!inSlot)
        {
            transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
        }
    }

    public void ReturnItem()
    {
        transform.position = lastKnownPosition;
    }
}
