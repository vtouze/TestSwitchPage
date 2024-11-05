using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool _isPaused = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsPaused
    {
        get { return _isPaused; }
        set
        {
            _isPaused = value;
        }
    }

    public void TogglePause()
    {
        IsPaused = !IsPaused;

        if (IsPaused)
        {
            ConnectionManager.Instance.SendStatusMessage("pause");
        }
        else
        {
            ConnectionManager.Instance.SendStatusMessage("play");
        }
    }
}