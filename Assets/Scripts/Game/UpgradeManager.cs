using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PointsManager pointsManager;
    public TMP_Text upgradeCostText;
    public AudioSource notEnoughPoints;

    public int upgradeCost = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgradeCostText.text = "Cost: " + upgradeCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradePointsPerClick()
    {
        if(pointsManager.TrySpendPoints(upgradeCost))
        {
            pointsManager.pointsPerClick++;
            upgradeCost *= 2;

            upgradeCostText.text = "Cost: " + upgradeCost.ToString();
            pointsManager.pointsText.text = "Points: " + pointsManager.points.ToString();

            Debug.Log("Upgraded points per click successfully");
        }
        else
        {
            
            Debug.LogWarning("Not enough to upgrade points per click");
            notEnoughPoints.Play();
        }
    }
}
