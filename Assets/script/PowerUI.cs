using UnityEngine;
using TMPro;

public class PowerUI : MonoBehaviour
{
    public BallLauncher ball;
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = "Power: " + Mathf.RoundToInt(ball.powerPercent * 100) + "%";
    }
}