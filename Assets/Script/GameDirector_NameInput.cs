using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector_NameInput : MonoBehaviour
{
    GameObject myInfo;
    GameObject enemyInfo;

    public InputField myNameInput;
    public InputField enemyNameInput;
    public Text myNameText;
    public Text enemyNameText;

    public void ChangeMyName()
    {
        myNameText.text = myNameInput.text;
    }
    public void ChangeEnemyName()
    {
        enemyNameText.text = enemyNameInput.text;
    }

    public void ChangeStartScene()
    {
        if(myNameText.text =="" || enemyNameText.text =="")
        {
            return;
        }
        myInfo.GetComponent<MyPlayer>().userName = myNameText.text;
        enemyInfo.GetComponent<EnemyPlayer>().userName = enemyNameText.text;
        SceneManager.LoadScene("CharSelectScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (null != GameObject.Find("MyPlayerInfomation"))
            this.myInfo = GameObject.Find("MyPlayerInfomation");

        if (null != GameObject.Find("EnemyPlayerInformation"))
            this.enemyInfo = GameObject.Find("EnemyPlayerInformation");
    }
    public void ChangeMainScene()
    {
        Destroy(myInfo);
        Destroy(enemyInfo);
        SceneManager.LoadScene("MainScene");
    }
}
