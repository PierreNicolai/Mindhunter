using UnityEngine;

public class CameraShaker : MonoBehaviour
{

    private float shake = 0;
    private float shakeAmount = 0.6f;
    private float shakeDecrease = 0.5f;

    // Update is called once per frame
    private void Update()
    {
        if (shake > 0)
        {
            Camera.main.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * shakeDecrease;
        }
        else
        {
            shake = 0;
        }
    }

    public void Shake(float shakeIntensity)
    {
        shake = shakeIntensity;
    }
}
