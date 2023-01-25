using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern04Move : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public float pattern04_time;

    private Vector3 direction = Vector3.left;
    private void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
