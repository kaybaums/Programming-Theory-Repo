using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBlock : MonoBehaviour
{
    private BuildingUI buildingUI;

    private void Start()
    {
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
    }

    private void OnMouseEnter()
    {
        buildingUI.isBlocked = true;
    }

    private void OnMouseExit()
    {
        buildingUI.isBlocked = false;
    }
}
