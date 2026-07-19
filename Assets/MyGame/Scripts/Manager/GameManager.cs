using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    #region SINGLETON
    private static GameManager instance;
    public static GameManager Instance {
        get {
            if (instance == null)
                Debug.LogError("There is no instance of GameManager, please create one");

            return instance;
        }
    }

    private void InitializeSingleton() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
    #endregion

    private void Awake() {
        InitializeSingleton();
    }
}
