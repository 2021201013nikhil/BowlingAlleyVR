using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
public class GameManager : MonoBehaviour
{
	//Move the ball
	//Manage the score
	//Manage the turns
	
	public GameObject ball;
	int score = 0;
	GameObject[] pins;
	int turnCounter = 0;
	public Text scoreUI;
	
	string tscores="";
	
	Vector3[] positions;
	public HighScore highScore; 
	public TopScore topScore;
	
	public TopScores tp;
	string myfile = "";
	
    // Start is called before the first frame update
    void Start()
    {
    	topScore = new TopScore();
    	tp = new TopScores();
    	myfile = Application.persistentDataPath + "/scores.txt";
    	if(!File.Exists(myfile))
    	{
    		FileStream fs = File.Create(myfile);
    	}
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];
        
        for(int i=0;i<pins.Length;i++) {
        	positions[i] = pins[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        
        if(Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < -20) {
        	CountPinsDown();
        	turnCounter++;
        	ResetPins();
        	
        	if(turnCounter == 2) {
        	    	tscores = tp.Scores(score);
        	    	using (StreamWriter sw = File.AppendText(myfile)){
        	    		sw.WriteLine(tscores.ToString());
        	    	}
        	    	
    			topScore.topScore = tscores;
    			Debug.Log("tsco = "+ topScore.topScore);
    			turnCounter = 0;
    			score=0;
        	}
        }
    }
    
    void MoveBall() {
    	Vector3 position = ball.transform.position;
    	position += (Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
    	position.x = Mathf.Clamp(position.x, -0.525f, 0.525f);
    	ball.transform.position = position;
    
    	//ball.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
    
    void CountPinsDown() {
    	for(int i=0;i<pins.Length;i++) {
    		if(pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf) {
    			score++;
    			pins[i].SetActive(false);
    		}
    	}
    	scoreUI.text = score.ToString();
    	
    	if(score > highScore.highScore) {
    		highScore.highScore = score;
    	}
    	    	
    	Debug.Log(highScore.highScore);
    }
    
    void ResetPins() {
    	for(int i=0;i<pins.Length;i++) {
    		pins[i].SetActive(true);
    		pins[i].transform.position = positions[i];
    		pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
    		pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    		pins[i].transform.rotation = Quaternion.identity;
    	}
    	
    	ball.transform.position = new Vector3(0, 0.019f, -8.64f);
		ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
		ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		ball.transform.rotation = Quaternion.identity;
    }
}
