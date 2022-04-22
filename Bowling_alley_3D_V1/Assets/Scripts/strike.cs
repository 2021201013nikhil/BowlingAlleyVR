using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
    	if(other.gameObject.name == "BowlingBall"){
    		AudioSource source = GetComponent<AudioSource>();
    		source.Play();
    	}
    }
}
