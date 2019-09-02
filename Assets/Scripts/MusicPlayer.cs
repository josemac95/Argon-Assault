using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	// Se ejecuta antes de Start
	void Awake()
	{
		// Para que no se pierda la música en otras escenas
		DontDestroyOnLoad(gameObject);
	}
}
