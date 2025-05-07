using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    protected override void Start() //상속받는 메서드에서도 protected 써줄 것
    {
        base.Start(); //부모 클래스의 Start() 먼저 실행

        runSpeed = 1.5f; //캐릭터별로 다르게
    }
}
