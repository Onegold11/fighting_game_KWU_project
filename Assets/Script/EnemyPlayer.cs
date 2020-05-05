using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour
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
    //초기화
    public EnemyPlayer()
    {
        userName = "";
        charSelect = 0;
        winScore = 0;
        loseScore = 0;
    }
    //화면이 넘어가도 오브젝트가 삭제되지 않는 코드
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
