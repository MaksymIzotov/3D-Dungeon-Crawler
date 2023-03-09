using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFader : MonoBehaviour
{
    #region Singleton Init
    public static AudioFader Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void Fade(AudioSource audioSource, float duration, float targetVolume)
    {
        StartCoroutine(StartFade(audioSource, duration, targetVolume));
    }

    private IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            if(audioSource == null) yield return null;

            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
