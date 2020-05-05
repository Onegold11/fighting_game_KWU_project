using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector_Result_Single_Win : MonoBehaviour
{
    // 플레이어 정보를 저장한 오브젝트, 여기서 정보를 얻을 수 있다.
    GameObject myInfo; // 내 정보
    GameObject enemyInfo; // 적 정보

    //UI 표시를 위한 Text, 실제 정보 아님
    public Text myName; //내 캐릭터 이름 텍스트
    public Text myWinNum; //내 승리 횟수 텍스트
    public Text myLoseNum; // 내 패배 횟수 텍스트
    public Text myTime;// 내 클리어 시간 텍스트

    // Start is called before the first frame update
    void Start()
    {
        //내 캐릭터 정보 오브젝트가 존재한지 확인
        if (null != GameObject.Find("MyPlayerInfomation"))
            this.myInfo = GameObject.Find("MyPlayerInfomation");
        if (null != GameObject.Find("ComputerInfomation"))
            this.enemyInfo = GameObject.Find("ComputerInfomation");
        //내 정보 UI 표시
        myName.text = this.myInfo.GetComponent<MyPlayer>().userName;
        myWinNum.text = this.myInfo.GetComponent<MyPlayer>().winScore.ToString();
        myLoseNum.text = this.myInfo.GetComponent<MyPlayer>().loseScore.ToString();
        myTime.text = this.myInfo.GetComponent<MyPlayer>().time.ToString();
    }

    //정보를 저장
    public void SaveInfomation()
    {
        //내 캐릭터 정보 추출
        string myName = this.myInfo.GetComponent<MyPlayer>().userName;
        int myWinTimes = this.myInfo.GetComponent<MyPlayer>().winScore;
        int myLoseTimes = this.myInfo.GetComponent<MyPlayer>().loseScore;
        float myTime = this.myInfo.GetComponent<MyPlayer>().time;

        //점수
        float score = (4 + (myWinTimes - myLoseTimes)) * (myTime * 0.1f);
        //정보 저장
    }
    public void ChangeMainScene()
    {
        Destroy(myInfo);
        Destroy(enemyInfo);
        SceneManager.LoadScene("MainScene");
    }
}
