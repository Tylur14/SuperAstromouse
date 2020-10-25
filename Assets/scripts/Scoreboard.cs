using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TextMeshPro display;
    public int score;
    private bool _canTick;
    public void StartTracking()
    {
        Reset();
        _canTick = true;
        Tick();
    }

    void Tick()
    {
        if(_canTick)
            StartCoroutine(TickScore());
        IEnumerator TickScore()
        {
            yield return new WaitForSeconds(1);
            score++;
            SetDisplay();
            Tick();
        }
    }
    

    public void StopTracking()
    {
        StopAllCoroutines();
        _canTick = false;
        SetDisplay();
    }

    public void Reset()
    {
        score = 0;
        SetDisplay();
    }

    void SetDisplay()
    {
        display.text = score.ToString();
    }
}
