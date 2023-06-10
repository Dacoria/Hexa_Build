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

    public void FadeIn(CanvasGroup canvasGroup, float aTime, Action callback = null) => FadeTo(canvasGroup, 1, aTime, callback);
    public void FadeOut(CanvasGroup canvasGroup, float aTime, Action callback = null) => FadeTo(canvasGroup, 0, aTime, callback);

    public void FadeTo(CanvasGroup canvasGroup, float aValue, float aTime, Action callback)
    {
        StartCoroutine(CR_FadeTo(canvasGroup, aValue, aTime, callback));
    }

    private IEnumerator CR_FadeTo(CanvasGroup canvasGroup, float aValue, float aTime, Action callback)
    {
        float alpha = canvasGroup.alpha;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            if (canvasGroup == null) { break; } // voor als je fade als een obj is vernietigd
            canvasGroup.alpha = Mathf.Lerp(alpha, aValue, t);
            yield return null;
        }
        if (canvasGroup == null) { callback?.Invoke(); yield break; } // voor als je fade als een obj is vernietigd
        canvasGroup.alpha = aValue;
        callback?.Invoke();
    }

    public void Do_CR(float waitTimeInSeconds, Action callback)
    {
        StartCoroutine(CR_Do_CR(waitTimeInSeconds, callback));
    }

    private IEnumerator CR_Do_CR(float waitTimeInSeconds, Action callback)
    {
        yield return Wait4Seconds.Get(waitTimeInSeconds);
        callback?.Invoke();
    }
}