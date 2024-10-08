using UnityEngine;

public class MovVertical : MonoBehaviour {
    public float speed = 5f;

    void Update() {
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, vertical) * speed * Time.deltaTime);
    }
}
