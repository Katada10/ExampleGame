using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour {

	public Button btn1, btn2;
	public Canvas canvas;	

	// Use this for initialization
	void Start () {
		canvas.enabled = false;
		btn1.GetComponent<Button>().onClick.AddListener(() => {
			 Scene loadedLevel = SceneManager.GetActiveScene ();
     			SceneManager.LoadScene (loadedLevel.buildIndex);
	 		});
		btn2.GetComponent<Button>().onClick.AddListener(() => {Application.Quit();});
	}


	void Update()
	{
		if(Game.isGameOver)
		{
			canvas.enabled = true;
		}
	}
}
