using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public float _hp;                         // 체력 상태
    public bool _isDie = false;             // 사망 여부
    public bool _isRightDir = false;       // 시선

    public enum State
    {
        Idle, // 대기
        Move, // 이동
        Attack, // 공격
        Damage, // 데미지
        Die // 사망
    };

    public State playerState;

    public State state
    {
        get
        {
            return this.playerState;
        }
        set
        {
            this.playerState = value;
        }
    }


}
