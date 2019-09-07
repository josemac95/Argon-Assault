using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
	// Puntuación
	int score;
	// Texto
	Text scoreText;

	void Start()
	{
		// Componente de texto
		// GetComponent<Text>() hace lo mismo, sin gameObject
		// Pero lo pongo por coherencia con AddComponent
		scoreText = gameObject.GetComponent<Text>();
		// Actualiza la UI
		scoreText.text = score.ToString();
	}

	// Función para actualizar la puntuación
	public void ScoreHit(int scorePerHit)
	{
		// Suma la puntuación del impacto
		score = score + scorePerHit;
		// Actualiza la UI
		scoreText.text = score.ToString();
	}
}
