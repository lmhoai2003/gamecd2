using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ChonTuong : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void chontuong1()
    {
        PlayerPrefs.SetInt("player", 0);
        PlayerPrefs.SetString("name", "Diaochan");
        LoadGameScene();
    }

    // Gọi khi bấm chọn nhân vật 2
    public void chontuong2()
    {
        PlayerPrefs.SetInt("player", 1);
        PlayerPrefs.SetString("name", "LiuBei");
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }

}
