using UnityEngine;

public class HighlightHexScript : MonoBehaviour
{
    public HighlightSelection HighlightSelectionPrefab;


    public HighlightColorType _currentColorHighlight;
    public HighlightColorType CurrentColorHighlight
    {
        get { return _currentColorHighlight; }
        set
        {
            if(_currentColorHighlight != value )
            {
                _currentColorHighlight = value;
                UpdateHighlight(_currentColorHighlight);
            }

        }
    }

    private void UpdateHighlight(HighlightColorType color)
    {
        if(isDestroyed) { return; }
        DestroyAllSelections();
        if (color != HighlightColorType.None)
        {
            var newSelection = Instantiate(HighlightSelectionPrefab, transform);
            newSelection.SetColor(color);
        }
    }

    private void OnDestroy()
    {
        isDestroyed = true;
    }

    private bool isDestroyed;

    private void DestroyAllSelections()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            var child = transform.GetChild(i);
            Destroy(child.gameObject);
        }
    }
}