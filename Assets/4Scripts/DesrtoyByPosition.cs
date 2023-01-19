using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesrtoyByPosition : MonoBehaviour
{
    void Update()
    {
        if(Mathf.Abs(transform.position.x) > 10 ||
            Mathf.Abs(transform.position.y) > 6)
        {
            Destroy(gameObject);
        }
    }

}
