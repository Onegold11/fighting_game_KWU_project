using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector_Char : MonoBehaviour
{
    GameObject myInfo;
    GameObject enemyInfo;

    public Text myNameText;
    public Text enemyNameText;

    public Text myCharSelText;
    public Text enemyCharSelText;

    // Start is called before the first frame update
    void Start()
    {
        if (null != GameObject.Find("MyPlayerInfomation"))
            this.myInfo = GameObject.Find("MyPlayerInfomation");

        if (null != GameObject.Find("EnemyPlayerInformation"))
            this.enemyInfo = GameObject.Find("EnemyPlayerInformation");

        myNameText.text = this.myInfo.GetComponent<MyPlayer>().userName;
        enemyNameText.text = this.enemyInfo.GetComponent<EnemyPlayer>().userName;
        myCharSelText.text = "";
        enemyCharSelText.text = "";
    }
    public void BtnClickMyChar1()
    {
        myCharSelText.text = "WOMAN";
        myInfo.GetComponent<MyPlayer>().charSelect = 1;
    }
    public void BtnClickMyChar2()
    {
        myCharSelText.text = "MAN";
        myInfo.GetComponent<MyPlayer>().charSelect = 2;
    }
    public void BtnClickMyChar3()
    {
        myCharSelText.text = "BLACK";
        myInfo.GetComponent<MyPlayer>().charSelect = 3;
    }
    public void BtnClickMyChar4()
    {
        myCharSelText.text = "KURIRIN";
        myInfo.GetComponent<MyPlayer>().charSelect = 4;
    }
    public void BtnClickMyChar5()
    {
        myCharSelText.text = "LUFFY";
        myInfo.GetComponent<MyPlayer>().charSelect = 5;
    }
    public void BtnClickEnemyChar1()
    {
        enemyCharSelText.text = "WOMAN";
        enemyInfo.GetComponent<EnemyPlayer>().charSelect = 1;
    }
    public void BtnClickEnemyChar2()
    {
        enemyCharSelText.text = "MAN";
        enemyInfo.GetComponent<EnemyPlayer>().charSelect = 2;
    }
    public void BtnClickEnemyChar3()
    {
        enemyCharSelText.text = "BLACK";
        enemyInfo.GetComponent<EnemyPlayer>().charSelect = 3;
    }
    public void BtnClickEnemyChar4()
    {
        enemyCharSelText.text = "KURIRIN";
        enemyInfo.GetComponent<EnemyPlayer>().charSelect = 4;
    }
    public void BtnClickEnemyChar5()
    {
        enemyCharSelText.text = "LUFFY";
        enemyInfo.GetComponent<EnemyPlayer>().charSelect = 5;
    }
    public void ChangeNextScene()
    {
        if (myCharSelText.text == "" || enemyCharSelText.text == "")
        {
            return;
        }
        SceneManager.LoadScene("MapSelectScene");
    }
    public void ChangeNameScene()
    {
        Destroy(myInfo);
        Destroy(enemyInfo);
        SceneManager.LoadScene("NameInsertion");
    }
}
