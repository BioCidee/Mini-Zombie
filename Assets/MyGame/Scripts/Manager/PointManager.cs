using UnityEngine;

public class PointManager : MonoBehaviour
{
    [Header("---- Point System ----")]
    [SerializeField] private int currentPoint;
    [SerializeField] private int minimumPoint = 0;

    private enum eventList {
        onZombieDie,
        onPlayerBuy,
    }

    private void Start() {
        EventManager.Instance.CreateEvent(eventList.onZombieDie.ToString());
        EventManager.Instance.SubscribreToEvent(eventList.onZombieDie.ToString(), AddPoint);
    }

    public int GetCurrentPoint() {
        return currentPoint;
    }

    private void RemovePoint() {

    }

    private void AddPoint() { // ALERTE MAGIC NUMBER HERE
        currentPoint += 10;
    }


}
