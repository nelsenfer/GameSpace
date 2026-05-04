using UnityEngine;

public class ScoreTarget : MonoBehaviour
{
    public int pointValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Memanggil ScoreManager secara otomatis lewat Singleton
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.TambahPoin(pointValue);
            }

            Debug.Log(gameObject.name + " Hancur!");
            Destroy(gameObject);
        }
    }
}