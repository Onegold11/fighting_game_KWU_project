using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector_Rank : MonoBehaviour
{
    public Text rank;
    // Start is called before the first frame update
    void Start()
    {
        //rank
        rank.text = "";
    }
    public void ChangeMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
