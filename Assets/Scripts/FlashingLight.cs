using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    private Light lightComp;

    public float minIntensity = 2f;
    public float maxIntensity = 10f;
    public float flashSpeed = 5f;

    void Start()
    {
        lightComp = GetComponent<Light>();
    }

    void Update()
    {
        lightComp.intensity =
            Mathf.Lerp(
                minIntensity,
                maxIntensity,
                Mathf.PingPong(
                    Time.time * flashSpeed,
                    1f
                )
            );
    }
}