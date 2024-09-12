using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace WorkPlaceContent
{
    public abstract class WorkPlace : MonoBehaviour
    {
        [SerializeField] private Image _loadImage;
        [SerializeField] private Image _loadFill;
        [SerializeField] private ParametersLoad _parametersLoad;
        
        [Inject] private ImageLoader _imageLoader;
        
        private Coroutine _coroutine;
        private bool _isWorking;

        public event Action WorkCompleted;
        
        public void Work()
        {
            _isWorking = true;
            _loadImage.gameObject.SetActive(true);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(StartWork());
        }

        public void StopWork()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _imageLoader.StopLoading();
            _coroutine = null;
            _isWorking = false;
            _loadImage.gameObject.SetActive(false);
        }
        
        private IEnumerator StartWork()
        {
            if (_isWorking)
            {
                _imageLoader.PlayLoading(_parametersLoad.Duration, _loadFill);
                yield return new WaitForSeconds(_parametersLoad.Duration);
                WorkCompleted?.Invoke();
                StopWork();
            }
        }
    }
}