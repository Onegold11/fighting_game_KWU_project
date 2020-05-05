using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector_Map : MonoBehaviour
{
    public Text mapSelText;
    private int mapSel = 0;

    public void BtnClickMap1()
    {
        mapSelText.text = "노천극장";
        mapSel = 1;
    }
    public void BtnClickMap2()
    {
        mapSelText.text = "광운스퀘어";
        mapSel = 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        mapSelText.text = "";
    }
    public void ChangeStartScene()
    {
        if (mapSelText.text == "")
        {
            return;
        }
        if(mapSel == 1)
        {
            SceneManager.LoadScene("GameScene");
        }else if(mapSel == 2)
        {
            SceneManager.LoadScene("GameScene_2");
        }
    }
    public void ChangeCharScene()
    {
        SceneManager.LoadScene("CharSelectScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
