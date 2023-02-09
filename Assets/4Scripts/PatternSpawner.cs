using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatternSpawner : MonoBehaviour
{
    private string[] Pattern = new string[] { "pattern01", "pattern02", "pattern03", "pattern04" };

    private PatternManager patternManager;

    [Header("TEST")]
    [SerializeField]
    private int 패턴시작번호 = 0;
    [SerializeField]
    private int 패턴끝번호 = 1;
    [Header("Common")]
    [SerializeField]
    private float delayTime = 1;
    [SerializeField]
    private PatternInfo[] patternInfo;

    private int N; // pattern Number

    public void Start()
    {
        N = RandomN();
        patternManager = GetComponent<PatternManager>();
        patternManager.InfoPattern(patternInfo[N]);
        StartCoroutine("SpawnPattern");
    }
    private int RandomN()  // 랜덤으로 패턴 번호를 뽑아오는 함수
    {
        return Random.Range(패턴시작번호, 패턴끝번호+1);
    }
    private IEnumerator SpawnPattern() 
    {
        while(true){
            patternManager.StopCoroutine(Pattern[N]);                                           // 이전에 실행되던 패턴 Stop
            N = RandomN();                                                                      // 새로운 패턴 번호 뽑기
            patternManager.InfoPattern(patternInfo[N]);                                         // patternManager에 뽑은 번호의 패턴 정보 전달
            yield return new WaitForSeconds(delayTime);                                         // 딜레이 시간 대기
            patternManager.Timer = 0;
            patternManager.StartCoroutine(Pattern[N]);                                          // 새로운 패턴 Start
            yield return new WaitForSeconds(patternInfo[N].patternTime);                        // 패턴 지속시간 만큼 대기
            while (patternManager.clearPattern == false) yield return new WaitForSeconds(1);    // 패턴 클리어 조건 달성할 때 까지 대기     
        }
    } 

}


[System.Serializable]
public struct PatternInfo
{
    public GameObject[] patternPrefab; //패턴 프리팹
    public float spawnCycle;  // 패턴 생성 주기 
    public float patternTime; // 패턴 지속시간
    public bool clearPattern; // 별도의 클리어 조건 충족 여부 (없으면 체크)

}