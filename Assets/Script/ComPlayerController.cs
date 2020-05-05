using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ComPlayerController : MonoBehaviour
{
    private Transform[] playerTransforms;

    GameObject comInfo; //컴퓨터 정보

    public AudioClip deathClip;
    public AudioClip hitClip;
    public AudioClip damageClip;

    private float jumpForce = 300f;
    private float walkForce = 100.0f;

    //점프 카운터
    private int jumpCount = 0;

    //행동 여부
    private bool isGrounded = false;
    private bool isWalked = false;
    private bool isPunched = false;
    private bool isGuarded = false;
    private bool isDead = false;

    //행동 프레임 수치
    private int punchFrame = 0;
    private int guardFrame = 0;
    private int jumpFrame = 0;
    private int walkFrame = 0;

    //컴포넌트
    private Rigidbody playerRidibody;
    private Animator animator;
    private GameObject AttackBox;
    GameObject myHpGage;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (null != GameObject.Find("ComputerInfomation"))
            this.comInfo = GameObject.Find("ComputerInfomation");
        //comLevel = this.comInfo.GetComponent<Computer_Info>().level;
        playerRidibody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        AttackBox = transform.Find("AttackBox").gameObject;
        myHpGage = GameObject.Find("EnemyHp");
        playerAudio = GetComponent<AudioSource>();
    }
    private void Die()
    {
        animator.SetTrigger("Lose");

        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerRidibody.velocity = Vector2.zero;
        isDead = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead || IsDead())
        {
            return;
        }
        //공격, 피격 판정 프레임
        if (IsDelayFrame())
        {
            return;
        }
        isWalked = false;
        isPunched = false;
        isGuarded = false;
        if (IsClosePlayer())
        {
            int moveNum = Random.Range(1, 10);
            //이동 - 오른쪽(앞)
            if (moveNum < 8)
            {
                if (playerRidibody.velocity.x > -2.0f)
                {
                    Debug.Log("뒤로");
                    if (isGrounded)
                    {
                        playerRidibody.velocity = Vector3.zero;
                    }
                    playerRidibody.AddForce(new Vector3(walkForce * -1, 0, 0));
                    isWalked = true;
                }
            }
            //이동 - 왼쪽(뒤)
            else
            {
                if (playerRidibody.velocity.x < 2.0f)
                {
                    Debug.Log("앞으로");
                    if (isGrounded)
                    {
                        playerRidibody.velocity = Vector3.zero;
                    }
                    playerRidibody.AddForce(new Vector3(walkForce * 1, 0, 0));
                    isWalked = true;
                }
            }
        }
        else
        {
            int actNum = Random.Range(1, 4);

            switch (actNum)
            {
                case 1:
                    {
                        //점프
                        if (jumpCount < 1)
                        {
                            jumpCount++;
                            playerRidibody.velocity = Vector3.zero;
                            playerRidibody.AddForce(new Vector3(0, jumpForce, 0));
                            //playerAudio.Play();
                        }
                        else if (playerRidibody.velocity.y > 0)
                        {
                            playerRidibody.velocity *= 0.5f;
                        }
                        break;
                    }
                case 2:
                    {
                        //펀치
                        Debug.Log("펀치");
                        playerAudio.clip = hitClip;
                        playerAudio.Play();
                        isPunched = true;
                        break;
                    }
                case 3:
                    {
                        //가드
                        Debug.Log("가드");
                        isGuarded = true;
                        break;
                    }
            }
        }
        animator.SetBool("Guarded", isGuarded);
        animator.SetBool("Punched", isPunched);
        animator.SetBool("Walked", isWalked);
        animator.SetBool("Grounded", isGrounded);
    }
    //공격, 피격 판정 프레임
    private bool IsDelayFrame()
    {
        //공격 프레임
        if (isPunched)
        {
            if (punchFrame >= 5)
            {
                //공격 초기화
                AttackBox.GetComponent<BoxCollider>().enabled = false;
                punchFrame = 0;
                return false;
            }
            else
            {
                AttackBox.GetComponent<BoxCollider>().enabled = true;
                Debug.Log("공격 중" + punchFrame);
                punchFrame++;
                return true;
            }
        }//방어 프레임
        else if (isGuarded)
        {
            if (guardFrame >= 15)
            {
                //방어 초기화
                this.GetComponent<BoxCollider>().enabled = true;
                guardFrame = 0;
                return false;
            }
            else
            {
                Debug.Log("방어 중" + guardFrame);
                this.GetComponent<BoxCollider>().enabled = false;
                guardFrame++;
                return true;
            }
        }
        return false;
    }
    //죽은지 확인
    private bool IsDead()
    {
        if (myHpGage.GetComponent<Image>().fillAmount == 0)
        {
            Debug.Log("죽음");
            if (!isDead)
            {
                Die();
                return true;
            }
        }
        return false;
    }
    //충돌
    private void OnTriggerEnter(Collider other)
    {
        //공격
        if (other is BoxCollider && isPunched)
        {
            //공격 성공
            Debug.Log("펀치 성공");
            //Hp decrease
            GameObject enemyHpGage = GameObject.Find("MyHp");
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector_Game>().DecreaseHp(enemyHpGage);
        }//피격
        else if (other is BoxCollider && !isPunched)
        {
            Debug.Log("맞음");
            playerAudio.clip = damageClip;
            playerAudio.Play();
            animator.SetTrigger("Hitted");
        }
    }
    //바닥 닿았을 때
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Plane" && collision.contacts[0].normal.y > 0.7f)
        {
            Debug.Log("바닥 닿음");
            isGrounded = true;
            jumpCount = 0;
        }
    }
    //바닥 벗어났을 때
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Plane")
        {
            Debug.Log("바닥 벗어남");
            isGrounded = false;
        }
    }
    //캐릭터와 거리 확인
    private bool IsClosePlayer()
    {
        int index = 0;
        GameObject[] Player1s = GameObject.FindGameObjectsWithTag("Player1");
        GameObject[] Player2s = GameObject.FindGameObjectsWithTag("Player2");
        playerTransforms = new Transform[Player1s.Length + Player2s.Length];
        for (int i = 0; i < Player1s.Length; i++)
        {
            playerTransforms[index++] = Player1s[i].transform;
        }
        for (int j = 0; j < Player2s.Length; j++)
        {
            playerTransforms[index++] = Player2s[j].transform;
        }

        if (playerTransforms.Length == 0)
        {
            Debug.Log("No Player find");
            return false;
        }

        float xMin, xMax;
        xMin = xMax = playerTransforms[0].position.x;

        for (int i = 1; i < playerTransforms.Length; i++)
        {
            if (playerTransforms[i].position.x < xMin)
                xMin = playerTransforms[i].position.x;
            if (playerTransforms[i].position.x > xMax)
                xMax = playerTransforms[i].position.x;
        }

        float distance = (xMax - xMin);

        if(distance > 0.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
