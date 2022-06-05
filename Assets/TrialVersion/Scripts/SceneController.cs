using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    public Button tryAgain;
    public Button nextLevel;
    public TMPro.TMP_Text nextText;
    public TMPro.TMP_Text tryText;
    public Canvas canvas;

    private static int currentLevel;

    // Start is called before the first frame update
    void Awake()
    {
        currentLevel = 0;
        tryAgain.onClick.AddListener(LoadLevel);
        nextLevel.onClick.AddListener(LoadLevel);
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
        canvas.gameObject.SetActive(false);
        currentLevel += 1;
        SceneManager.LoadScene("First" + currentLevel);
    }

    public void LoadFailLevel()
    {
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
        currentLevel += 1;
        canvas.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(false);
        tryText.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(true);
        nextText.gameObject.SetActive(true);
    }

}
