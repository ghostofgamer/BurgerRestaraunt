using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    private float _elapsedTime;
    private Coroutine _coroutine;

    public void PlayLoading(float duration, Image loadFill)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(LoadFillImage(duration, loadFill));
    }

    public void StopLoading()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = null;
    }

    private IEnumerator LoadFillImage(float duration, Image loadFill)
    {
        _elapsedTime = 0;
        loadFill.fillAmount = 0;

        while (_elapsedTime < duration)
        {
            _elapsedTime += Time.deltaTime;
            loadFill.fillAmount = _elapsedTime / duration;
            yield return null;
        }
    }
}