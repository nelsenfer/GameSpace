using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour
{
    [SerializeField] float delay = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(WinDelay());
        }
    }

    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(delay);

        Debug.Log("WIN!");
        Time.timeScale = 0f;
    }
}