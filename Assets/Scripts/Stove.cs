using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Stove : MonoBehaviour
{
    [SerializeField] private Image _loadImage;
    [SerializeField] private Image _loadFill;

    [Inject] private ImageLoader _imageLoader;

    private bool _isCooking;
    private float _duration = 3f;
    private float _elapsedTime;
    private Coroutine _coroutine;

    public event Action CookingFinished;

    public void StartCooking()
    {
        _isCooking = true;
        _loadImage.gameObject.SetActive(true);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CookingProgress());
    }

    public void StopCooking()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _imageLoader.StopLoading();
        _coroutine = null;
        _isCooking = false;
        _loadImage.gameObject.SetActive(false);
    }

    private IEnumerator CookingProgress()
    {
        if (_isCooking)
        {
            _imageLoader.PlayLoading(_duration, _loadFill);
            yield return new WaitForSeconds(_duration);
            CookingFinished?.Invoke();
            StopCooking();
            Debug.Log("Finish");
        }
    }
}