using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

    public Transform StartPoint;

	public void Reset()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.buildIndex);
        //transform.position = StartPoint.position;
        //transform.forward = StartPoint.forward;
    }
}
