using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    // Every box needs to have a name as well as the ability to summon the panel, change its text, and number of slots available.

    [SerializeField] private GameObject panel;
    [SerializeField] private string name;
    [SerializeField] private string boxDescription;
    [SerializeField] private Text panelText;
    [SerializeField] private Text nameText;

    [SerializeField] private int numberOfSlots;
    [SerializeField] private float panelOffset;

    // Start is called before the first frame update
    public virtual void Start()
    {
        nameText.text = name;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void OpenTextPanel()
    {
        //A button floats above every box that when pressed will activate the panel and set its text as well as number of slots available.
        panel.transform.position = new Vector3(transform.position.x, panelOffset, transform.position.z);
        panel.GetComponent<DescriptionBox>().WritePanelText(boxDescription, 1);
        panel.SetActive(true);
    }
}
