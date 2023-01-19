using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSquareMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector3 moveDirection;
    [SerializeField]
    private float ss = 1;

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * ss * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
