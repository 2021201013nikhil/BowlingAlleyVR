using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class MainMenu : MonoBehaviour
{
	public HighScore highScore;
	public TopScore topScore;
	public Text topScoreValue;
	public GameObject topScoreMenu;
	public Text highScoreValue;
	public Text highHighScoreValue;
	public GameObject highScoreMenu;
	List<int> scores = new List<int>();
	string myfile;
	
	public string readFile(){
		int temp = 0;
		List<int> scores = new List<int>();
		List<int> scores10 = new List<int>();
		myfile = Application.persistentDataPath + "/scores.txt";
		using(StreamReader sw = File.OpenText(myfile)){
			string line = "";
			while((line = sw.ReadLine()) != null)
			{
				temp = int.Parse(line);
				scores.Add(temp);
				Debug.Log("Temp: " + temp);
			}
		}
		
		scores.Reverse();
		for(int i = 0; i<10; i++){
			if(i==scores.Count)
				break;
			scores10.Add(scores[i]);
		}
		
		scores10.Sort();
		String temp1 = "| ";
		for(int i = scores10.Count -1 ; i>=0; i--){
			temp1 += scores10[i] +  " | ";
		}
		
		return temp1;
	}
	
	
	public void StartGame() {
		SceneManager.LoadScene("Game");
	}
	public void QuitGame() {
		Application.Quit();
	}
	public void OpenHighScore() {
		//highScoreMenu.SetActive(true);
		SceneManager.LoadScene(2);
		Debug.Log("High Score ans = "+ highScore.highScore.ToString());
		highScoreValue.text = highScore.highScore.ToString();
		highHighScoreValue.text = highScore.highScore.ToString();
	}
	public void CloseHighScore() {
		// highScoreMenu.SetActive(false);
		SceneManager.LoadScene("MainMenu");
	}
	public void ResetHighScore() {
		highScore.highScore = 0;
		highScoreValue.text = highScore.highScore.ToString();
	}
	public void OpenTopScores(){
		topScoreMenu.SetActive(true);
		string score = readFile();
		Debug.Log("Top Score ans = "+ score);
		//Debug.Log("Top Score ans = "+ topScore.topScore);
		topScoreValue.text = score.ToString();
	}
	public void CloseTopScore() {
		topScoreMenu.SetActive(false);
	}
}
