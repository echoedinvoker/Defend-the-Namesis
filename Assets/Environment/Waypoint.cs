using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }


    void OnMouseDown() {
        if (isPlaceable) {
            bool isPlaced = tower.CreateTower(transform.position);
            // isPlaceable = false;
            isPlaceable = !isPlaced;
        }
    }
}
