using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class KyotoWeather : MonoBehaviour
{
    TextMeshProUGUI text;
    public GameObject sun;
    public GameObject rain;
    public GameObject clouds;
    public string apiKey = "4c91371cc501ca36efe3e4fc68ea84d2";
    float updateInterval = 5f;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        StartCoroutine(UpdateWeather());
    }

    IEnumerator UpdateWeather()
    {
        while (true)
        {
            string url =
                "https://api.openweathermap.org/data/2.5/weather?q=Kyoto,jp&units=metric&appid=" + apiKey;

            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;
                WeatherData data = JsonUtility.FromJson<WeatherData>(json);

                // Ensure 'condition' is always assigned before use to fix CS0165.
                string condition = "Unknown";
                if (data != null && data.weather != null && data.weather.Length > 0 && !string.IsNullOrEmpty(data.weather[0].main))
                {
                    condition = data.weather[0].main;
                }

                if (data != null && data.main != null)
                {
                    text.text = $"{data.main.temp}°C\n{condition}";
                }
                else
                {
                    text.text = $"--°C\n{condition}";
                }

                sun.SetActive(false);
                rain.SetActive(false);
                clouds.SetActive(false);

                if (condition == "Clear")
                {
                    sun.SetActive(true);
                }
                else if (condition == "Rain")
                {
                    rain.SetActive(true);
                }
                else if (condition == "Clouds")
                {
                    clouds.SetActive(true);
                }
            }
            else
            {
                text.text = "Weather Error";
                Debug.Log(request.error);
            }

            yield return new WaitForSeconds(updateInterval);
        }
    }

    [System.Serializable]
    public class WeatherData
    {
        public Main main;
        public Weather[] weather;
    }

    [System.Serializable]
    public class Main
    {
        public float temp;
    }

    [System.Serializable]
    public class Weather
    {
        public string main;
    }
}