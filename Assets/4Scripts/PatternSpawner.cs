using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatternSpawner : MonoBehaviour
{
    private string[] Pattern = new string[] { "pattern01", "pattern02", "pattern03", "pattern04" };

    private PatternManager patternManager;

    [Header("TEST")]
    [SerializeField]
    private int ���Ͻ��۹�ȣ = 0;
    [SerializeField]
    private int ���ϳ���ȣ = 1;
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
    private int RandomN()  // �������� ���� ��ȣ�� �̾ƿ��� �Լ�
    {
        return Random.Range(���Ͻ��۹�ȣ, ���ϳ���ȣ+1);
    }
    private IEnumerator SpawnPattern() 
    {
        while(true){
            patternManager.StopCoroutine(Pattern[N]);                                           // ������ ����Ǵ� ���� Stop
            N = RandomN();                                                                      // ���ο� ���� ��ȣ �̱�
            patternManager.InfoPattern(patternInfo[N]);                                         // patternManager�� ���� ��ȣ�� ���� ���� ����
            yield return new WaitForSeconds(delayTime);                                         // ������ �ð� ���
            patternManager.Timer = 0;
            patternManager.StartCoroutine(Pattern[N]);                                          // ���ο� ���� Start
            yield return new WaitForSeconds(patternInfo[N].patternTime);                        // ���� ���ӽð� ��ŭ ���
            while (patternManager.clearPattern == false) yield return new WaitForSeconds(1);    // ���� Ŭ���� ���� �޼��� �� ���� ���     
        }
    } 

}


[System.Serializable]
public struct PatternInfo
{
    public GameObject[] patternPrefab; //���� ������
    public float spawnCycle;  // ���� ���� �ֱ� 
    public float patternTime; // ���� ���ӽð�
    public bool clearPattern; // ������ Ŭ���� ���� ���� ���� (������ üũ)

}