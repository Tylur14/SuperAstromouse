using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Blink : MonoBehaviour
{
    private bool _isVisible;
    [SerializeField] private bool canBlink;
    [SerializeField] private float timerLength;
    private float _timer;
    private Renderer _render;

    private void Start()
    {
        _render = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(canBlink)
            if (_timer > 0)
                _timer -= Time.deltaTime;
            else if (_timer <= 0)
                Blink();
    }

    void Blink()
    {
        _isVisible = !_isVisible;
        _render.enabled = _isVisible;
        _timer = timerLength;
    }
}
