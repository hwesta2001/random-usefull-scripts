
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score
{
    public int score;
    public string name;
}

public class LeaderBoardManager : MonoBehaviour
{

    public class LeaderBoard : MonoBehaviour
    {
        public int currentScore;
        public List<Score> scores = new(); // new değil playerprefaba yaz çek.
                                           // ilk başta custom bir liste oluşturabiliriz 
        public List<TextMeshProUGUI> textMeshesNames = new();
        public List<TextMeshProUGUI> textMeshesScores = new();

        void SetScore(string _name)
        {
            currentScore = GlobalVeriler.ins.Score;
            Score newScore = new()
            {
                name = _name,
                score = currentScore
            };
            CompareScores(newScore);
        }

        void CompareScores(Score _score)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                if (_score.score >= scores[i].score)
                {
                    scores[i] = _score;
                    break;
                }
            }
            RefresLeaderboardList();
        }

        void RefresLeaderboardList()
        {
            for (int i = 0; i < scores.Count; i++)
            {
                textMeshesNames[i].text = scores[i].name;
                textMeshesScores[i].text = scores[i].score.ToString();
            }

        }

    }


}
