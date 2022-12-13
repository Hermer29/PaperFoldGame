using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StickerEffect : MonoBehaviour
{
    private Transform _cachedTransform;
    public Transform CachedTransform
    {
        get
        {
            if (_cachedTransform == null)
                _cachedTransform = transform;
            return _cachedTransform;
        }
    }

    private SpriteRenderer _cachedSpriteRenderer;
    public SpriteRenderer CachedSpriteRenderer
    {
        get
        {
            if (_cachedSpriteRenderer == null)
                _cachedSpriteRenderer = GetComponent<SpriteRenderer>();
            return _cachedSpriteRenderer;
        }
    }


    private void Awake()
    {
        
        CachedTransform.localScale = Vector2.zero;
    }


    private IEnumerator ShowEffectCoroutine(Sprite stickerImage)
    {
        bool endEffect = false;

        CachedSpriteRenderer.sprite = stickerImage;
        gameObject.SetActive(true);

        LeanTween.scale(gameObject, Vector2.one, 1f).setEaseInOutElastic().setOnComplete(() =>
        {
            endEffect = true;
        });

        yield return new WaitUntil(() => endEffect);
        yield break;
    }

    public Coroutine ShowEffect(Sprite stickerImage)
    {
        return StartCoroutine(ShowEffectCoroutine(stickerImage));
    }
}