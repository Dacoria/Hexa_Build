using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Image BackGround;
    public TextMeshProUGUI HeaderField;
    public TextMeshProUGUI ContentField;
    public RectTransform rectTransform;

    [ComponentInject] private LayoutElement layoutElement;
    [ComponentInject] private ContentSizeFitter contentSizeFitter;
    [ComponentInject] private VerticalLayoutGroup verticalLayoutGroup;

    private int CharacterWrapLimit = 25;

    private void Awake()
    {
        this.ComponentInject();
    }

    public void Start()
    {
        rectTransform.localScale = new Vector3(1, 1, 1);
    }

    public void SetText(string content = "", string header = "")
    {
        if (header == null) { header = ""; };
        if (content == null) { content = ""; };

        UpdateContentBox(header.Length, content.Length);
        UpdatePivot();

        HeaderField.gameObject.SetActive(!string.IsNullOrEmpty(header));
        HeaderField.text = header;
        ContentField.text = content;
    }

    public void Update()
    {
        transform.position = Input.mousePosition;
        contentSizeFitter.enabled = true;
    }

    public void UpdatePivot()
    {
        var position = Input.mousePosition;

        var pivotX = position.x / Screen.width;
        var pivotY = position.y / Screen.height;

        // standaard normale tooltip, tenzij aan uiteinde van scherm
        if (pivotX < 0.5)
        {
            pivotX = 0;
        }
        if (pivotY > 0.5)
        {
            pivotY = 1;
        }

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }

    public void UpdateContentBox(int headerLength, int contentLength)
    {
        contentSizeFitter.enabled = true;

        var needsExpension = (headerLength > CharacterWrapLimit || contentLength > CharacterWrapLimit) ? true : false;
        if(layoutElement.enabled != needsExpension)
        {
            contentSizeFitter.enabled = false; // enabled bij volgende tik -> forceert verandering (Vraag me niet waarom... )
            layoutElement.enabled = needsExpension;

            verticalLayoutGroup.padding.top = 10;
            verticalLayoutGroup.padding.bottom = 10;
        }
    }
}