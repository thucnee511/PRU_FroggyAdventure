using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;
using System;

public class ScoreBoardScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text player1;
    public TMP_Text player2;
    public TMP_Text player3;
    public TMP_Text player4;
    public TMP_Text player5;
    public TMP_Text score1;
    public TMP_Text score2;
    public TMP_Text score3;
    public TMP_Text score4;
    public TMP_Text score5;
    void Start()
    {   
        List<UserScore> scores = UserScore.GetScores();
        scores.Sort((a, b) => b.Score.CompareTo(a.Score));
        List<UserScore> top5 = scores.GetRange(0, Math.Min(5, scores.Count));
        Debug.Log(top5.Count);
        UserScore _player1 = null, _player2 = null, _player3 = null, _player4 = null, _player5 = null;
        for(int i = 0; i < top5.Count; i++){
            if(i == 0){
                _player1 = top5[i];
            }
            if(i == 1){
                _player2 = top5[i];
            }
            if(i == 2){
                _player3 = top5[i];
            }
            if(i == 3){
                _player4 = top5[i];
            }
            if(i == 4){
                _player5 = top5[i];
            }
        }
        player1.text = _player1 != null ? _player1.Name : "Not found";
        player2.text = _player2 != null ? _player2.Name : "Not found";
        player3.text = _player3 != null ? _player3.Name : "Not found";
        player4.text = _player4 != null ? _player4.Name : "Not found";
        player5.text = _player5 != null ? _player5.Name : "Not found";
        score1.text = _player1 != null ? _player1.Score.ToString() : "0";
        score2.text = _player2 != null ? _player2.Score.ToString() : "0";
        score3.text = _player3 != null ? _player3.Score.ToString() : "0";
        score4.text = _player4 != null ? _player4.Score.ToString() : "0";
        score5.text = _player5 != null ? _player5.Score.ToString() : "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
