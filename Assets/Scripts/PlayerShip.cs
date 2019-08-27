﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour
{
	// Velocidad máxima de la nave (m/s)
	[Tooltip("In ms^-1")] [SerializeField] float speed = 5f;
	// Limite horizontal de movimiento (m)
	[Tooltip("In m")] [SerializeField] float xRange = 4f;
	// Limite vertical de movimiento (m)
	[Tooltip("In m")] [SerializeField] float yRange = 2.5f;
	// Factor de cabeceo respecto a la posición en Y
	[SerializeField] float positionPitchFactor = -8f;
	// Factor de cabeceo respecto al impuslo vertical
	[SerializeField] float yThrowPitchFactor = -10f;
	// Factor de guiñada respecto a la posición en X
	[SerializeField] float positionYawFactor = 7f;
	// Factor de alabeo respecto al impuslo horizontal
	[SerializeField] float xThrowRollFactor = -20f;

	// Impulso horizontal de la nave
	float xThrow;
	// Impulso vertical de la nave
	float yThrow;

	void Start()
	{

	}

	void Update()
	{
		// Movimiento de la nave
		ProcessTranslation();
		// Rotacion de la nave
		ProcessRotation();
	}

	// Movimiento de la nave en la posición local
	private void ProcessTranslation()
	{
		// Posición horizontal
		float xPos = CalculateXPos();
		// Posición vertical
		float yPos = CalculateYPos();
		// Movimiento en la posición local (relativa al padre = cámara)
		transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
	}

	// Posición local en el eje horizontal
	private float CalculateXPos()
	{
		// Impulso horizontal (valor de -1 a 1)
		// Depende de la sensibilidad y la gravedad
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		// Desplazamiento horizontal para este frame
		float xOffset = xThrow * speed * Time.deltaTime;
		// Posición local en el eje horizontal
		float rawXPos = transform.localPosition.x + xOffset;
		// Posición local en el eje horizontal con el limite horizontal
		return Mathf.Clamp(rawXPos, -xRange, xRange);
	}

	// Posición local en el eje vertical
	private float CalculateYPos()
	{
		// Impulso vertical (valor de -1 a 1)
		// Depende de la sensibilidad y la gravedad
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");
		// Desplazamiento vertical para este frame
		float yOffset = yThrow * speed * Time.deltaTime;
		// Posición local en el eje vertical
		float rawYPos = transform.localPosition.y + yOffset;
		// Posición local en el eje vertical con el limite vertical
		return Mathf.Clamp(rawYPos, -yRange, yRange);
	}

	// Movimiento de rotación de la nave
	private void ProcessRotation()
	{
		// x = cabeceo (vertical)
		float pitch = transform.localPosition.y * positionPitchFactor + yThrow * yThrowPitchFactor;
		// y = guiñada (horziontal)
		float yaw = transform.localPosition.x * positionYawFactor;
		// z = alabeo (rotación)
		float roll = xThrow * xThrowRollFactor;
		// Rotación local
		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}
}
