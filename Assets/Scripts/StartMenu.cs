using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

public GameObject btn1, btn2;
	void Start()
	{
		btn1.GetComponent<Button>().onClick.AddListener(StartGame);
		btn2.GetComponent<Button>().onClick.AddListener(ExitGame);
		 
	}
	void StartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}

	void ExitGame()
	{
		Application.Quit();
	}
}
