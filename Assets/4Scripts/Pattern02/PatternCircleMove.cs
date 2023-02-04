using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PatternCircleMove : MonoBehaviour
{
    [SerializeField]
    private float circleR;              // 반지름
    [SerializeField]
    private float objSpeed;             // 원운동 속도
    [SerializeField]
    private GameObject Standard;        // 공전 기준체 오브젝트

    private float deg;                  // 각도
    
    void Update()
    {
        deg += Time.deltaTime * objSpeed;
        if (deg < 360)
        {
            var rad = Mathf.Deg2Rad * (deg);
            var x = circleR * Mathf.Sin(rad);
            var y = circleR * Mathf.Cos(rad);
            transform.position = Standard.transform.position + new Vector3(x, y);
            transform.rotation = Quaternion.Euler(0, 0, deg * -1); //가운데를 바라보게 각도 조절
        }
        else
        {
            deg = 0;
        }
    }
}
