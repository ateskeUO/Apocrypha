using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionBox : MonoBehaviour
{

    [SerializeField] public Text descriptionText;
    [SerializeField] private GameObject[] itemInSlot;
    [SerializeField] private Text[] itemDescription;

    [Header("Drop Boxes")]
    [SerializeField] private GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WritePanelText(string newText, int numberOfPanels)
    {
        // Set the box's text based on an inputed string, make exactly the specified number of slots available.

        descriptionText.text = newText;

        // Run through all the slots and make sure they are all turned off.
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].SetActive(false);
        }

        // Run through as many slots as need to be turned on, turn them on. Sensually.
        for(int i = 0; i < numberOfPanels; i++)
        {
            slots[i].SetActive(true);
        }
    }
}
