using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Desc : 패턴들의 코드가 있는 클래스, PatternSpawner로 부터 지시받은 패턴을 실행시키는 역할.
 * InfoPattern() : PatternSpawner로 부터 실행시킬 패턴의 정보를 받아온다.
 */
public class PatternManager : MonoBehaviour
{
    [Header("현재 패턴 정보")]
    [SerializeField]
    private GameObject[] patternPrefab; //패턴 프리팹
    [SerializeField]
    private float spawnCycle;  // 패턴 생성 주기 
    [SerializeField]
    private float patternTime; // 패턴 지속시간
    [SerializeField]
    public bool clearPattern = false; // 별도의 클리어 조건 충족 여부 (없으면 체크)
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

    public void InfoPattern(PatternInfo Info)   //PatternSpawner로 부터 패턴의 정보를 받아옴
    {
        patternPrefab = Info.patternPrefab;
        spawnCycle = Info.spawnCycle;
        patternTime = Info.patternTime;
        clearPattern = Info.clearPattern;

    }
    

    private IEnumerator pattern01()
    {
        clearPattern = true;   // 이 패턴은 별도의 클리어 조건이 없습니다.
        int flag = 1;
        int x = 0, y = 0, z = 0;
        int hell = 1;  //hell 난이도 테스트용.
        int N01 = 0; //hell 난이도 테스트용
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
        clearPattern = true; // 이 패턴은 별도의 클리어 조건이 없습니다.
        while (true)
        {
            // 랜덤 좌표 x, y값 생성
            int x = Random.Range(-3, 4);
            int y = Random.Range(-2, 3);

            Vector3 position_circle = new Vector3(x, y, 0);

            // 랜덤 좌표 x, y에 공전 기준체 클론 생성
            GameObject clone_circle = Instantiate(patternPrefab[0], position_circle, Quaternion.identity);
            yield return new WaitForSeconds(spawnCycle);
        }
    }

    private IEnumerator pattern03()
    {
        clearPattern = true; // 이 패턴은 별도의 클리어 조건이 없습니다.
        List<GameObject> clone_patter03 = new List<GameObject>();
        while (true)
        {
            // 랜덤 좌표 x, y값 생성
            int x = Random.Range(-2, 3);
            int y = Random.Range(-2, 3);

            Vector3 position_bomb = new Vector3(x, y, 0);

            // 랜덤 좌표 x, y에 폭탄 이미지 생성
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
        
        clearPattern = true;   // 이 패턴은 별도의 클리어 조건이 없습니다.
        
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
