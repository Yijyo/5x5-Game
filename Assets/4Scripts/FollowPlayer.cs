using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    public float lerpSpeed;
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Setup(Transform player,float lerpSpeed)
    {
        this.player = player;
        this.lerpSpeed = lerpSpeed;

    }
    private void Update()
    {   
        if(player.GetComponent<SpriteRenderer>().color.a == 0.4f) spriteRenderer.color = new Color(1, 1, 1, 0.3f);
        else spriteRenderer.color = new Color(1, 1, 1, 1);
        transform.position = Vector2.Lerp(transform.position, player.position, lerpSpeed * Time.deltaTime);
    }
}