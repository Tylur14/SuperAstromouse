using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, this.transform.parent);
    }
}
