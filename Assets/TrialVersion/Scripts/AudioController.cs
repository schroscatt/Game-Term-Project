using UnityEngine;


public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }
    public AudioSource music;
    public AudioSource fail;
    public AudioSource win;
    public AudioSource death;


    private int _currentLevel;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);

        if (!music.isPlaying)
        {
            music.Play();
        }
    }

    public void PlayFailMusic()
    {
        music.Stop();
        fail.Play();
    }
    
    public void PlayWinMusic()
    {
        music.Stop();
        win.Play();
    }


    public void PlayLevelMusic()
    {
        fail.Stop();
        win.Stop();
        music.Play();
    }

    public void PlayDeathMusic()
    {
        music.Stop();
        death.Play();
    }

}