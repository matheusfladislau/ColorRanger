using UnityEngine;

public class MovLateral : MonoBehaviour {
    public float speed = 5f;

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontal, 0) * speed * Time.deltaTime);
    }
}
