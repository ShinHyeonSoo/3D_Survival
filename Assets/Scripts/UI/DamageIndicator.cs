using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Image _image;
    public float _flashSpeed;

    private Coroutine _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player._condition.OnTakeDamage += Flash;
    }

    public void Flash()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _image.enabled = true;
        _image.color = new Color(1f, 100f / 255f, 100f / 255f);
        _coroutine = StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while(a > 0)
        {
            a -= (startAlpha / _flashSpeed) * Time.deltaTime;
            _image.color = new Color(1f, 100f / 255f, 100f / 255f, a);
            yield return null;
        }

        _image.enabled = false;
    }
}
