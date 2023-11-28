using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private float _duration;
    private Image _image;

    private void Awake()
    {
        _duration = 1;
        _image = GetComponent<Image>();
    }

    public void DestroyHeart()
    {
        StartCoroutine(DestroyingHeart());
    }

    private IEnumerator DestroyingHeart()
    {
        float elapsedTime = 0;

        while (elapsedTime < _duration)
        {
            _image.fillAmount = Mathf.Lerp(1, 0, elapsedTime / _duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
