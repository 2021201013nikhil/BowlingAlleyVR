using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	
	Vector3[] positions;
	public HighScore highScore; 
	
	public GameObject menu;
	
    // Start is called before the first frame update
    void Start()
    {
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
        	
        	if(turnCounter == 10) {
        		menu.SetActive(true);
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
