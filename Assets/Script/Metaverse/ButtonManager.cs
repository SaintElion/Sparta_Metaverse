using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    protected SceneChangeBttn[] sceneChangeBttn;
    protected void Start()
    {
        sceneChangeBttn = GetComponentsInChildren<SceneChangeBttn>(); //SceneChangBttn 스크립트가 있는 모든 오브젝트를 배열로 모아줌

        foreach (var bttn in sceneChangeBttn)
        {
            bttn.BttnUp();
        }
    }
}
