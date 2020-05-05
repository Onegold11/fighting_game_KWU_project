using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class RankingManager : MonoBehaviour {

    InputField input_response;
    InputField input_nickname;
    InputField input_score;
    InputField input_ranking_list;


    void Awake()
    {
        this.input_response = transform.FindChild("input_response").GetComponent<InputField>();
        this.input_nickname = transform.FindChild("input_nickname").GetComponent<InputField>();
        this.input_score = transform.FindChild("input_score").GetComponent<InputField>();
        this.input_ranking_list = transform.FindChild("input_ranking_list").GetComponent<InputField>();
    }


    public void get_ranking_list()
    {
        StartCoroutine(request_ranking_list());
    }


    public void get_user_rank()
    {
        if (this.input_nickname.text.Length <= 0)
        {
            return;
        }

        StartCoroutine(request_user_rank(this.input_nickname.text));
    }


    public void add_score()
    {
        if (this.input_nickname.text.Length <= 0)
        {
            return;
        }

        if (this.input_score.text.Length <= 0)
        {
            return;
        }

        StartCoroutine(request_add_score(this.input_nickname.text, int.Parse(this.input_score.text)));
    }


    void on_response(string text)
    {
        this.input_response.text = text;
    }


    IEnumerator request_ranking_list()
    {
        WWW www = new WWW("localhost/MyRankingServer/api/rankings");
        yield return www;

        on_response(www.text);

        // 랭킹 리스트 표시.
        ArrayList list = XUtil.MiniJSON.jsonDecode(www.text) as ArrayList;
        string result = "";
        for (int i = 0; i < list.Count; ++i)
        {
            Hashtable table = list[i] as Hashtable;
            result += string.Format("{0}    score : {1}\n", table["nickname"].ToString(), int.Parse(table["score"].ToString()));
        }
        this.input_ranking_list.text = result;
    }


    IEnumerator request_user_rank(string nickname)
    {
        WWW www = new WWW(string.Format("localhost/MyRankingServer/api/rankings?nickname={0}", nickname));
        yield return www;

        on_response(www.text);
    }


    IEnumerator request_add_score(string nickname, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", nickname);
        form.AddField("score", score);

        WWW www = new WWW("localhost/MyRankingServer/api/rankings", form);
        yield return www;
       
        on_response(www.text);
    }
}
