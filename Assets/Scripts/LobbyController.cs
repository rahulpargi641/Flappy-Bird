using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LobbyController : MonoBehaviour
{
    [SerializeField] Button m_StartButton;
    [SerializeField] Button m_QuitButton;
    private void Awake()
    {
        m_StartButton.onClick.AddListener(StartGame);
        m_StartButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.ESounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void QuitGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.ESounds.ButtonClick);
        Application.Quit();
    }
}
