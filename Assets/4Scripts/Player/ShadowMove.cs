using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMove : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime*50);   
    }
}
