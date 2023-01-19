using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pattern03 : MonoBehaviour
{
    [SerializeField]
    private GameObject patternPrefab;
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private float spawnCycle;

    private List<GameObject> clone;

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
            int x = Random.Range(-2, 3);
            int y = Random.Range(-2, 3);

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    Vector3 position = new Vector3(x + i, y + j, 0);
                    //clone.Add(Instantiate(patternPrefab, position, Quaternion.identity));
                }
            }
            yield return new WaitForSeconds(spawnCycle);
            /*foreach (GameObject go in clone)
            {
                Destroy(go);
            }*/
        }
    }
}
