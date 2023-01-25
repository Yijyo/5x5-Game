using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pattern" && gameObject.layer == 10)
        {
            Debug.Log("Hit");
            OnDamaged();
        }
    }

    private void OnDamaged()
    {
        // 11번 Layer == Importal Active
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // 피격 시 시간 정지
        gameManager.GetComponent<GameManager>().timeActive = false;

        // 1초간 11번 레이어 상태 및 무적 상태
        Invoke("OffDamaged", 1);
    }

    private void OffDamaged()
    {
        // 10번 Layer == Player 원래 상태로 되돌리기
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}