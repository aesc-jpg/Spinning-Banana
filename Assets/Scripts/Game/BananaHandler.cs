using UnityEngine;

public class BananaHandler : MonoBehaviour
{
    public float degreesPerSecond = 0;
    public AudioSource bananaSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bananaSFX.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(degreesPerSecond > 1000)
        {
            degreesPerSecond = 1000;
        }
        transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);

        if (degreesPerSecond > 0)
        {
            bananaSFX.volume = (float)(degreesPerSecond * 0.001);
        }
    }
}
