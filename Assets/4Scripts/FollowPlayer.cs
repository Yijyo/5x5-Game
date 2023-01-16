using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    public float lerpSpeed;
    private Transform player;

    public void Setup(Transform player,float lerpSpeed)
    {
        this.player = player;
        this.lerpSpeed = lerpSpeed;

    }
    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, lerpSpeed * Time.deltaTime);
    }
}