using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float limitSec;

    void Start()
    {
        Destroy(this.gameObject, limitSec);
    }
}
