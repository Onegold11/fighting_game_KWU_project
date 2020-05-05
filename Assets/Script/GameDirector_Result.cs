using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector_Result : MonoBehaviour
{
    // 플레이어 정보를 저장한 오브젝트, 여기서 정보를 얻을 수 있다.
    GameObject myInfo; // 내 정보
    GameObject enemyInfo; // 적 정보

    //UI 표시를 위한 Text, 실제 정보 아님
    public Text myName; //내 캐릭터 이름 텍스트
    public Text enemyName; //적 캐릭터 이름 텍스트
    public Text myWinNum; //내 승리 횟수 텍스트
    public Text enemyWinNum; // 적 승리 횟수 텍스트
    public Text myLoseNum; // 내 패배 횟수 텍스트
    public Text enemyLoseNum;// 적 패배 횟수 텍스트

    //처음 시작하면 1번 실행되는 함수
    void Start()
    {
        //내 캐릭터 정보 오브젝트가 존재한지 확인
        if(null != GameObject.Find("MyPlayerInfomation"))
            this.myInfo = GameObject.Find("MyPlayerInfomation");
        //적 캐릭터 정보 오브젝트가 존재한지 확인
        if(null != GameObject.Find("EnemyPlayerInformation"))
            this.enemyInfo = GameObject.Find("EnemyPlayerInformation");
        //내 정보 UI 표시
        myName.text = this.myInfo.GetComponent<MyPlayer>().userName;
        myWinNum.text = this.myInfo.GetComponent<MyPlayer>().winScore.ToString();
        myLoseNum.text = this.myInfo.GetComponent<MyPlayer>().loseScore.ToString();
        //적 정보 UI 표시
        enemyName.text = this.enemyInfo.GetComponent<EnemyPlayer>().userName;
        enemyWinNum.text = this.enemyInfo.GetComponent<EnemyPlayer>().winScore.ToString();
        enemyLoseNum.text = this.enemyInfo.GetComponent<EnemyPlayer>().loseScore.ToString();
    }
    //정보를 저장
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("GameScene");
        /*
        //내 캐릭터 정보 추출
        string myName = this.myInfo.GetComponent<MyPlayer>().userName;
        int myWinTimes = this.myInfo.GetComponent<MyPlayer>().winScore;
        int myLoseTimes = this.myInfo.GetComponent<MyPlayer>().loseScore;

        //적 캐릭터 정보 추출
        string enemyName = this.enemyInfo.GetComponent<EnemyPlayer>().userName;
        int enemyWinTimes = this.enemyInfo.GetComponent<EnemyPlayer>().winScore;
        int enemyLoseTimes = this.enemyInfo.GetComponent<EnemyPlayer>().loseScore;

        //정보 저장
        */
    }
    //정보를 저장하지 않고 화면을 전환
    public void ChangeMainScene()
    {
        Destroy(myInfo);
        Destroy(enemyInfo);
        SceneManager.LoadScene("MainScene");
    }
}
