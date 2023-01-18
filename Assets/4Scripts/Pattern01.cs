using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern01 : MonoBehaviour
{
    [SerializeField]
    private GameObject patternPrefab;
    [SerializeField]
    private float spawnCycle;
    private int flag = 1;
    private int x, y;
    private Vector3 direction;


    private void OnEnable()
    {
        StartCoroutine(nameof(SpawnPattern));

    }

    private void OnDisable()
    {
        StopCoroutine(nameof(SpawnPattern));
    }

    private IEnumerator SpawnPattern()
    {
        float waitTime = 1;
        yield return new WaitForSeconds(waitTime);

        while (true)
        {
            int num = Random.Range(0, 2); //num = 0 �Ͻ� ���� , 1�Ͻ� �¿�
            if (num == 0)  // ��,�� ������
            {
                y = SetXy(num);
                direction = new Vector3(0,flag,0);
            }
            if (num == 1) // ��,�� ������
            {
                x = SetXy(num);
                direction = new Vector3(flag, 0, 0);
            }

            Vector3 position = new Vector3(x, y, 0);
            GameObject clone = Instantiate(patternPrefab, position, Quaternion.identity);
            clone.GetComponent<PatternSquareMove>().MoveTo(direction);


            yield return new WaitForSeconds(spawnCycle);
        }
    }



    private int SetXy(int num)
    {
        flag *= -1;
        if (num == 0)     // ��, �� ������ 
        {
            x = Random.Range(-2, 3);
            return -6 * flag;
        }
        else              // ��, �� ������
        {
            y = Random.Range(-2, 3);
            return -10 * flag;
        }
    }
}