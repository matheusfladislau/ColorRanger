using UnityEngine;

public class MovLateral : MonoBehaviour {
    public float speed = 5f;

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
    }
}
