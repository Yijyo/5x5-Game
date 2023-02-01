using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern04Move : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private void Update()
    {
        Vector3 direction = Vector3.left;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
