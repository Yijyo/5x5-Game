using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject moveEffectPrefab;
    [SerializeField]
    private float speed = 40;
    [SerializeField]
    private int effectCount = 5;
    

    private void Update()
    {

        while(effectCount > 0)
        {
            GameObject clone = Instantiate(moveEffectPrefab, transform.position, Quaternion.identity);
            clone.transform.localScale = new Vector3(100/effectCount *0.01f, 100 / effectCount * 0.01f, 100 / effectCount * 0.01f);
            clone.GetComponent<FollowPlayer>().Setup(transform,speed/effectCount);


            effectCount--;
        }
    }
}
