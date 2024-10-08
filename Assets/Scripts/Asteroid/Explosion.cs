using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionSound;

    void Start()
    {
        Instantiate(explosionSound, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        StartCoroutine(AutoDestruir());
    }

    void Update()
    {
        
    }

    IEnumerator AutoDestruir()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}