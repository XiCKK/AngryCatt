using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPoint : MonoBehaviour
{
    [SerializeField] private Cat catPrefab;
    private void Start()
    {
        Instantiate(catPrefab, transform.position, Quaternion.identity);
    }
}
