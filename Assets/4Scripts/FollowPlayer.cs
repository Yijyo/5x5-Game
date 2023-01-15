using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float lerpSpeed;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, lerpSpeed * Time.deltaTime);
    }
}