using UnityEngine;

public class ScreenBounds : MonoBehaviour {
    private SpriteRenderer _renderer;
    private Bounds _cameraBounds;

    void Start() {
        _renderer = GetComponent<SpriteRenderer>();

        float height = Camera.main.orthographicSize * 2f;
        float width = height * Camera.main.aspect;
        _cameraBounds = new Bounds(Vector3.zero, new Vector3(width, height));
    }

    void LateUpdate() {
        float spriteWidth = _renderer.sprite.bounds.extents.x;
        float spriteHeight = _renderer.sprite.bounds.extents.y;

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, _cameraBounds.min.x + spriteWidth, _cameraBounds.max.x - spriteWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, _cameraBounds.min.y + spriteHeight, _cameraBounds.max.y - spriteHeight);
        transform.position = newPosition;
    }
}
