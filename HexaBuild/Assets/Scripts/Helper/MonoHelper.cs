using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonoHelper : MonoBehaviour
{
    public static MonoHelper instance;

    private void Awake()
    {
        instance = this;
    }

    public AnimationCurve CurveGradual;
    public AnimationCurve CurveLinear;
    public AnimationCurve CurveSlowStart;
    public AnimationCurve CurveSlowEnd;
       
    public void FadeIn(CanvasGroup canvasGroup, float aTime = 0.4f, Action callback = null) => FadeTo(canvasGroup, 1, aTime, callback);
    public void FadeOut(CanvasGroup canvasGroup, float aTime = 0.2f, Action callback = null) => FadeTo(canvasGroup, 0, aTime, callback);

    public void FadeTo(CanvasGroup canvasGroup, float aValue, float aTime, Action callback)
    {
        StartCoroutine(CR_FadeTo(canvasGroup, aValue, aTime, callback));
    }

    private IEnumerator CR_FadeTo(CanvasGroup canvasGroup, float aValue, float aTime, Action callback)
    {
        float alpha = canvasGroup.alpha;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            if(canvasGroup == null) { yield break; }
            canvasGroup.alpha = Mathf.Lerp(alpha, aValue, t);
            yield return null;
        }
        canvasGroup.alpha = aValue;
        callback?.Invoke();
    }
}