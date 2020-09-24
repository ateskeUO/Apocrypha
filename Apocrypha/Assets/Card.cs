using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private float timer = 0;

    // Every card needs a name, a list of tags it has, and the ability to hold a timer with a variable amount of time.
    // Individual cards will need definitions for what happens when their timer runs out as well as definitions for what cards they can turn into.

    [SerializeField] private string name;
    [SerializeField] private float timeLeft;
    [SerializeField] private float startingTime;
    [SerializeField] private float panelOffset;
    [SerializeField] private float timerMultiplier = 1;
    [SerializeField] public string[] keywords;

    [SerializeField] private Text nameText;
    [SerializeField] private Text timerText;
    [SerializeField] private Image cardImage;
    [SerializeField] public GameObject panel;
    [SerializeField] private Text panelText;
    [SerializeField] private string cardDescription;

    // Start is called before the first frame update
    void Start()
    {
        // Set name text
        nameText.text = name;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //If a card has a clock, tick it down
        timer += timerMultiplier * Time.deltaTime;
        timeLeft = startingTime - timer;
        timerText.text = timeLeft.ToString("0.0");
    }

    // Old code, cards no longer open text panel, but will need to add a description to a UI box in the future.
    /*
    public void OpenTextPanel()
    {
        panel.transform.position = new Vector3(transform.position.x, panelOffset, transform.position.z);
        panel.GetComponent<DescriptionBox>().WritePanelText(cardDescription);
        panel.SetActive(true);
    }
    */
}
