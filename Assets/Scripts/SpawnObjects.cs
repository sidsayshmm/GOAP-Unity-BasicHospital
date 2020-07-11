using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject patientPrefab;
    private void Start()
    {
        Invoke(nameof(SpawnPatient), 1f);
    }

    private void SpawnPatient()
    {
        GameObject x = Instantiate(patientPrefab, transform.position, Quaternion.identity);
        for (var i = 0; i < 4; i++)
        {
            x.transform.GetChild(0).GetChild(i).gameObject.SetActive(UnityEngine.Random.Range(0,2) == 0);
        }
        x.transform.SetParent(gameObject.transform);
        x.transform.position = gameObject.transform.position;
        Invoke(nameof(SpawnPatient), UnityEngine.Random.Range(2f, 5f));
    }
}
