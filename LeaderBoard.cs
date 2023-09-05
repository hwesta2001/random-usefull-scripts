using UnityEngine;
using System;

public class LeaderBoard : Monobehaivour
{
 public int currentScore;
 public List<Score>  scores = new(); // new değil playerprefaba yaz çek.
                      															// ilk başta custom bir liste oluşturabiliriz 
 public List<TexMeshProOnGui> textMeshesNames = new();
 public List<TexMeshProOnGui> textMeshesScores = new();

 void SetScore(string _name)
 {
   currentScore=Globals.ins.Score; 
   Score newScore = new();
   newScore.name = _name;
   newScore.score =currentScore;
   CompareScores(newScore);
 } 
 void CompareScores(Score _score) 
 {
  for (int i=0; i<scores.Count; i++) 
  {
   if(_score.score>=scores[i])
   {
    scores[i]=_score;
    break;
   }
  }
  RefresLeaderboardList();
 }

void RefresLeaderboardList()
{
 for(int i = 0; i<scores.Count; i++) 
 {
   textMeshesNames[i].text=scores[i].name;
   textMeshesScores[i].text=scores[i].score;
 } 


} 
 
}

public class Score
{
 public int score;
 public string name;
} 
