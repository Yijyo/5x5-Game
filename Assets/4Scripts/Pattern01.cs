using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern01 : MonoBehaviour
{
    [SerializeField]
    private GameObject patternPrefab;
    [SerializeField]
    private float spawnCycle;

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
            Vector3 position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            Instantiate(patternPrefab, position, Quaternion.identity);

            yield return new WaitForSeconds(spawnCycle);
        }
    }

    private int RandomX()
    {
        int num = 0;

        return num;
    }
}
