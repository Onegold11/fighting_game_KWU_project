using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector_SingleName : MonoBehaviour
{
    GameObject myInfo;
    GameObject enemyInfo;

    public InputField myNameInput;
    public Text myNameText;

    public void ChangeMyName()
    {
        myNameText.text = myNameInput.text;
    }

    public void ChangeStartScene()
    {
        if (myNameText.text == "")
        {
            return;
        }
        myInfo.GetComponent<MyPlayer>().userName = myNameText.text;
        SceneManager.LoadScene("CharSelectScene_Single");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (null != GameObject.Find("MyPlayerInfomation"))
            this.myInfo = GameObject.Find("MyPlayerInfomation");
        if (null != GameObject.Find("EnemyPlayerInformation"))
            this.enemyInfo = GameObject.Find("ComputerInfomation");
    }
    public void ChangeMainScene()
    {
        Destroy(myInfo);
        Destroy(enemyInfo);
        SceneManager.LoadScene("MainScene");
    }
}
