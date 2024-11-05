using UnityEngine;

public class InitScene : MonoBehaviour
{
    private float _fadeAnimationTime = 1.95f;
    [SerializeField] private GameObject _fadeOutCircle = null;

    void Start()
    {
        _fadeOutCircle.SetActive(true);
    }

    void Update()
    {
        if (_fadeAnimationTime > 0)
        {
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0)
        {
            _fadeOutCircle.SetActive(false);
        }
    }
}
