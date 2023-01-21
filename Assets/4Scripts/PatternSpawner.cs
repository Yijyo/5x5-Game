using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Patterns { pattern01 = 0, pattern03 }

public class PatternSpawner : MonoBehaviour
{

    [Header("Common")]
    [SerializeField]
    private float delayTime = 3;
    [SerializeField]
    private GameObject[] patternPrefab;

    [Header("Pattern01")]
    [SerializeField]
    private GameObject pt01Prefab;
    [SerializeField]
    private float pt01SpawnCycle;
    [SerializeField]
    private float pt01time = 10;

    [Header("Pattern03")]
    [SerializeField]
    private GameObject pt03Prefab;
    [SerializeField]
    private GameObject pt03Boom;
    [SerializeField]
    private float pt03SpawnCycle = 1;
    [SerializeField]
    private float pt03time = 10;

     

    private Patterns pattern = Patterns.pattern03;
    public void Start()
    {
        ChangePattern(pattern);
    }

    public void ChangePattern(Patterns newPattern)
    {
        StopCoroutine(newPattern.ToString());
        StartCoroutine("patternDelay"); //���ϰ� ���� ���� ������ �ð�
        StartCoroutine("patternTime",pt01time); //���� ���ӽð�

        //������ �ð� �ڷ�ƾ�� ���� ���ӽð� �ڷ�ƾ�� �ΰ� ����°� �ּ��ΰ��� ���� ��� .... �ϴ� �̷��� �ϰڽ��ϴ�

    }



    
    private IEnumerator pattern01()
    {

        int flag = 1;
        int x=0, y=0, z=0;
        Vector3 direction = new Vector3(0, 0, 0);

        int SetXy(int num)
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
            GameObject clone = Instantiate(pt01Prefab, position, Quaternion.identity);
            clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, z);
            clone.GetComponent<PatternSquareMove>().MoveTo(direction);

            yield return new WaitForSeconds(pt01SpawnCycle);
        }
    }
    private IEnumerator pattern03()
    {
        float waitTime = 1;
        List<GameObject> clone_patter03 = new List<GameObject>();
        while (true)
        {
            // ���� ��ǥ x, y�� ����
            int x = Random.Range(-2, 3);
            int y = Random.Range(-2, 3);

            Vector3 position_bomb = new Vector3(x, y, 0);

            // ���� ��ǥ x, y�� ��ź �̹��� ����
            GameObject clone_bomb = Instantiate(pt03Boom, position_bomb, Quaternion.identity);

            // waittime ��ٸ���
            yield return new WaitForSeconds(waitTime);

            // ��ź �̹��� ����
            Destroy(clone_bomb);

            // ���� ��ǥ x, y�������� 3x3 ũ���� ���� ����
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    Vector3 position = new Vector3(x + i, y + j, 0);
                    GameObject clone_pattern03 = Instantiate(pt03Prefab, position, Quaternion.identity);
                    clone_patter03.Add(clone_pattern03);
                }
            }
            yield return new WaitForSeconds(pt03SpawnCycle);
            // 3x3 ���� ����
            foreach (GameObject go in clone_patter03)
            {
                Destroy(go);
            }
        }
    }




    private IEnumerator patternTime(float time)   //���� ���ӽð�
    {
        yield return new WaitForSeconds(time);
        ChangePattern(pattern);
    }
    private IEnumerator patternDelay()   //���ϰ� ���� ���� ������ �ð�
    {
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(pattern.ToString());
    }

}
