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
        descriptionText.text = newText;
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].SetActive(false);
        }

        for(int i = 0; i < numberOfPanels; i++)
        {
            slots[i].SetActive(true);
        }
    }
}
