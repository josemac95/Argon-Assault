using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton sin statics
public class MusicPlayer : MonoBehaviour
{
	// Se ejecuta antes de Start
	void Awake()
	{
		// Encuentra los MusicPlayer
		int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
		// Si no es el primero
		if (numMusicPlayers > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			// Para que no se pierda la música en otras escenas
			DontDestroyOnLoad(gameObject);
		}
	}
}
