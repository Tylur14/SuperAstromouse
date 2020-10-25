using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float maxHeight = 273.07f;

    [SerializeField] private float moveSpeed;
    void Update()
    {
        var pos = transform.position;
        pos.y += moveSpeed * Time.deltaTime;
        if (pos.y > maxHeight)
            pos.y = 0;
        transform.position = pos;
    }
}
