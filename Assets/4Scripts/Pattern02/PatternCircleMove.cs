using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PatternCircleMove : MonoBehaviour
{
    [SerializeField]
    private float circleR;              // ������
    [SerializeField]
    private float objSpeed;             // ��� �ӵ�
    [SerializeField]
    private GameObject Standard;        // ���� ����ü ������Ʈ

    private float deg;                  // ����
    
    void Update()
    {
        deg += Time.deltaTime * objSpeed;
        if (deg < 360)
        {
            var rad = Mathf.Deg2Rad * (deg);
            var x = circleR * Mathf.Sin(rad);
            var y = circleR * Mathf.Cos(rad);
            transform.position = Standard.transform.position + new Vector3(x, y);
            transform.rotation = Quaternion.Euler(0, 0, deg * -1); //����� �ٶ󺸰� ���� ����
        }
        else
        {
            deg = 0;
        }
    }
}
