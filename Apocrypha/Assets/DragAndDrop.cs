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
        // Keep z position of the dragged object constant
        zPosition = mainCamera.WorldToScreenPoint(transform.position).z;

        // If dragging, make the position of the dragged object equal to the (x, y) of the mouse on the screen
        if (dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPosition);
            transform.position = mainCamera.ScreenToWorldPoint(position + new Vector3(offset.x, offset.y));
        }

    }

    void OnMouseDown()
    {
        // When mouse button is depressed, give it zoloft and begin dragging procedures
        if (!dragging)
        {
            BeginDrag();
        }
    }

    void OnMouseUp()
    {
        // When mouse is lifted up, congratulate it and start end of dragging procedures
        EndDrag();

    }

    public void BeginDrag()
    {
        // The object is by definition not in a slot, but we need to remember the position it was in before picking it up.
        // Begin dragging the object and define offset to be the difference between WorldToScreenPoint and the current mousePosition
        // Give the object some extra height for a "feeling" of being picked up

        inSlot = false;
        lastKnownPosition = transform.position;
        OnBeginDrag.Invoke();
        dragging = true;
        offset = mainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
        transform.position += new Vector3(0, pickupOffset, 0);
    }

    public void EndDrag()
    {
        // Drop object, no longer dragging. Run through every slot available, if the object was dropped within the bounds of the slot, drop it in the slot.
        // If the object wasn't dropped anywhere in particular, set it down where it lies. Perhaps in future create a grid of empty objects that it snaps to when not in a slot.

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
        // Put that back you don't know where it's been.
        transform.position = lastKnownPosition;
    }
}
