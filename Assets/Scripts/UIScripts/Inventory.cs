using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int invenSize = 9;
    public GameObject [] slotArray;
    public Slot slot;

    private void Awake()
    {
        slotArray = new GameObject[9];
    }


}
