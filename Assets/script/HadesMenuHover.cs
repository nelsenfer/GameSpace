using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening; // (Kalau kamu pakai DOTween di script ini)
using UnityEngine.SceneManagement; // <--- TAMBAHKAN BARIS INI
public class HadesMenuHover : MonoBehaviour, IPointerEnterHandler
{
    public Transform pointerIcon;
    public GameObject darkHighlight;
    public TextMeshProUGUI menuText;
    public Color normalColor = new Color(0.7f, 0.7f, 0.7f);
    public Color hoverColor = new Color(1f, 0.8f, 0.2f);

    public bool isPlayButton = false;
    private static HadesMenuHover currentSelected;

    void Start()
    {
        if (isPlayButton)
        {
            SetActiveState(true);
            currentSelected = this;
        }
        else
        {
            SetActiveState(false);
        }
    }

    public void PlayGame()
    {
        DOVirtual.DelayedCall(0.5f, () =>
        {
            SceneManager.LoadScene("golf");
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentSelected != null && currentSelected != this)
        {
            currentSelected.SetActiveState(false);
        }

        SetActiveState(true);
        currentSelected = this;
    }

    private void SetActiveState(bool isActive)
    {
        darkHighlight.SetActive(isActive);
        menuText.color = isActive ? hoverColor : normalColor;

        if (isActive)
        {
            pointerIcon.gameObject.SetActive(true);
            pointerIcon.position = new Vector3(pointerIcon.position.x, transform.position.y, pointerIcon.position.z);
        }
    }
}