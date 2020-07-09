using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : Movement
{
    // public 변수
    public float moveSpeed;

    public Vector2 timeRandomRage;
    public float trunTime;

    // private 변수
    float currentTime;
    Transform tr;

    
    bool isGround;
    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        tr = GetComponent<Transform>();
    }
    
    private void Update()
    {
        RandTrun();



        MonsterMove();
    }

    private void RandTrun()
    {
        // 일정 시간이 누적되면 턴을 실행 턴을 했으면 시간 초기화
        currentTime += Time.deltaTime;
        if (currentTime > trunTime)
        {
            Trun();
            trunTime = Random.Range(timeRandomRage.x, timeRandomRage.y);
        }


        // 맵끝에가면 턴
        if (tr.position.x > EndOfMapCheck.instance.xVector.EndOfRight && moveSpeed > 0)
        {
            Trun();
        }
        else if (tr.position.x < EndOfMapCheck.instance.xVector.EndOfLeft && moveSpeed < 0)
        {
            Trun();
        }


    }
    
    void MonsterMove()
    {
        isGround = EndOfMapCheck.instance.isGround;
        if (isGround)
        {
            Debug.Log("Target = " + tr.position + Vector3.right * moveSpeed);
            tr.position = Vector3.MoveTowards(tr.position, tr.position + Vector3.right * moveSpeed, Time.deltaTime * Mathf.Abs(moveSpeed));
        }
    }

    void Trun()
    {
        moveSpeed = -moveSpeed;
        Flip();
        currentTime = 0;
    }


}
