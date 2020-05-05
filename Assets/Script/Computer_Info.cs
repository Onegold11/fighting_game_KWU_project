using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer_Info : MonoBehaviour
{
    //이름
    public string userName
    {
        get;
        set;
    }
    //캐릭터 선택
    public int charSelect
    {
        get;
        set;
    }
    //승리
    public int winScore
    {
        get;
        set;
    }
    //패배
    public int loseScore
    {
        get;
        set;
    }
    //난이도
    public int level
    {
        get;
        set;
    }
    //초기화
    public Computer_Info()
    {
        userName = "COM";
        charSelect = 1;
        winScore = 0;
        loseScore = 0;
        level = 1;
    }
    //화면이 넘어가도 오브젝트가 삭제되지 않는 코드
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
