using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern04PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float jumpPower;
    
    Rigidbody2D rigid;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Floor"));

        if (Input.GetButtonDown("Jump") && rayHit.collider != null)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}

