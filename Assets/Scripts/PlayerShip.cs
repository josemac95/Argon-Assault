using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour
{
	void Start()
	{

	}

	void Update()
	{
		float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		print(horizontalThrow);
	}
}
