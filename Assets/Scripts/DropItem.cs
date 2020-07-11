using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    //public Item itemOption;
    public bool isDropItem;


    private void OnDisable()
    {
        if (isDropItem)
        {
            Debug.Log("drop");
            Drop();
        }
    }

    void Drop()
    {
        int tmp = Random.Range(0,ItemData.instance.itemsData.Count);

        //Debug.Log(ItemData.instance.itemsData[tmp].name);
        //Debug.Log(ItemData.instance.itemsData[tmp].option.plusDamage);
        //Debug.Log(ItemData.instance.itemsData[tmp].option.plusDefense);
        //Debug.Log(ItemData.instance.itemsData[tmp].option.plusCritical);

        GameObject item = ObjectPool.instance.PullOfObjectPool(ObjectPool.instance.pool[1]);
        item.GetComponent<SpriteRenderer>().sprite = ItemData.instance.itemsData[tmp].spriteImage;
        item.GetComponent<ItemOption>().Item.spriteImage = ItemData.instance.itemsData[tmp].spriteImage;
        item.GetComponent<ItemOption>().Item.name = ItemData.instance.itemsData[tmp].name;
        item.GetComponent<ItemOption>().Item.option.plusDamage = ItemData.instance.itemsData[tmp].option.plusDamage;
        item.GetComponent<ItemOption>().Item.option.plusDefense = ItemData.instance.itemsData[tmp].option.plusDefense;
        item.GetComponent<ItemOption>().Item.option.plusCritical = ItemData.instance.itemsData[tmp].option.plusCritical;




    }


}
