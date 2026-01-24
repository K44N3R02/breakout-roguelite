using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        SceneController.Instance.LoadScene("StartUIScene");
    }
}
