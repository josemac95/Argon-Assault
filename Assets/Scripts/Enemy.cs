using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Efecto de muerte
	[Tooltip("FX prefab on enemy")] [SerializeField] GameObject deathFX;
	// Padre de los objetos creados en tiempo de ejecución
	[Tooltip("Parent (Spawned at Runtime)")] [SerializeField] Transform parent;

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
		// Efecto de muerte (instancia el prefab)
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		// Lo agrupa en la jerarquía
		fx.transform.parent = parent;
		// Destruye el enemigo
		Destroy(gameObject);
	}
}
