using UnityEngine;
public class RepeatingGround : MonoBehaviour
{
    private BoxCollider2D m_GroundBoxCollider2D;        
    private float m_GroundHorizontalLength;     

    private void Awake()
    {
        m_GroundBoxCollider2D = GetComponent<BoxCollider2D>();
        m_GroundHorizontalLength = m_GroundBoxCollider2D.size.x;
    }

    private void Update()
    {
        if (transform.position.x < -m_GroundHorizontalLength)
        {
            ProceessRepositioningOfBackground();
        }
    }

    private void ProceessRepositioningOfBackground()
    {
        Vector2 groundOffSet = new Vector2(m_GroundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
