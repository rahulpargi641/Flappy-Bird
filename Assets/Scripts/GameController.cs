using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject m_StartGameGo;
    [SerializeField] GameObject m_GameOverGO;
    [SerializeField] TMP_Text m_ScoreText;

    public static GameController Instance;
    public bool m_GameOver = false;
    public float m_ScrollSpeed = -20.5f;
    bool m_GamePaused = true;
    int m_Score = 0;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else if(Instance!=this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if(m_GameOver && Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (m_GamePaused && Input.GetMouseButtonDown(0))
        {
            ProcessGameResume();
        }

        if (!m_GamePaused && Input.GetKeyDown(KeyCode.P))
        {
            ProcessGamePause();
        }
    }

    public void ProcessBirdScored()
    {
        if (m_GameOver) return;
        m_Score++;
        m_ScoreText.text = "Score: " + m_Score.ToString();
    }
    public void ProcessBirdDead()
    {
        m_GameOver = true;
        m_GameOverGO.SetActive(true);
    }
    public void ProcessGameResume()
    {
        Time.timeScale = 1;
        m_GamePaused = false;
        m_StartGameGo.SetActive(false);
    }
    public void ProcessGamePause()
    {
        Time.timeScale = 0;
        m_GamePaused = true;
        m_StartGameGo.SetActive(true);
    }
}
