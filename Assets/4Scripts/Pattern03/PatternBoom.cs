using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PatternBoom : MonoBehaviour
{
    [SerializeField]
    private GameObject patternPrefab;

    private GameObject clone_pattern03;
    private float m_time;


    private void Start()
    {
        Destroy(gameObject, 3);
    }
    private void Update()
    {
        m_time += Time.deltaTime;
        if (m_time > 2)
        {
            Boom();
            m_time = 0;
        }
    }

    private void Boom()
    {
        clone_pattern03 = Instantiate(patternPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Destroy(clone_pattern03, 3);
    }


}