using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moveball : MonoBehaviour {
	Rigidbody rb;
    public int bspeed;
    public int jspeed;
    private bool istouching = true;
    private int counter;
    public Text cointext;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
        counter = 0;
        cointext.text = "COINS: " + counter;
	}
	
	// Update is called once per frame
	void Update () {
		float Hmove = Input.GetAxis ("Horizontal");
		float Vmove = Input.GetAxis ("Vertical");
		Vector3 ballmove = new Vector3 (Hmove, 0.0f, Vmove);
		rb.AddForce (ballmove * bspeed);
        if (Input.GetKey(KeyCode.Space) && istouching == true) {
            Vector3 balljump = new Vector3(0.0f, 10.0f, 0.0f);
            rb.AddForce(balljump * jspeed);

        }
        istouching = false;
	}
    private void OnCollisionStay()
    {
        istouching = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cointag"))
        {
            other.gameObject.SetActive(false);
            counter = counter + 1;
            cointext.text = "COINS: " + counter;
        }
        if (counter == 4) {
            SceneManager.LoadScene("Endscene");
        
        }
    }



}
