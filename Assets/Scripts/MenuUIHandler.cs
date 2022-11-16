using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text textScore;
    string playerName;

    private void Start()
    {
        DataManager.Instance.LoadScore();

        string playerName = DataManager.Instance.playerData.playerName;
        int score = DataManager.Instance.playerData.score;

        textScore.text = "Best Score: " + playerName + ":" + score;
    }

    public void StartNew()
    {
        playerName = inputField.text;
        if (playerName != "")
        {
            DataManager.Instance.playerName = playerName;
            SceneManager.LoadScene("main");
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
