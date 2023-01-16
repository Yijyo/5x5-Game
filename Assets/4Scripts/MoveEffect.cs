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
    private float min = 0;
    [SerializeField]
    private float max = 100;
    [SerializeField]
    private int effectCount = 5;
    private float Scale;

    private void Update()
    {

        while(effectCount > 0)
        {
            Scale = SetScale(min, max, effectCount);
            GameObject clone = Instantiate(moveEffectPrefab, transform.position, Quaternion.identity);
            clone.transform.localScale = new Vector3(Scale, Scale,1);
            clone.GetComponent<FollowPlayer>().Setup(transform,speed/effectCount);


            effectCount--;
        }
    }

    private float SetScale(float min, float max, int effectCount)
    {
        return ((max-min)/effectCount+min)*0.01f;
    }
}
