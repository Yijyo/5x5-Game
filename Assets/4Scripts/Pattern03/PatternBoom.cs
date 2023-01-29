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
        Invoke("Destroy", 1f);
        gameObject.SetActive(false);
    }

    private void Destroy()
    {
        
        Destroy(clone_pattern03);
        Destroy(gameObject);
    }
}