using UnityEngine;
using System;

public class LeaderBoard : Monobehaivour
{
	
	public List<Score>  scores = new() ;
	
	void CompareScores(Score _score) 
	{
		for (int i=0; i<scores.Count; i++) 
		{
			if(_score.score>=scores[i])
			
		} 
	
	} 
	
	
}

public class Score
{
	public int score;
	public string name;
} 
