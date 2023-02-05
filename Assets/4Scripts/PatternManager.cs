using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Desc : ���ϵ��� �ڵ尡 �ִ� Ŭ����, PatternSpawner�� ���� ���ù��� ������ �����Ű�� ����.
 * InfoPattern() : PatternSpawner�� ���� �����ų ������ ������ �޾ƿ´�.
 */
public class PatternManager : MonoBehaviour
{
    [Header("���� ���� ����")]
    [SerializeField]
    private GameObject[] patternPrefab; //���� ������
    [SerializeField]
    private float spawnCycle;  // ���� ���� �ֱ� 
    [SerializeField]
    private float patternTime; // ���� ���ӽð�
    [SerializeField]
    public bool clearPattern = false; // ������ Ŭ���� ���� ���� ���� (������ üũ)
    [SerializeField]
    public float Timer = 0;
    [Header("...")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject playerShadow;


    private void Update()
    {
        Timer += Time.deltaTime;
    }

    public void InfoPattern(PatternInfo Info)   //PatternSpawner�� ���� ������ ������ �޾ƿ�
    {
        patternPrefab = Info.patternPrefab;
        spawnCycle = Info.spawnCycle;
        patternTime = Info.patternTime;
        clearPattern = Info.clearPattern;

    }
    

    private IEnumerator pattern01()
    {
        clearPattern = true;   // �� ������ ������ Ŭ���� ������ �����ϴ�.
        int flag = 1;
        int x = 0, y = 0, z = 0;
        int hell = 1;  //hell ���̵� �׽�Ʈ��.
        int N01 = 0; //hell ���̵� �׽�Ʈ��
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
            GameObject clone = Instantiate(patternPrefab[N01], position, Quaternion.identity);
            clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, z);
            clone.GetComponent<PatternSquareMove>().MoveTo(direction);

            yield return new WaitForSeconds(spawnCycle);
            hell++;
            if (hell > 20)
            {
                N01 = 1;
                spawnCycle = 0.3f;
            }
        }
    }

    private IEnumerator pattern02()
    {
        clearPattern = true; // �� ������ ������ Ŭ���� ������ �����ϴ�.
        while (true)
        {
            // ���� ��ǥ x, y�� ����
            int x = Random.Range(-3, 4);
            int y = Random.Range(-2, 3);

            Vector3 position_circle = new Vector3(x, y, 0);

            // ���� ��ǥ x, y�� ���� ����ü Ŭ�� ����
            GameObject clone_circle = Instantiate(patternPrefab[0], position_circle, Quaternion.identity);
            yield return new WaitForSeconds(spawnCycle);
        }
    }

    private IEnumerator pattern03()
    {
        clearPattern = true; // �� ������ ������ Ŭ���� ������ �����ϴ�.
        List<GameObject> clone_patter03 = new List<GameObject>();
        while (true)
        {
            // ���� ��ǥ x, y�� ����
            int x = Random.Range(-2, 3);
            int y = Random.Range(-2, 3);

            Vector3 position_bomb = new Vector3(x, y, 0);

            // ���� ��ǥ x, y�� ��ź �̹��� ����
            GameObject clone_bomb = Instantiate(patternPrefab[0], position_bomb, Quaternion.identity);
            yield return new WaitForSeconds(spawnCycle);
        }
    }

    private void OnPlayer()
    {
        player.SetActive(true);
        
    }

    private IEnumerator pattern04()
    {
        
        clearPattern = true;   // �� ������ ������ Ŭ���� ������ �����ϴ�.
        
        GameObject clone_player = Instantiate(patternPrefab[3], Vector3.zero, Quaternion.identity);

        Vector3 floorPosition = new Vector3(0, -2.5f, 0);
        GameObject clone_floor = Instantiate(patternPrefab[2], floorPosition, Quaternion.identity);
        
        Destroy(clone_player, patternTime);
        Destroy(clone_floor, patternTime);
        
        player.SetActive(false);
        

        Invoke("OnPlayer", patternTime);

        while (true)
        {
            int num = Random.Range(0, 2);
            float positionY = 0;
            if (num == 0) positionY = -1.5f;
            else if (num == 1) positionY = -0.5f;

            Vector3 position = new Vector3(9, positionY, 0);
            GameObject clone_patter04 = Instantiate(patternPrefab[num], position, Quaternion.identity);

            yield return new WaitForSeconds(spawnCycle);
        }
    }
}
