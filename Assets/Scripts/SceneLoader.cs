using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	// Tiempo de carga
	float loadTime = 2f;

	void Start()
	{
		Invoke("LoadFirstScene", loadTime);
	}

	private void LoadFirstScene()
	{
		SceneManager.LoadScene(1);
	}
}
