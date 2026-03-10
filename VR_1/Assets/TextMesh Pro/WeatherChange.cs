using UnityEngine;

public class WeatherChange : MonoBehaviour
{
    public GameObject rain;
    public GameObject sun;
    public GameObject clouds;

    void Start()
    {
        int weather = Random.Range(0, 3);

        rain.SetActive(false);
        sun.SetActive(false);
        clouds.SetActive(false);

        if (weather == 0)
            sun.SetActive(true);

        if (weather == 1)
            clouds.SetActive(true);

        if (weather == 2)
            rain.SetActive(true);
    }
}