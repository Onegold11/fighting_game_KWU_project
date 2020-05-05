using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector_Main : MonoBehaviour
{  
    //Single 메뉴 실행
    public void ChangeSingleStartScene()
    {
        SceneManager.LoadScene("NameInsertion_Single");
    }
    //Vs 메뉴 실행
    public void ChangeVsStartScene()
    {
        SceneManager.LoadScene("NameInsertion");
    }
    public void ChangeRankScene()
    {
        SceneManager.LoadScene("RankingScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
