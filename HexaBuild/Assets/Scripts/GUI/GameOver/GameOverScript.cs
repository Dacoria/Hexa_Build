using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class GameOverScript : BaseEventCallback
{
    public Canvas Canvas;
    public TMP_Text GameOverText;
    public TMP_Text GameOverDescriptionText;

    private void Start()
    {
        GameOverText.gameObject.SetActive(false);
        GameOverDescriptionText.gameObject.SetActive(false);
    }

    protected override void OnGameOver()
    {
        
        GameOverText.gameObject.SetActive(true);
        GameOverDescriptionText.gameObject.SetActive(true);

        var allButtonsInCanvas = Canvas.GetComponentsInChildren<Button>().ToList();
        allButtonsInCanvas.ForEach(button => button.interactable = false);
    }
}
