using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    [SerializeField] private float selfDestructTimer = 20f;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        StartCoroutine(SD());
        IEnumerator SD()
        {
            yield return new WaitForSeconds(selfDestructTimer);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        var pos = transform.localPosition;
        pos.y -= moveSpeed * Time.deltaTime;
        transform.localPosition = pos;
    }
}