using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] float m_UpForce = 200f;

    Rigidbody2D m_Rigidbody2D;
    Animator m_Animator;

    bool m_Dead = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (m_Dead) return;
        if(Input.GetMouseButtonDown(0))
        {
            ProcessBirdJump();
        }
    }

    private void ProcessBirdJump()
    {
        m_Rigidbody2D.velocity = Vector2.zero;
        m_Rigidbody2D.AddForce(new Vector2(0, m_UpForce));
        m_Animator.SetTrigger("Flap");
        SoundManager.Instance.PlaySound(SoundManager.ESounds.BirdJump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_Rigidbody2D.velocity = Vector2.zero;
        m_Dead = true;
        GameController.Instance.ProcessBirdDead();
        SoundManager.Instance.PlaySound(SoundManager.ESounds.BirdCollided);
    }
}
