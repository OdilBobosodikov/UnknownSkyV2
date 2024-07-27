using System;
using System.Collections;
using TMPro;
using UnityEngine;
 public class UIApperiance : MonoBehaviour
{
    public TextMeshProUGUI  displayText; 
    public float displayDuration = 2f; 
    public float fadeDuration = 0.5f; 

    private void SetAlphoToZero()
    {
         Color originalColor = displayText.color;
          displayText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }

    public void ShowText()
    {
        displayText.enabled = false;
        SetAlphoToZero();
        StopAllCoroutines();
        StartCoroutine(FadeTextInAndOut());
    }

    private IEnumerator FadeTextInAndOut()
    {
        yield return new WaitForSeconds(displayDuration); 
        yield return StartCoroutine(FadeTextTo(1f)); 
        yield return new WaitForSeconds(displayDuration); 
        yield return StartCoroutine(FadeTextTo(0f)); 
    }

    private IEnumerator FadeTextTo(float targetAlpha)
    {
        displayText.enabled = true;
        Color originalColor = displayText.color;
        float startAlpha = displayText.color.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            displayText.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            yield return null;
        }

        displayText.color = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);

        if (targetAlpha == 0f)
        {
            displayText.enabled = false;
        }
    }
}