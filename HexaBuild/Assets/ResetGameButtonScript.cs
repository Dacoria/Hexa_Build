using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetGameButtonScript : BaseEventCallback
{
    [ComponentInject] private Button button;
    
    void Start()
    {
        button.interactable = false;
    }

    protected override void OnGameOver()
    {
        // button worden eerst allemaal niet-interactable gemaakt; wacht daarop
        MonoHelper.instance.Do_CR(0.1f, () => button.interactable = true);
    }

    public void Click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
