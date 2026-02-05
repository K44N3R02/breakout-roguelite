using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] private BallConfig ballConfig;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Time.timeScale = 1f;
        ballConfig?.ResetSpeed();
        SceneController.Instance.LoadScene("StartUIScene");
        
    }
}
