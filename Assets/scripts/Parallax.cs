using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length, _startPos;
    private GameObject _cam;
    [SerializeField] private float parallaxEffect;

    private void Start()
    {
        _cam = Camera.main.gameObject;
        _startPos = transform.position.y;
        _length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        float temp = _cam.transform.position.y * (1 - parallaxEffect);
        float dist = (_cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(transform.position.x,_startPos + dist,transform.position.z);
        if (temp > _startPos + _length) _startPos += _length;
        else if (temp < _startPos - _length) _startPos -= _length;
    }
}    
