using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    [SerializeField] private CanvasGroup transitionCanvas;
    [SerializeField] private float fadeDuration;
    [SerializeField] private string initialScene;

    private string currentSceneName = string.Empty;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        LoadScene(initialScene);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(TransitionSequence(sceneName));
    }

    private IEnumerator TransitionSequence(string sceneName)
    {
        transitionCanvas.blocksRaycasts = true;
        yield return StartCoroutine(Fade(1f));

        if (!string.IsNullOrEmpty(currentSceneName))
        {
            yield return SceneManager.UnloadSceneAsync(currentSceneName);
        }

        AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!loadOp.isDone)
        {
            yield return null;
        }

        Scene newScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(newScene);
        currentSceneName = sceneName;

        yield return StartCoroutine(Fade(0f));
        transitionCanvas.blocksRaycasts = false;
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = transitionCanvas.alpha;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            transitionCanvas.alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            yield return null;
        }

        transitionCanvas.alpha = targetAlpha;
    }
}
