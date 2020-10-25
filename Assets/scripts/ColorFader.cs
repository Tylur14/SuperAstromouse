using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorFader : MonoBehaviour
{
    [SerializeField] private TextMeshPro colorObject;
    [SerializeField] private float maxOpacity;
    [SerializeField] private float minOpacity;
    [SerializeField] private float fadeSpeed;
    private void Start()
    {
        var color = colorObject.color;
        color.a = 0f;
        colorObject.color = color;
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(DoFadeIn());
        IEnumerator DoFadeIn()
        {
            while (colorObject.color.a < maxOpacity)
            {
                var color = colorObject.color;
                color.a += Time.deltaTime * fadeSpeed;
                colorObject.color = color;
                yield return null;
            }

        }
    }

    public void FadeOut()
    {
        StartCoroutine(DoFadeOut());
        IEnumerator DoFadeOut()
        {
            while (colorObject.color.a > minOpacity)
            {
                var color = colorObject.color;
                color.a -= Time.deltaTime * fadeSpeed;
                colorObject.color = color;
                yield return null;
            }

        }
        
    }

    private void OnEnable()
    {
        FadeIn();
    }
}
