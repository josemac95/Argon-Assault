using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour
{
	// Velocidad máxima horizontal de la nave (m/s)
	[Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;
	// Limite horizontal de movimiento (m)
	[Tooltip("In m")] [SerializeField] float xRange = 4f;

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
		// Posición local en el eje horizontal
		float rawXPos = transform.localPosition.x + xOffset;
		// Posición local en el eje horizontal con el limite horizontal
		float xPos = Mathf.Clamp(rawXPos, -xRange, xRange);
		// Movimiento horizontal en la posición local (relativa al padre = cámara)
		transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
	}
}
