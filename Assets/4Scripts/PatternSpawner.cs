using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public enum Patterns { pattern01 = 0, pattern02 }
public class PatternSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private Pattern01 pattern01;
    private int phase = 1;
    //private Patterns pattern = Patterns.pattern01;


    public void Start()
    {
        ChangePattern();
    }

    

    public void ChangePattern()
    {
        //pattern01 = GetComponent<Pattern01>();
        pattern01.StopCoroutine("SpawnPattern");
        pattern01.StartCoroutine("SpawnPattern");
        Invoke("ChangePattern", 10);
    }


    private float GameSetSec()
    {
        //게임 시간을 받는 함수
        return gameManager.GetComponent<GameManager>().timeStart;
    }
}
