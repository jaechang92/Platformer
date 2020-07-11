using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static ItemData instance;
    private void Awake()
    {
        instance = this;
    }


    public List<Item> itemsData;
}
