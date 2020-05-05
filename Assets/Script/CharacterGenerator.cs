using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public GameObject Player1Prefab;
    public GameObject Player2Prefab;
    public GameObject Player3Prefab;
    public GameObject Player4Prefab;
    public GameObject Player5Prefab;

    GameObject myInfo;
    GameObject enemyInfo;
    // Start is called before the first frame update
    void Start()
    {
        //내 캐릭터
        if (null != GameObject.Find("MyPlayerInfomation"))
        {
            this.myInfo = GameObject.Find("MyPlayerInfomation");
            switch (myInfo.GetComponent<MyPlayer>().charSelect)
            {
                case 1:
                    GameObject p1 = Instantiate(Player1Prefab) as GameObject;
                    p1.transform.position = new Vector3(-2, 1, 0);
                    p1.transform.rotation = Quaternion.Euler(0, 90, 0);
                    p1.GetComponent<EnemyPlayerController>().enabled = false;
                    p1.GetComponent<ComPlayerController>().enabled = false;
                    p1.gameObject.tag = "Player1";
                    break;
                case 2:
                    GameObject p2 = Instantiate(Player2Prefab) as GameObject;
                    p2.transform.position = new Vector3(-2, 1, 0);
                    p2.transform.rotation = Quaternion.Euler(0, 90, 0);
                    p2.GetComponent<EnemyPlayerController>().enabled = false;
                    p2.GetComponent<ComPlayerController>().enabled = false;
                    p2.gameObject.tag = "Player1";
                    break;
                case 3:
                    GameObject p3 = Instantiate(Player3Prefab) as GameObject;
                    p3.transform.position = new Vector3(-2, 1, 0);
                    p3.transform.rotation = Quaternion.Euler(0, 90, 0);
                    p3.GetComponent<EnemyPlayerController>().enabled = false;
                    p3.GetComponent<ComPlayerController>().enabled = false;
                    p3.gameObject.tag = "Player1";
                    break;
                case 4:
                    GameObject p4 = Instantiate(Player4Prefab) as GameObject;
                    p4.transform.position = new Vector3(-2, 1, 0);
                    p4.transform.rotation = Quaternion.Euler(0, 90, 0);
                    p4.GetComponent<EnemyPlayerController>().enabled = false;
                    p4.GetComponent<ComPlayerController>().enabled = false;
                    p4.gameObject.tag = "Player1";
                    break;
                case 5:
                    GameObject p5 = Instantiate(Player5Prefab) as GameObject;
                    p5.transform.position = new Vector3(-2, 1, 0);
                    p5.transform.rotation = Quaternion.Euler(0, 90, 0);
                    p5.GetComponent<EnemyPlayerController>().enabled = false;
                    p5.GetComponent<ComPlayerController>().enabled = false;
                    p5.gameObject.tag = "Player1";
                    break;
            }
        }
        //적 캐릭터
        if (null != GameObject.Find("EnemyPlayerInformation"))
        {
            this.enemyInfo = GameObject.Find("EnemyPlayerInformation");
            switch (enemyInfo.GetComponent<EnemyPlayer>().charSelect)
            {
                case 1:
                    GameObject p1 = Instantiate(Player1Prefab) as GameObject;
                    p1.transform.position = new Vector3(2, 1, 0);
                    p1.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p1.GetComponent<MyPlayerController>().enabled = false;
                    p1.GetComponent<ComPlayerController>().enabled = false;
                    p1.gameObject.tag = "Player2";
                    break;
                case 2:
                    GameObject p2 = Instantiate(Player2Prefab) as GameObject;
                    p2.transform.position = new Vector3(2, 1, 0);
                    p2.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p2.GetComponent<MyPlayerController>().enabled = false;
                    p2.GetComponent<ComPlayerController>().enabled = false;
                    p2.gameObject.tag = "Player2";
                    break;
                case 3:
                    GameObject p3 = Instantiate(Player3Prefab) as GameObject;
                    p3.transform.position = new Vector3(2, 1, 0);
                    p3.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p3.GetComponent<MyPlayerController>().enabled = false;
                    p3.GetComponent<ComPlayerController>().enabled = false;
                    p3.gameObject.tag = "Player2";
                    break;
                case 4:
                    GameObject p4 = Instantiate(Player4Prefab) as GameObject;
                    p4.transform.position = new Vector3(2, 1, 0);
                    p4.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p4.GetComponent<MyPlayerController>().enabled = false;
                    p4.GetComponent<ComPlayerController>().enabled = false;
                    p4.gameObject.tag = "Player2";
                    break;
                case 5:
                    GameObject p5 = Instantiate(Player5Prefab) as GameObject;
                    p5.transform.position = new Vector3(2, 1, 0);
                    p5.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p5.GetComponent<MyPlayerController>().enabled = false;
                    p5.GetComponent<ComPlayerController>().enabled = false;
                    p5.gameObject.tag = "Player2";
                    break;
            }
        }
        //컴퓨터
        if (null != GameObject.Find("ComputerInfomation"))
        {
            this.enemyInfo = GameObject.Find("ComputerInfomation");
            enemyInfo.GetComponent<Computer_Info>().charSelect = Random.Range(1,5);

            switch (enemyInfo.GetComponent<Computer_Info>().charSelect)
            {
                case 1:
                    GameObject p1 = Instantiate(Player1Prefab) as GameObject;
                    p1.transform.position = new Vector3(2, 1, 0);
                    p1.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p1.GetComponent<MyPlayerController>().enabled = false;
                    p1.GetComponent<EnemyPlayerController>().enabled = false;
                    p1.gameObject.tag = "Player2";
                    break;
                case 2:
                    GameObject p2 = Instantiate(Player2Prefab) as GameObject;
                    p2.transform.position = new Vector3(2, 1, 0);
                    p2.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p2.GetComponent<MyPlayerController>().enabled = false;
                    p2.GetComponent<EnemyPlayerController>().enabled = false;
                    p2.gameObject.tag = "Player2";
                    break;
                case 3:
                    GameObject p3 = Instantiate(Player3Prefab) as GameObject;
                    p3.transform.position = new Vector3(2, 1, 0);
                    p3.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p3.GetComponent<MyPlayerController>().enabled = false;
                    p3.GetComponent<EnemyPlayerController>().enabled = false;
                    p3.gameObject.tag = "Player2";
                    break;
                case 4:
                    GameObject p4 = Instantiate(Player4Prefab) as GameObject;
                    p4.transform.position = new Vector3(2, 1, 0);
                    p4.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p4.GetComponent<MyPlayerController>().enabled = false;
                    p4.GetComponent<EnemyPlayerController>().enabled = false;
                    p4.gameObject.tag = "Player2";
                    break;
                case 5:
                    GameObject p5 = Instantiate(Player5Prefab) as GameObject;
                    p5.transform.position = new Vector3(2, 1, 0);
                    p5.transform.rotation = Quaternion.Euler(0, -90, 0);
                    p5.GetComponent<MyPlayerController>().enabled = false;
                    p5.GetComponent<EnemyPlayerController>().enabled = false;
                    p5.gameObject.tag = "Player2";
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
