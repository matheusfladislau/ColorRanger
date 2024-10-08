using UnityEngine;

public class MovVertical : MonoBehaviour {
    public float speed = 5f;

    void Update() {
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * vertical * speed * Time.deltaTime);
    }
}
