using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _duration;

    private float _maxFillValue = 1f;
    private float _minFillValue = 0f;
    private Coroutine _fillChanger;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = _maxFillValue;
    }

    public void ToFill()
    {
        ChangeHeartFill(_minFillValue, _maxFillValue, Fill);
    }

    public void ToEmpty()
    {
        ChangeHeartFill(_maxFillValue, _minFillValue, Destroy);
    }

    private void ChangeHeartFill(float startValue, float targetValue, UnityAction<float> lerpingEnd)
    {
        StopHeartFillChanging();
        StartHeartFillChanging(startValue, targetValue, lerpingEnd);
    }

    private void StartHeartFillChanging(float startValue, float targetValue, UnityAction<float> lerpingEnd)
    {
        _fillChanger = StartCoroutine(ChangeHeartFillTo(startValue, targetValue, lerpingEnd));
    }

    private void StopHeartFillChanging()
    {
        if (_fillChanger != null)
            StopCoroutine(_fillChanger);
    }

    private IEnumerator ChangeHeartFillTo(float startValue, float targetValue, UnityAction<float> lerpingEnd)
    {        
        float elapsed = 0;

        while (elapsed < _duration)
        {
            _image.fillAmount = Mathf.Lerp(startValue, targetValue, elapsed / _duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(targetValue);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }
    
    private void Destroy(float value)
    {
        _image.fillAmount = value;
        gameObject.SetActive(false);
    }
}
