using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject howToPlayPopup;
    public GameObject pulpito;

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnHowToPlay()
    {
        howToPlayPopup.SetActive(true);
        pulpito.SetActive(false);
    }

    public void OnCloseHowToPlay()
    {
        howToPlayPopup.SetActive(false);
        pulpito.SetActive(true);
    }

    public void OnExit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
