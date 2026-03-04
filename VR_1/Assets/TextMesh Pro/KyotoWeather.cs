using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class KyotoWeather : MonoBehaviour
{
    TextMeshProUGUI text;
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

                if (data != null && data.main != null)
                    text.text = data.main.temp + "°C";
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
    }

    [System.Serializable]
    public class Main
    {
        public float temp;
    }
}