using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameDirector_Game : MonoBehaviour
{
    GameObject timerText;
    GameObject myNameText;
    GameObject enemyNameText;
    GameObject gameOverText;
    GameObject myHpGage;
    GameObject enemyHpGage;

    GameObject myInfo;
    GameObject enemyInfo;

    private bool isCom;

    public float time = 60f;
    public float exitDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.gameOverText = GameObject.Find("GameOverText");
        this.myHpGage = GameObject.Find("MyHp");
        this.enemyHpGage = GameObject.Find("EnemyHp");
        this.myNameText = GameObject.Find("MyNameText");
        this.enemyNameText = GameObject.Find("EnemyNameText");

        if (null != GameObject.Find("MyPlayerInfomation"))
        {
            this.myInfo = GameObject.Find("MyPlayerInfomation");
            this.myNameText.GetComponent<Text>().text = this.myInfo.GetComponent<MyPlayer>().userName;
        }

        //상대방
        if (null != GameObject.Find("EnemyPlayerInformation"))
        {
            this.enemyInfo = GameObject.Find("EnemyPlayerInformation");
            this.enemyNameText.GetComponent<Text>().text = this.enemyInfo.GetComponent<EnemyPlayer>().userName;
            isCom = false;
        }
        //컴퓨터
        if (null != GameObject.Find("ComputerInfomation"))
        {
            this.enemyInfo = GameObject.Find("ComputerInfomation");
            this.enemyNameText.GetComponent<Text>().text = this.enemyInfo.GetComponent<Computer_Info>().userName;
            isCom = true;
        }

        this.gameOverText.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Time Show && Time Over
        if (this.time >= Time.deltaTime)
        {
            this.time -= Time.deltaTime;
            this.timerText.GetComponent<Text>().text = this.time.ToString("F0");
        }
        else
        {
            this.timerText.GetComponent<Text>().text = "Time Over";
            if(this.exitDelay < Time.deltaTime)
            {
                SceneManager.LoadScene("GameScene");
            }
            this.exitDelay -= Time.deltaTime;
        }

        //Attack Win Game Clear
        //상대편 승리
        if(myHpGage.GetComponent<Image>().fillAmount == 0)
        {
            //AllActionStop();
            //컴퓨터 상대로
            if (isCom)
            {
                this.gameOverText.GetComponent<Text>().text = this.enemyInfo.GetComponent<Computer_Info>().userName + " Win";
                if (this.exitDelay < Time.deltaTime)
                {
                    this.enemyInfo.GetComponent<Computer_Info>().winScore++;
                    this.myInfo.GetComponent<MyPlayer>().loseScore++;
                    this.myInfo.GetComponent<MyPlayer>().time += this.time;
                    this.myInfo.GetComponent<MyPlayer>().clearTimes++;

                    if(this.myInfo.GetComponent<MyPlayer>().clearTimes < 3)
                    {
                        //3판
                        SceneManager.LoadScene("GameScene");
                    }
                    else
                    {
                        //결과창
                        SceneManager.LoadScene("ResultScene_Single_Win");
                    }
                }
            }//사람 상대로
            else
            {
                this.gameOverText.GetComponent<Text>().text = this.enemyInfo.GetComponent<EnemyPlayer>().userName + " Win";
                if (this.exitDelay < Time.deltaTime)
                {
                    this.enemyInfo.GetComponent<EnemyPlayer>().winScore++;
                    this.myInfo.GetComponent<MyPlayer>().loseScore++;
                    SceneManager.LoadScene("ResultScene");
                }
            }
            this.exitDelay -= Time.deltaTime;
        }
        //내 승리
        if(enemyHpGage.GetComponent<Image>().fillAmount == 0)
        {
            //AllActionStop();
            //컴 상대로
            if (isCom)
            {
                this.gameOverText.GetComponent<Text>().text = this.myInfo.GetComponent<MyPlayer>().userName + " Win";
                if (this.exitDelay < Time.deltaTime)
                {
                    this.enemyInfo.GetComponent<Computer_Info>().loseScore++;
                    this.myInfo.GetComponent<MyPlayer>().winScore++;
                    this.myInfo.GetComponent<MyPlayer>().time += this.time;
                    this.myInfo.GetComponent<MyPlayer>().clearTimes++;

                    if (this.myInfo.GetComponent<MyPlayer>().clearTimes < 3)
                    {
                        this.enemyInfo.GetComponent<Computer_Info>().level++;
                        //3판
                        SceneManager.LoadScene("GameScene");
                    }
                    else
                    {
                        //결과창
                        SceneManager.LoadScene("ResultScene_Single_Win");
                    }
                }
            }//사람 상대로
            else
            {
                this.gameOverText.GetComponent<Text>().text = this.myInfo.GetComponent<MyPlayer>().userName + " Win";

                if (this.exitDelay < Time.deltaTime)
                {
                    this.myInfo.GetComponent<MyPlayer>().winScore++;
                    this.enemyInfo.GetComponent<EnemyPlayer>().loseScore++;
                    SceneManager.LoadScene("ResultScene");
                }
            }
            this.exitDelay -= Time.deltaTime;
        }
    }
    private void AllActionStop()
    {
        GameObject p1 = GameObject.FindWithTag("Player1");
        GameObject p2 = GameObject.FindWithTag("Player2");

        p1.GetComponent<MyPlayerController>().enabled = false;
        p1.GetComponent<EnemyPlayerController>().enabled = false;
        p1.GetComponent<ComPlayerController>().enabled = false;

        p2.GetComponent<MyPlayerController>().enabled = false;
        p2.GetComponent<EnemyPlayerController>().enabled = false;
        p2.GetComponent<ComPlayerController>().enabled = false;
    }
    public void DecreaseHp(GameObject hpGage)
    {
        hpGage.GetComponent<Image>().fillAmount -= 0.25f;
    }
}
