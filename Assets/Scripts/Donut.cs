using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Donut : MonoBehaviour
{
	

	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.gameObject.name == "pacman")
		{
			Destroy(gameObject);

		}
		
	}
	
}
