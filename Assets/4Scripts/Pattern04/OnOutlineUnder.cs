using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOutlineUnder : MonoBehaviour
{
    public void OnSprite()
    {
        gameObject.SetActive(true);
    }

    public void OffSprite()
    {
        gameObject.SetActive(false);
    }
}
