using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveData
{
    public float moveSpeed;
    public float jumpSpeed;

}


public class PlayerMovement : MonoBehaviour
{
    public MoveData moveData = new MoveData();


    Rigidbody m_physics;
    Transform m_tr;

    public Vector3 m_velocity;
    float horizontal;
    float vertical;
    
    void Start()
    {
        m_tr = this.GetComponent<Transform>();
        m_physics = this.GetComponent<Rigidbody>();
        

    }



    void Update()
    {
        
#if UNITY_EDITOR

        horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_physics.velocity = m_physics.velocity + Vector3.up * moveData.jumpSpeed;
            Debug.Log("Input");
        }

#endif
        m_physics.velocity = new Vector3(horizontal*moveData.moveSpeed, m_physics.velocity.y);


    }

#if UNITY_ANDROID


#endif

    private void LateUpdate()
    {
        m_velocity = m_physics.velocity;
    }





}
