using UnityEngine;
using Unity.Cinemachine; // Library khusus Unity 6

public class CameraManager : MonoBehaviour
{
    public CinemachineCamera[] vams; // Drag 4 kamera kamu ke sini nanti

    public void AktifkanKamera(int index)
    {
        for (int i = 0; i < vams.Length; i++)
        {
            // Kamera terpilih diberi Priority tinggi (10), sisanya rendah (5)
            vams[i].Priority = (i == index) ? 10 : 5;
        }
    }
}