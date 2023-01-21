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
    private float rotateSpeed = 1;

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
