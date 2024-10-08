using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPrefab : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AutoDestruir());
    }

    void Update()
    {
        
    }

    IEnumerator AutoDestruir()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
