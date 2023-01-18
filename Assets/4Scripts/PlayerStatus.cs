using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    /*[SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject pattern;*/
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        //player = GetComponent<GameObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pattern")
        {
            Debug.Log("Hit");
            OnDamaged();
        }
    }

    private void OnDamaged()
    {
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        Time.timeScale = 0;
        Invoke("OffDamaged", 1);
    }

    private void OffDamaged()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
