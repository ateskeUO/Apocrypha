using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableButton : MonoBehaviour
{
    [SerializeField] private GameObject thePanel;

    public void TurnOffTextPanel()
    {
        thePanel.SetActive(false);
    }
}
