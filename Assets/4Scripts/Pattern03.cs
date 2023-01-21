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
    private GameObject patternPrefabBomb;
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private float spawnCycle;

    private List<GameObject> clone_patter03 = new List<GameObject>();

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
            // ���� ��ǥ x, y�� ����
            int x = Random.Range(-2, 3);
            int y = Random.Range(-2, 3);

            Vector3 position_bomb = new Vector3(x, y, 0);

            // ���� ��ǥ x, y�� ��ź �̹��� ����
            GameObject clone_bomb = Instantiate(patternPrefabBomb, position_bomb, Quaternion.identity);

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
                    GameObject clone_pattern03 = Instantiate(patternPrefab, position, Quaternion.identity);
                    clone_patter03.Add(clone_pattern03);
                }
            }
            yield return new WaitForSeconds(spawnCycle);
            // 3x3 ���� ����
            foreach (GameObject go in clone_patter03)
            {
                Destroy(go);
            }
        }
    }
}
