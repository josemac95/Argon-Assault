﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	void Start()
	{
		// Añade el componente via script
		// Por si se actualiza el Asset Pack
		AddNonTriggerBoxCollider();
	}

	// Añade el collider (No trigger)
	private void AddNonTriggerBoxCollider()
	{
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		// Por defecto es así, pero es mejor asegurarse
		// Porque es importante para el funcionamiento
		boxCollider.isTrigger = false;
	}

	// Si choca una partícula con el objeto
	void OnParticleCollision(GameObject other)
	{
		Destroy(gameObject);
	}
}
