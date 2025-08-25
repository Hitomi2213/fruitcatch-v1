using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyOnTime : MonoBehaviour
{
    [SerializeField]
    float liveTime = 0.5f;
    void Start()
    {
        Destroy(gameObject, liveTime);
    }
}