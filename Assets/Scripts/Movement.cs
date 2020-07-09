using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected CharacterState characterState;

    protected virtual void Awake()
    {
        if (GetComponent<CharacterState>() == null)
        {
            gameObject.AddComponent<CharacterState>();
        }
        characterState = GetComponent<CharacterState>();
    }
    // 방향 전환
    public void Flip()
    {
        // 오브젝트 반전
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        // 시선 정보 변경
        characterState._isRightDir = !characterState._isRightDir;
    }
}
