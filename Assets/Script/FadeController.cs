using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{

    public void FadeIn(Image image, float fadeOutTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIn(image, fadeOutTime, nextEvent));
    }

    public void FadeOut(Image image, float fadeOutTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(image, fadeOutTime, nextEvent));
    }

    // 투명 -> 불투명
    IEnumerator CoFadeIn(Image image, float fadeOutTime, System.Action nextEvent = null)
    {
        Color tempColor = image.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            image.color = tempColor;

            if (tempColor.a >= 1f)
                tempColor.a = 1f;

            yield return null;
        }

        image.color = tempColor;
        if (nextEvent != null)
            nextEvent();
    }

    // 불투명 -> 투명
    IEnumerator CoFadeOut(Image image, float fadeOutTime, System.Action nextEvent = null)
    {
        Color tempColor = image.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            image.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        image.color = tempColor;
        if (nextEvent != null) nextEvent();
    }
}
