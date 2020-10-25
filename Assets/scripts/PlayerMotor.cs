using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 boundaries;
    private float _xInput;
    
    private Vector3 _vel = Vector3.zero;
    void Update()
    {
        if (Input.GetMouseButton(0))
            _xInput = -1;
        if (Input.GetMouseButton(1))
            _xInput = 1;
        if(!Input.GetMouseButton(0) && !Input.GetMouseButton(1)) 
            _xInput = 0;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var pos = transform.position;
        pos.x += (moveSpeed) * _xInput;
        pos.x = Mathf.Clamp(pos.x, boundaries.x, boundaries.y);
        transform.position = Vector3.SmoothDamp(transform.position,pos,ref _vel, moveSpeed * Time.deltaTime);
    }
}
