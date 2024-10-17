using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public TMP_InputField nameInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ReturnToMainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void SaveScore(){
        var score = player.GetComponent<PlayerScript>().score;
        var name = nameInput.text;
        if(name.Length == 0) return;
        List<UserScore> scores = UserScore.GetScores();
        scores.Add(new UserScore(name, score));
        UserScore.SaveScores(scores);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
