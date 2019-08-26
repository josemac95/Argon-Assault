using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour
{
	// Velocidad máxima horizontal de la nave (m/s)
	[Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;

	void Start()
	{

	}

	void Update()
	{
		// Impulso horizontal (valor de -1 a 1)
		// Depende de la sensibilidad y la gravedad
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		// Desplazamiento para este frame
		float xOffset = xThrow * xSpeed * Time.deltaTime;
	}
}
