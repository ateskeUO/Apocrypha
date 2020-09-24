using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableButton : MonoBehaviour
{
    [SerializeField] private GameObject thePanel;

    public void TurnOffTextPanel()
    {
        //This is an invisible button above the table that acts to dismiss the panel when 'blank space' is clicked.
        thePanel.SetActive(false);
    }
}
