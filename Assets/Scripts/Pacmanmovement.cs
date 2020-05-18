using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pacmanmovement : MonoBehaviour
{
    public float speed = 0.2f;
    Vector2 destination = Vector2.zero;


    void Start()
    {
        destination = transform.position;
    }

    void FixedUpdate()
    {

        Vector2 p = Vector2.MoveTowards(transform.position, destination, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // input to move
        if ((Vector2)transform.position == destination)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                destination = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                destination = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                destination = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                destination = (Vector2)transform.position - Vector2.right;
        }


        Vector2 dir = destination - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
    // if Pacman collides with donut >> speed increases 
    IEnumerator Donut()
    {
        speed = 1f;
        yield return new WaitForSeconds(0.5f);
        speed = 0.4f;

    }


    void OnTriggerEnter2D(Collider2D co)
    {
   
        if (co.gameObject.name == "donut")

        {
            StopCoroutine(Donut());                
            StartCoroutine(Donut());               
        }
        if (GameObject.FindGameObjectsWithTag("Donut").Length == 0)
        {
            SceneManager.LoadScene("Winner");
        }
    } 
 }


