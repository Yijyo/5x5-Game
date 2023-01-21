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
    private int x, y, z;
    private Vector3 direction;

    private IEnumerator SpawnPattern()
    {
        float waitTime = 3;
        yield return new WaitForSeconds(waitTime);

        while (true)
        {
            int num = Random.Range(0, 2); //num = 0 �Ͻ� ���� , 1�Ͻ� �¿�
            if (num == 0)  // ��,�� ������
            {
                y = SetXy(num);
                direction = new Vector3(0, flag, 0);
            }
            if (num == 1) // ��,�� ������
            {
                x = SetXy(num);
                direction = new Vector3(flag, 0, 0);
        
            }

            //�� -> �� �϶� num = 1 , flag = 1
            //�� -> �� �϶� num = 1 , flag = -1
            Vector3 position = new Vector3(x, y, 0);
            GameObject clone = Instantiate(patternPrefab, position, Quaternion.identity);
            clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, z);
            clone.GetComponent<PatternSquareMove>().MoveTo(direction);
 
            yield return new WaitForSeconds(spawnCycle);
        }
    }

    private int SetXy(int num)
    {
        flag *= -1;
        if (num == 0)     // ��, �� ������ 
        {
            if (flag == -1) z = -90;
            else z = 90;

            x = Random.Range(-2, 3);
            return -6 * flag;
        }
        else              // ��, �� ������
        {
            if (flag == -1) z = 180;
            else z = 0;
            y = Random.Range(-2, 3);
            return -10 * flag;
        }
    }
}