using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Si choca una partícula con el objeto
	void OnParticleCollision(GameObject other)
	{
		Destroy(gameObject);
	}
}
