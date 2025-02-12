using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnClick() {
        Time.timeScale = 1;
        SceneManager.LoadScene( "_Scene_0");
    }

    // Update is called once per frame
    
}
