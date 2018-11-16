using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {

    public Text instructText;
    public static int count;
    public Button OK_button;

	// Use this for initialization
	void Start () {

        Debug.Log("In start");
        //OK_button = GetComponent<Button>();
        OK_button.gameObject.SetActive(false);

        //instructText = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider checkpoint)
    {
        if (checkpoint.gameObject.CompareTag("Player"))
        {

            Debug.Log("Inside if");   
            Time.timeScale = 0;

            Debug.Log("After Pause");


            if (count == 0)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "Button Instructions";
                count++;
            }
            else if (count == 1)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "Click the button to the left";
                count++;
            }
            else if (count == 2)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "Click the button to the right";
                count++;
            }
            else if (count == 3)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "Click the button below";
                count++;
            }

        }


    }

        
    public void resumeGame(){

        instructText.text = "";

        Time.timeScale = 1;

        OK_button.gameObject.SetActive(false);

      
    }

}
