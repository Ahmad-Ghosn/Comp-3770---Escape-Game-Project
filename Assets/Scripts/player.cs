using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D raycastHit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //resetting the moveDelta
        moveDelta = new Vector3(x,y,0);

        //switches directions
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }else if (moveDelta.x < 0) 
        { 
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //setting up collision
        raycastHit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector3(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        
        //check if we can move in this direction
        if(raycastHit.collider == null)
        {
            //allow movement if there is no collision
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //repeating for the x axis
        raycastHit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector3(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        //check if we can move in this direction
        if (raycastHit.collider == null)
        {
            //allow movement if there is no collision
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }
}
