using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{

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
        panel.transform.position = new Vector3(transform.position.x, panelOffset, transform.position.z);
        panel.GetComponent<DescriptionBox>().WritePanelText(boxDescription, 1);
        panel.SetActive(true);
    }
}
