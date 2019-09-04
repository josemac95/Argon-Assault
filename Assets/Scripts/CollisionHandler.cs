using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
	// Tiempo de carga
	[Tooltip("In seconds")] [SerializeField] float loadTime = 1f;
	// Efecto de muerte
	[Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

	// Si choca con un objeto (disparador)
	void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
	}

	// Secuencia de muerte
	void StartDeathSequence()
	{
		// Mensaje a los que tengan el método OnPlayerDeath
		SendMessage("OnPlayerDeath");
		// Efecto de muerte
		deathFX.SetActive(true);
		// Carga de nuevo la escena
		Invoke("ReloadScene", loadTime);
	}

	// Carga el nivel
	private void ReloadScene()
	{
		SceneManager.LoadScene(1);
	}
}
