using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneChangeButton : MonoBehaviour
{
    [SerializeField] private string nextSceneName = string.Empty;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            button.onClick.AddListener(() =>
            {
                SceneController.Instance.LoadScene(nextSceneName);
            });
        }
    }
}
