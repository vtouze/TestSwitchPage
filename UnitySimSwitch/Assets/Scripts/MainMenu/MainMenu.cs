using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Fields
    [Header("Game Object")]
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _settingsMenu = null;
    [SerializeField] private GameObject _quitCheck = null;
    [SerializeField] private GameObject _encyclopedia = null;
    [SerializeField] private GameObject _fadeInCircle = null;
    [SerializeField] private CameraController _cameraController = null;
    [Header("Animation")]
    [SerializeField] private Animator _quitAnim = null;
    [SerializeField] private Animator _openSettings = null;
    [SerializeField] private Animator _openEncyclopedia = null;
    private float _fadeAnimationTime = 1.95f;
    private bool _hasFinishedQuitAnimation = false;
    private bool _hasFinishedPlayAnimation = false;

    #endregion Fields

    #region Methods
    void Start()
    {
        _mainMenu.SetActive(true);
        _settingsMenu.SetActive(false);
        _quitCheck.SetActive(false);
        _encyclopedia.SetActive(false);
        _cameraController._isMenuing = true;
    }

    private void Update()
    {
        QuitToDesktopAnimation();
        SwitchSceneAnimation();
    }

    #region Buttons
    public void Play()
    {
        CheckAnimations(_openSettings);
        CheckAnimations(_openEncyclopedia);
        CheckAnimations(_quitAnim);
        _hasFinishedPlayAnimation = true;
    }

    private void CheckAnimations(Animator anim)
    {
        if(anim.GetBool("isOpening"))
        {
            anim.SetBool("isOpening", false);
        }
    }

    private void PlayAnimations(Animator anim, GameObject gameObject)
    {
        gameObject.SetActive(true);
        anim.SetBool("isOpening", true);
    }

    public void OpenSettings()
    {
        CheckAnimations(_openEncyclopedia);
        CheckAnimations(_quitAnim);
        PlayAnimations(_openSettings, _settingsMenu);
    }

    public void OpenEncyclopedia()
    {
        CheckAnimations(_openSettings);
        CheckAnimations(_quitAnim);
        PlayAnimations(_openEncyclopedia, _encyclopedia);
    }

    public void QuitChecking()
    {
        CheckAnimations(_openEncyclopedia);
        CheckAnimations(_openSettings);
        PlayAnimations(_quitAnim, _quitCheck);
    }

    #endregion Buttons
    #region Quit Methods
    public void QuitY()
    {
        _hasFinishedQuitAnimation = true;
        //Application.OpenURL("https://teez21.itch.io/testwebgl2022");
    }

    public void QuitN()
    {
        CheckAnimations(_quitAnim);
    }

    private void SwitchSceneAnimation()
    {
        if (_hasFinishedPlayAnimation == true && _fadeAnimationTime > 0)
        {
            _fadeInCircle.SetActive(true);
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedPlayAnimation == true)
        {
            SceneManager.LoadScene("Overview");
        }
    }

    private void QuitToDesktopAnimation()
    {
        if (_hasFinishedQuitAnimation == true && _fadeAnimationTime > 0)
        {
            _fadeInCircle.SetActive(true);
            _fadeAnimationTime -= Time.deltaTime;
        }

        if (_fadeAnimationTime <= 0 && _hasFinishedQuitAnimation == true)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
    #endregion Quit Methods
    #endregion Methods
}