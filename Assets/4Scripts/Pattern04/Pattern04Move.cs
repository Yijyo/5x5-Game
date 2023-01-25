using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern04Move : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Vector3 direction = Vector3.left;
    private void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
