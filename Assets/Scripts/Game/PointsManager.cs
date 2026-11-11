using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public TMP_Text pointsText;
    public TMP_Text mainMenuText;

    public KeyCode mainMenuKey;

    public int points = 0;
    public int pointsPerClick = 1;

    private float timer = 0;
    public float timerThreshold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        pointsText.text = "Points: " + points.ToString();
        mainMenuText.text = "[Esc] Back to Main Menu";
    }

    private void Update()
    {
        if (Input.GetKey(mainMenuKey))
        {
            mainMenuText.text = "Returning...";
            timer += Time.deltaTime;
            if(timer > timerThreshold)
            {
                BackToMainMenu();
            }
        }
        else
        {
            mainMenuText.text = "[Esc] Back to Main Menu";
            timer = 0;
        }
    }

    public void MakePoints(int addedPoints)
    {
        points += addedPoints;
        pointsText.text = "Points: " + points.ToString();
    }

    public void MakePointsPerClick()
    {
        MakePoints(pointsPerClick);
    }

    public bool TrySpendPoints(int amount)
    {
        if (points >= amount)
        {
            points -= amount;
            pointsText.text = "Points: " + points.ToString();

            return true;
        }
        return false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        SceneManager.UnloadSceneAsync("Game");
    }
}
