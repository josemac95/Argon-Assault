using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Efecto de muerte
	[Tooltip("FX prefab on enemy")] [SerializeField] GameObject deathFX;
	// Padre de los objetos creados en tiempo de ejecución
	[Tooltip("Parent (Spawned at Runtime)")] [SerializeField] Transform parent;

	// Referencia a la puntuación
	ScoreBoard scoreBoard;
	// Puntuación por impacto
	[SerializeField] int scorePerHit = 12;
	// Puntuación por muerte
	[SerializeField] int scorePerKill = 100;

	// Vida (en número de impactos)
	[SerializeField] int hits = 10;

	void Start()
	{
		// Añade el componente via script
		// Por si se actualiza el Asset Pack
		AddNonTriggerBoxCollider();
		// Busca el ScoreBoard
		scoreBoard = FindObjectOfType<ScoreBoard>();
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
		// Para evitar doble muerte por colisión simultánea
		if (hits > 0)
		{
			ProcessHit();
			// Si está muerto
			if (hits == 0)
			{
				KillEnemy();
			}
		}
	}

	// Procesa el impacto
	private void ProcessHit()
	{
		// Incrementa la puntuación por impacto
		scoreBoard.ScoreHit(scorePerHit);
		// Queda menos vida
		hits = hits - 1;
	}

	// Mata al enemigo
	private void KillEnemy()
	{
		// Puntuación por matar
		scoreBoard.ScoreHit(scorePerKill);
		// Efecto de muerte (instancia el prefab)
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		// Lo agrupa en la jerarquía
		fx.transform.parent = parent;
		// Destruye el enemigo
		Destroy(gameObject);
	}
}
