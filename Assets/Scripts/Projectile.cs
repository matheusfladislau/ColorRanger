using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.up);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
