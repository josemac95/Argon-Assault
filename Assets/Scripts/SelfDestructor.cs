using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
	// Tiempo de destrucción
	[Tooltip("In seconds")] [SerializeField] float destructionTime = 3f;

	void Start()
	{
		Destroy(gameObject, destructionTime);
	}
}
