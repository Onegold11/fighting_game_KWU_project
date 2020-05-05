using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameDirector_Char_Single : MonoBehaviour
{
    GameObject myInfo;
    GameObject enemyInfo;

    public Text myNameText;

    public Text myCharSelText;

    // Start is called before the first frame update
    void Start()
    {
        if (null != GameObject.Find("MyPlayerInfomation"))
            this.myInfo = GameObject.Find("MyPlayerInfomation");
        if (null != GameObject.Find("EnemyPlayerInformation"))
            this.enemyInfo = GameObject.Find("EnemyPlayerInformation");

        myNameText.text = this.myInfo.GetComponent<MyPlayer>().userName;
        myCharSelText.text = "";
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
    public void ChangeNextScene()
    {
        if (myCharSelText.text == "")
        {
            return;
        }
        SceneManager.LoadScene("MapSelectScene");
    }
    public void ChangeNameScene()
    {
        Destroy(myInfo);
        Destroy(enemyInfo);
        SceneManager.LoadScene("NameInsertion_Single");
    }
}
