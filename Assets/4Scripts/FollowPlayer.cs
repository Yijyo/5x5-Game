using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float speed;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}