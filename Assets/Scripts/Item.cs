using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Option
{
    public float plusDamage;
    public float plusDefense;
    public float plusCritical;
}

[System.Serializable]
public class Item 
{
    public string name;
    public Sprite spriteImage;
    public Option option;

}
