using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatternSpawner : MonoBehaviour
{
    private string[] Pattern = new string[] { "pattern01", "pattern03" };


    [Header("TEST")]
    [SerializeField]
    private int ���Ϲ�ȣ = 0;
    [Header("Common")]
    [SerializeField]
    private float delayTime = 1;
    [SerializeField]
    private bool clearPattern = false;  // ������ Ŭ���� ���� �޼� ����


    [SerializeField]
    private PatternInfo[] patternInfo;


    private int N; // pattern Number


    public void Start()
    {
        
        N = RandomN();
        SpawnPattern();
    }


    
    private int RandomN()  // �������� ���� ��ȣ�� �̾ƿ��� �Լ�
    {
        return Random.Range(���Ϲ�ȣ, ���Ϲ�ȣ);
    }


    
    private IEnumerator pattern01()
    {
        clearPattern = true;   // �� ������ ������ Ŭ���� ������ �����ϴ�.
        int flag = 1;
        int x=0, y=0, z=0;
        int hell = 1;  //hell ���̵� �׽�Ʈ��.
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
            GameObject clone = Instantiate(patternInfo[N].patternPrefab[0], position, Quaternion.identity);
            clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, z);
            clone.GetComponent<PatternSquareMove>().MoveTo(direction);

            yield return new WaitForSeconds(patternInfo[N].spawnCycle);
            hell++;
            if (hell > 30)
                patternInfo[N].spawnCycle = 0.2f;
        }
    }
    private IEnumerator pattern03()
    {
        clearPattern = true; // �� ������ ������ Ŭ���� ������ �����ϴ�.
        float waitTime = 1;
        List<GameObject> clone_patter03 = new List<GameObject>();
        while (true)
        {
            // ���� ��ǥ x, y�� ����
            int x = Random.Range(-2, 3);
            int y = Random.Range(-2, 3);

            Vector3 position_bomb = new Vector3(x, y, 0);

            // ���� ��ǥ x, y�� ��ź �̹��� ����
            GameObject clone_bomb = Instantiate(patternInfo[N].patternPrefab[1], position_bomb, Quaternion.identity);

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
                    GameObject clone_pattern03 = Instantiate(patternInfo[N].patternPrefab[0], position, Quaternion.identity);
                    clone_patter03.Add(clone_pattern03);
                }
            }
            yield return new WaitForSeconds(patternInfo[N].spawnCycle);
            // 3x3 ���� ����
            foreach (GameObject go in clone_patter03)
            {
                Destroy(go);
            }
        }
    }



    public void SpawnPattern()
    {
        StartCoroutine("StartPattern"); 
    }

    private IEnumerator StartPattern() 
    {
        while(true){
            StopCoroutine(Pattern[N]);                                           // ������ ����Ǵ� ���� Stop
            N = RandomN();                                                       // ���ο� ���� ��ȣ �̱�
            yield return new WaitForSeconds(delayTime);                          // ������ �ð� ���
            StartCoroutine(Pattern[N]);                                          // ���ο� ���� Start
            yield return new WaitForSeconds(patternInfo[N].patternTime);         // ���� ���ӽð� ��ŭ ���
            while (clearPattern == false) yield return new WaitForSeconds(1);    // ���� Ŭ���� ���� �޼��� �� ���� ���
            

            
        }
    } 

}




[System.Serializable]
public struct PatternInfo
{
    public GameObject[] patternPrefab; //���� ������
    public float spawnCycle;  // ���� ���� �ֱ� 
    public float patternTime; // ���� ���ӽð�
}