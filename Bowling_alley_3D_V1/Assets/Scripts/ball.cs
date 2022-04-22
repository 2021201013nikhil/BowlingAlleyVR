using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
	public Rigidbody rb;
	public float power = 5000;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
        	rb.AddForce(Vector3.forward * 5500);
        	AudioSource source = GetComponent<AudioSource>();
        	source.Play();
        }
        
    }
}
