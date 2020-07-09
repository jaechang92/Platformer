using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class xVector2
{
    public float EndOfLeft;
    public float EndOfRight;
    public float Center;
}


public class EndOfMapCheck : MonoBehaviour
{
    public static EndOfMapCheck instance;
    
    public bool isGround = false;

    public GameObject beforeGround = null;
    
    public xVector2 xVector = new xVector2();

    private float halfSize;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        halfSize = this.gameObject.GetComponent<BoxCollider2D>().size.x / 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGround = true;

            if (beforeGround != collision.gameObject)
            {
                beforeGround = collision.gameObject;
                Bounds bounds = beforeGround.GetComponent<CompositeCollider2D>().bounds;
                xVector.Center = bounds.center.x;
                xVector.EndOfLeft = -bounds.extents.x + xVector.Center + halfSize;
                xVector.EndOfRight = bounds.extents.x + xVector.Center - halfSize;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGround = false;
        }
    }
}
