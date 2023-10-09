using UnityEngine;
using TMPro;
using Dan.Main;

public class LeaderBoardManager : MonoBehaviour
{

  
    [SerializeField] TextMeshProUGUI learderBoardTMP;
    [SerializeField] TMP_InputField userNameIF;
    readonly string publicLeaderBoardKey = "0********************************************e";
    int maxTopLenght = 20;

    void Start()
    {
        GetLeaderboard();
        if (PlayerPrefs.HasKey("username"))
        {
            userNameIF.text = PlayerPrefs.GetString("username").ToString();
        }

    }

    void GetLeaderboard()
    {
        learderBoardTMP.text = "";
        LeaderboardCreator.GetLeaderboard(publicLeaderBoardKey, (msg) =>
        {
            int loopLenght = (msg.Length < maxTopLenght) ? msg.Length : maxTopLenght;
            foreach (var item in msg)
            {
                learderBoardTMP.text += item.Username + " - " + item.Score.ToString() + "\n";
            }
        });
    }

    void SetLeaderBoard(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, username, score, (msg) =>
        {
            GetLeaderboard();
        });
    }


    public void SendToLeaderBoardButton()
    {
        int _socre= 110000; // get playe score from your game
        SetLeaderBoard(userNameIF.text, _socre);
        PlayerPrefs.SetString("username", userNameIF.text);
        PlayerPrefs.Save();
    }

}



