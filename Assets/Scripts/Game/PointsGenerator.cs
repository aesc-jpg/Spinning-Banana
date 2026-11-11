using TMPro;
using UnityEngine;

public class PointsGenerator : MonoBehaviour
{
    public PointsManager pointsManager;
    public BananaHandler bananaHandler;
    public TMP_Text upgradeCostText;
    public AudioSource notEnoughPoints;

    public int pointsPerSecond = 0;
    public int upgradeCost;
    public int upgradeCostMult;

    public float pointsAddInterval = 1;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgradeCostText.text = "Cost: " + upgradeCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > pointsAddInterval)
        {
            pointsManager.MakePoints(pointsPerSecond);
            timer = 0;
        }
    }

    public void UpgradePointsPerSecond()
    {
        if(pointsManager.TrySpendPoints(upgradeCost))
        {
            pointsPerSecond++;
            upgradeCost *= upgradeCostMult;

            upgradeCostText.text = "Cost: " + upgradeCost.ToString();
            bananaHandler.degreesPerSecond += 5;

            Debug.Log("Upgraded points per second successfully");
        }
        else
        {
            Debug.LogWarning("Not enough to upgrade points per second");
            notEnoughPoints.Play();
        }
    }
}
