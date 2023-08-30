using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;

    void Start()
    {
        uiPanel.SetActive(true);
    }

    public void OpenPanel()
    {

    }

    public void ClosePanel()
    {

    }
}
