using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarManager : MonoBehaviour
{
    public GameObject autoSearch;
    public GameObject blurObject;

    private void Start()
    {
        autoSearch.SetActive(false);
        blurObject.SetActive(false);
    }

    public void SearchCountry()
    {
        blurObject.SetActive(true);
        autoSearch.SetActive(true);
    }

    public void SearchOnCompletion()
    {
        autoSearch.SetActive(false);
        blurObject.SetActive(false);
    }
}
