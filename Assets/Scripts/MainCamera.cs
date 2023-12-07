using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform findPlayer;
    public float xbound = 0.15f;
    public float ybound = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        float deltax = findPlayer.position.x - transform.position.x;

        //check to see if you are in the bounds on the x axis for camera tracking
        if(deltax > xbound || deltax < -xbound)
        {
            if (transform.position.x < findPlayer.position.x) 
            { 
                delta.x = deltax - xbound;
            }
            else
            {
                delta.x = deltax + xbound;
            }
        }

        float deltay = findPlayer.position.y - transform.position.y;

        //check to see if you are in the bounds on the y axis for camera tracking
        if(deltay > ybound || deltay < -ybound)
        {
            if (transform.position.y < findPlayer.position.y)
            {
                delta.y = deltay - ybound;
            }
            else
            {
                delta.y = deltay + ybound;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
