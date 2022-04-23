using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System;

public class TopScores : MonoBehaviour
{

	public string Scores(int lastScore) {
	List<int> prev_scores = new List<int>();
	int flag=0;
	
	if(PlayerPrefs.HasKey("scoreKey"))
	{
		string temp = "";
		string[] scores = temp.Split();
		
		int j=0;
		while(j<scores.Length-1)
		{
			prev_scores.Add(int.Parse(scores[j]));
			j++;
		}
	}
	
	prev_scores.Add(lastScore);
	
	if(prev_scores.Count > 10)
	{
		flag = 1;
	}
	
	int i=1;
	
	if(flag == 0)
	{
		i=0;
	}
	
	string final="";
	
	while(i<prev_scores.Count)
	{
		final = final+prev_scores[i].ToString()+" ";
		i++;
	}
	
	PlayerPrefs.SetString("scoreKey",final);
	
	if(flag == 1)
	{
		prev_scores.RemoveAt(0);
	}
	
	prev_scores.Sort();
	
	string ret="";
	for(int k=0;k<prev_scores.Count;k++)
	{
		ret = ret + prev_scores[k].ToString()+" ";
	}
	
	
	return ret;
	}
}
