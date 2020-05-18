using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Ghostmovement : MonoBehaviour
{
	public Transform[] waypoints;
	int current = 0;

	public float speed = 0.3f;


	void FixedUpdate()
	{

		if (Vector2.Distance(transform.position, waypoints[current].position) < 0.1f)
		{
			if (current == waypoints.Length) {
				current = 0;
			}
			else {
				current++;
			}
		}


		else
		{
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[current].position, speed);
			GetComponent<Rigidbody2D>().MovePosition(p);

		}

	Vector2 dir = waypoints[current].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.name == "pacman") {
			Destroy(co.gameObject);
			SceneManager.LoadScene("EndScreen");
		}
			
	}

}