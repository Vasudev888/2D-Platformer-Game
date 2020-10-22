using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
   public Button buttonPlay;
   public GameObject  LevelSelection;

   private void Awake() {
       buttonPlay.onClick.AddListener(PlayGame);
   }

    private void PlayGame()
    {
        // SceneManager.LoadScene(1);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }

    public  void ButtonQuit()
    {
        Application.Quit();
    }
}
