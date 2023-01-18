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
    private Vector3 direction = new Vector3(1, 0, 0).normalized;

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
            int x = RandomX(); int y = RandomY();
            if (x == 10) { Vector3 direction = new Vector3(-1, 0, 0).normalized; }
            if (x == -10) { Vector3 direction = new Vector3(1, 0, 0).normalized; }
            if (y == 5) { Vector3 direction = new Vector3(0, -1, 0).normalized; }
            if (y == -5) { Vector3 direction = new Vector3(0, 1, 0).normalized; }

            Vector3 position = new Vector3(x, y, 0);
            Instantiate(patternPrefab, position, Quaternion.identity);
            patternPrefab.GetComponent<PatternSquareMove>().MoveTo(direction);


            yield return new WaitForSeconds(spawnCycle);
        }
    }

    private int RandomX()
    {
        flag *= -1;
        int num = Random.Range(-10, 11);

        if (num > -3 && num < 3)
        {
            return num;
        }

        else num = 10;

        return num * flag;
    }
    private int RandomY()
    {
        flag *= -1;
        int num = Random.Range(-6, 6);

        if (num > -3 && num < 3)
        {
            return num;
        }

        else num = 5;

        return num * flag;
    }
}
