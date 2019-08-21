using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
	// Tiempo de carga
	float loadTime = 2f;

	// Se ejecuta antes de Start
	void Awake()
	{
		// Para que no se pierda la música en otras escenas
		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		Invoke("LoadFirstScene", loadTime);
	}

	private void LoadFirstScene()
	{
		SceneManager.LoadScene(1);
	}
}
