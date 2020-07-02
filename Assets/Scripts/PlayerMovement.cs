using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MoveData
{
    public float moveSpeed;
    public float jumpSpeed;
    public float damage;
    public int jumpCount;
    public bool isJump;
    public bool isDubleJump;
    public bool isGrounded;
    
}


public class PlayerMovement : MonoBehaviour
{
    public MoveData moveData = new MoveData();
    

    Rigidbody m_physics;
    Transform m_tr;

    public Vector3 m_velocity;
    float horizontal;
    float vertical;
    public Vector3 target = Vector3.zero;
    void Start()
    {
        m_tr = this.GetComponent<Transform>();
        m_physics = this.GetComponent<Rigidbody>();
        

    }



    void Update()
    {
        MoveFunc();
        m_tr.position = Vector3.MoveTowards(m_tr.position, target, Time.deltaTime * constF);

        

    }

#if UNITY_ANDROID


#endif

    private void LateUpdate()
    {
        m_velocity = m_physics.velocity;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            moveData.isGrounded = true;
        }
        moveData.jumpCount = 2;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            moveData.isGrounded = false;
        }
    }

    public void MoveFunc()
    {
        horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
        JumpFunc();

        Dash();
        target = new Vector3(target.x + horizontal * moveData.moveSpeed * Time.deltaTime, m_tr.position.y, m_tr.position.z);
        

    }

    private void JumpFunc()
    {
        if (moveData.jumpCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_physics.velocity = m_physics.velocity + Vector3.up * moveData.jumpSpeed;
                Debug.Log("Input");
                moveData.jumpCount--;
            }
        }
    }


    public float constF;
    public float deltaTime;
    public KeyCode beforeKey = KeyCode.None;
    private void Dash()
    {
        deltaTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (beforeKey == KeyCode.RightArrow && deltaTime < 1.0f)
            {
                deltaTime++;
                target = new Vector3(m_tr.position.x + 5, target.y, target.z);
                
            }
            else
            {
                beforeKey = KeyCode.RightArrow;
                deltaTime = 0;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (beforeKey == KeyCode.LeftArrow && deltaTime < 1.0f)
            {
                deltaTime++;
                target = new Vector3(m_tr.position.x - 5, target.y, target.z);
            }
            else
            {
                beforeKey = KeyCode.LeftArrow;
                deltaTime = 0;
            }
        }
    }

    public void PressLeft()
    {
        Button btn = GetComponent<Button>();
        //btn.onClick.AddListener();
    }

    public void PressRight()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("OnTrigger");
            target = Vector3.zero;
            this.gameObject.transform.position = Vector3.zero;
        }
    }

}
