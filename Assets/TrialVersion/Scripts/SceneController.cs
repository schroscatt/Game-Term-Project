using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    public Button tryAgain;
    public Button nextLevel;
    public TMPro.TMP_Text nextText;
    public TMPro.TMP_Text tryText;
    public Canvas canvas;

    private int _currentLevel;

    // Start is called before the first frame update
    void Awake()
    {
        _currentLevel = 0;
        tryAgain.onClick.AddListener(LoadLevel);
        nextLevel.onClick.AddListener(LoadNextLevel);
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void LoadLevel()
    {
        AudioController.Instance.PlayLevelMusic();
        canvas.gameObject.SetActive(false);
        SceneManager.LoadScene("First" + _currentLevel);
    }
    
    public void LoadNextLevel()
    {
        AudioController.Instance.PlayLevelMusic();
        canvas.gameObject.SetActive(false);
        SceneManager.LoadScene("First" + _currentLevel);
    }


    public void LoadFailLevel()
    {
        AudioController.Instance.PlayFailMusic();
        SceneManager.LoadScene("LevelPanel");
        canvas.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);
        tryText.gameObject.SetActive(true);
        nextLevel.gameObject.SetActive(false);
        nextText.gameObject.SetActive(false);
    }

    public void LoadWinLevel()
    {
        SceneManager.LoadScene("LevelPanel");
        AudioController.Instance.PlayWinMusic();
        _currentLevel += 1;
        canvas.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(false);
        tryText.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(true);
        nextText.gameObject.SetActive(true);
    }

}
