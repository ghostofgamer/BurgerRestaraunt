using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AcceptingOrder : MonoBehaviour
{
    [SerializeField] private Image _loadImage;
    [SerializeField] private Image _loadFill;
    [SerializeField] private ParametersLoad _parametersLoad;
    
    [Inject] private ImageLoader _imageLoader;
    
    private bool _isAcceptingOrder;
    private float _elapsedTime;
    private Coroutine _coroutine;

    public event Action AcceptingOrderFinished;
    
    public void StartAcceptingOrder()
    {
        _isAcceptingOrder = true;
        _loadImage.gameObject.SetActive(true);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CookingProgress());
    }

    public void StopAcceptingOrder()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _imageLoader.StopLoading();
        _coroutine = null;
        _isAcceptingOrder = false;
        _loadImage.gameObject.SetActive(false);
    }

    private IEnumerator CookingProgress()
    {
        if (_isAcceptingOrder)
        {
            _imageLoader.PlayLoading(_parametersLoad.Duration, _loadFill);
            yield return new WaitForSeconds(_parametersLoad.Duration);
            AcceptingOrderFinished?.Invoke();
            StopAcceptingOrder();
        }
    }
}
