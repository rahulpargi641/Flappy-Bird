using UnityEngine;

public class ScrollingObjectController : MonoBehaviour
{
    Rigidbody2D m_Rigidbody2D;
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ProcessObjectScrolling();
    }
    void Update()
    {
        if (GameController.Instance.m_GameOver)
        {
            m_Rigidbody2D.velocity = Vector2.zero;
        }
    }
    private void ProcessObjectScrolling()
    {
        m_Rigidbody2D.velocity = new Vector2(GameController.Instance.m_ScrollSpeed, 0f);
    }
}
