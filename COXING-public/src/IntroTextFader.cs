using System.Collections;
using UnityEngine;
using TMPro;

public class IntroTextFader : MonoBehaviour
{
    [Header("References")]
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI introText;

    [Header("Timings (seconds)")]
    public float initialDelay     = 0.5f;  // 필요 없으면 0
    public float fadeInDuration   = 1.0f;
    public float stayDuration     = 3.0f;
    public float fadeOutDuration  = 1.0f;

    private void Awake()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null)
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 0f; // 시작은 투명
    }

    private void Start()
    {
        // 씬 로딩 끝나고 딱 한 번만 실행
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        // 0) 초기 지연 (선택)
        if (initialDelay > 0f)
            yield return new WaitForSecondsRealtime(initialDelay);

        // 1) 페이드 인
        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.unscaledDeltaTime; // 타임스케일 무시
            canvasGroup.alpha = Mathf.Clamp01(t / fadeInDuration);
            yield return null;
        }

        // 2) 유지
        yield return new WaitForSecondsRealtime(stayDuration);

        // 3) 페이드 아웃
        t = 0f;
        while (t < fadeOutDuration)
        {
            t += Time.unscaledDeltaTime;
            canvasGroup.alpha = 1f - Mathf.Clamp01(t / fadeOutDuration);
            yield return null;
        }

        // 4) 끝나면 꺼주기 (또 켤 일 없으면 Destroy도 가능)
        gameObject.SetActive(false);
        // Destroy(gameObject); // 이렇게 바꾸면 완전 제거
    }
}