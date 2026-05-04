using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton: Agar script lain bisa memanggil 'ScoreManager.instance'
    public static ScoreManager instance;

    private int score = 0;

    private void Awake()
    {
        // Menetapkan instance ini saat game mulai
        if (instance == null) instance = this;
    }

    public void TambahPoin(int jumlah)
    {
        score += jumlah;
        Debug.Log("Skor Bertambah! Skor sekarang: " + score);
    }
}