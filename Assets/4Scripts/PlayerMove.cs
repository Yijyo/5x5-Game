using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }
        if (Mathf.Abs(transform.position.x) > 2 )
        {
            transform.position = new Vector3(reposition(transform.position.x), transform.position.y, 0);
        }
        if (Mathf.Abs(transform.position.y) > 2)
        {
            transform.position = new Vector3(transform.position.x, reposition(transform.position.y), 0);
        }
    }

    private float reposition(float t)
    {
        float x = t * -2 / 3;
        return x;
    }
}
