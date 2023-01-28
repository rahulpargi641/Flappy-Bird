using UnityEngine;

public class ColumnsController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<BirdController>() != null)
        {
            GameController.Instance.ProcessBirdScored();
            SoundManager.Instance.PlaySound(SoundManager.ESounds.Score);
        }
    }
}
