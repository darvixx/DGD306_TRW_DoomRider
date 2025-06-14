using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightFollower : MonoBehaviour
{
    public RectTransform highlightImage;

    void Update()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;

        if (selected != null && selected.GetComponent<UnityEngine.UI.Button>() != null)
        {
            RectTransform selectedTransform = selected.GetComponent<RectTransform>();
            highlightImage.position = selectedTransform.position;
            highlightImage.sizeDelta = selectedTransform.sizeDelta;
        }
    }
}
