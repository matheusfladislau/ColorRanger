using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class CorMudanca : MonoBehaviour {
    public GameObject redShipPrefab;
    public GameObject greenShipPrefab;
    public GameObject blueShipPrefab;

    public GameObject _currentShip;

    public void ChangeColor() {
        Destroy(_currentShip);

        GameObject selectedPrefab = null;

        if (_currentShip == blueShipPrefab) {
            selectedPrefab = redShipPrefab;
        } else if (_currentShip == redShipPrefab) {
            selectedPrefab = greenShipPrefab;
        } else if (_currentShip == greenShipPrefab) {
            selectedPrefab = blueShipPrefab;
        }

        if (selectedPrefab != null) {
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;
            _currentShip = Instantiate(selectedPrefab, position, rotation);
        }
    }
}
