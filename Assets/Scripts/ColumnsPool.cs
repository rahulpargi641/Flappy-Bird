using UnityEngine;

public class ColumnsPool : MonoBehaviour
{
    [SerializeField] GameObject ColumnPrefab;
    GameObject[] m_Columns;

    Vector2 m_ColumnObjectPoolPos = new Vector2(-90f, -200f);
    int m_ColumnPoolSize = 5;
    float m_ColumnSpawnRate = 2f;

    float m_ColumnMinYPos =-22;
    float m_ColumnMaxYPos = 15;
    float m_ColumnSpawnXPos = 50;
    int m_CurrentColumnIndex = 0;
    float m_TimeSinceLastSpawned;

    void Start()
    {
        ProcessColumnPoolCreation();
    }

    void Update()
    {
        m_TimeSinceLastSpawned += Time.deltaTime;

        if(!GameController.Instance.m_GameOver && m_TimeSinceLastSpawned >= m_ColumnSpawnRate)
        {
            m_TimeSinceLastSpawned = 0;
            ProcessRePositioningOfColumnsFromThePool();
        }
    }

    private void ProcessRePositioningOfColumnsFromThePool()
    {
        float columnSpawnYPos = Random.Range(m_ColumnMinYPos, m_ColumnMaxYPos);
        m_Columns[m_CurrentColumnIndex].transform.position = new Vector2(m_ColumnSpawnXPos, columnSpawnYPos);
        m_CurrentColumnIndex++;
        if (m_CurrentColumnIndex >= m_ColumnPoolSize)
        {
            m_CurrentColumnIndex = 0;
        }
    }

    private void ProcessColumnPoolCreation()
    {
        m_Columns = new GameObject[m_ColumnPoolSize];

        for (int i = 0; i < m_ColumnPoolSize; i++)
        {
            m_Columns[i] = (GameObject)Instantiate(ColumnPrefab, m_ColumnObjectPoolPos, Quaternion.identity);
        }
    }
}
