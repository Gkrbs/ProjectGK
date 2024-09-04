using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneFadeOut : MonoBehaviour
{
    public Image fadeInOutImage;
    // Start is called before the first frame update
    void Start()
    {
        FadeOut(0.7f);
    }

    public void FadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIn(fadeOutTime, nextEvent));
    }

    public void FadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(fadeOutTime, nextEvent));
    }

    // 투명 -> 불투명
    IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        Color tempColor = fadeInOutImage.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            fadeInOutImage.color = tempColor;

            if (tempColor.a >= 1f)
                tempColor.a = 1f;

            yield return null;
        }

        fadeInOutImage.color = tempColor;
        if (nextEvent != null)
            nextEvent();
    }

    // 불투명 -> 투명
    IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        Color tempColor = fadeInOutImage.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            fadeInOutImage.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        fadeInOutImage.color = tempColor;
        if (nextEvent != null) nextEvent();
    }
}
