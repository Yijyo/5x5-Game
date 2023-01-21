using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatternSpawner : MonoBehaviour
{
    private string[] Pattern = new string[] { "pattern01", "pattern03" };


    [Header("TEST")]
    [SerializeField]
    private int 패턴번호 = 0;
    [Header("Common")]
    [SerializeField]
    private float delayTime = 1;
    [SerializeField]
    private bool clearPattern = false;  // 패턴의 클리어 조건 달성 여부


    [SerializeField]
    private PatternInfo[] patternInfo;


    private int N; // pattern Number


    public void Start()
    {
        
        N = RandomN();
        SpawnPattern();
    }


    
    private int RandomN()  // 랜덤으로 패턴 번호를 뽑아오는 함수
    {
        return Random.Range(패턴번호, 패턴번호);
    }


    
    private IEnumerator pattern01()
    {
        clearPattern = true;   // 이 패턴은 별도의 클리어 조건이 없습니다.
        int flag = 1;
        int x=0, y=0, z=0;
        int hell = 1;  //hell 난이도 테스트용.
        Vector3 direction = new Vector3(0, 0, 0);

        int SetXy(int num)
        {
            flag *= -1;
            if (num == 0)     // 상, 하 움직임 
            {
                if (flag == -1) z = -90;
                else z = 90;

                x = Random.Range(-2, 3);
                return -6 * flag;
            }
            else              // 좌, 우 움직임
            {
                if (flag == -1) z = 180;
                else z = 0;
                y = Random.Range(-2, 3);
                return -10 * flag;
            }
        }
        
        while (true)
        {
            int num = Random.Range(0, 2); //num = 0 일시 상하 , 1일시 좌우
            if (num == 0)  // 상,하 움직임
            {
                y = SetXy(num);
                direction = new Vector3(0, flag, 0);
            }
            if (num == 1) // 좌,우 움직임
            {
                x = SetXy(num);
                direction = new Vector3(flag, 0, 0);

            }

            //좌 -> 우 일때 num = 1 , flag = 1
            //우 -> 좌 일때 num = 1 , flag = -1
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
        clearPattern = true; // 이 패턴은 별도의 클리어 조건이 없습니다.
        float waitTime = 1;
        List<GameObject> clone_patter03 = new List<GameObject>();
        while (true)
        {
            // 랜덤 좌표 x, y값 생성
            int x = Random.Range(-2, 3);
            int y = Random.Range(-2, 3);

            Vector3 position_bomb = new Vector3(x, y, 0);

            // 랜덤 좌표 x, y에 폭탄 이미지 생성
            GameObject clone_bomb = Instantiate(patternInfo[N].patternPrefab[1], position_bomb, Quaternion.identity);

            // waittime 기다리고
            yield return new WaitForSeconds(waitTime);

            // 폭탄 이미지 제거
            Destroy(clone_bomb);

            // 랜덤 좌표 x, y기준으로 3x3 크기의 패턴 생성
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
            // 3x3 패턴 제거
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
            StopCoroutine(Pattern[N]);                                           // 이전에 실행되던 패턴 Stop
            N = RandomN();                                                       // 새로운 패턴 번호 뽑기
            yield return new WaitForSeconds(delayTime);                          // 딜레이 시간 대기
            StartCoroutine(Pattern[N]);                                          // 새로운 패턴 Start
            yield return new WaitForSeconds(patternInfo[N].patternTime);         // 패턴 지속시간 만큼 대기
            while (clearPattern == false) yield return new WaitForSeconds(1);    // 패턴 클리어 조건 달성할 때 까지 대기
            

            
        }
    } 

}




[System.Serializable]
public struct PatternInfo
{
    public GameObject[] patternPrefab; //패턴 프리팹
    public float spawnCycle;  // 패턴 생성 주기 
    public float patternTime; // 패턴 지속시간
}