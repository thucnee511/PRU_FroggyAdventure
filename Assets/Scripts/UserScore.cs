using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class UserScore{
    public string Name{get; set;}
    public int Score{get; set;}
    public UserScore(){}
    public UserScore(string name, int score){
        Name = name;
        Score = score;
    }
    public static List<UserScore> GetScores(){
        using FileStream file = File.Open("Assets/Resources/scores.xml", FileMode.Open);
        var xs = new XmlSerializer(typeof(List<UserScore>));
        return (List<UserScore>)xs.Deserialize(file);
    }

    public static void SaveScores(List<UserScore> scores){
        using FileStream file = File.Open("Assets/Resources/scores.xml", FileMode.Create);
        //remove all old scores
        file.SetLength(0);
        var xs = new XmlSerializer(typeof(List<UserScore>));
        xs.Serialize(file, scores);
    }
}