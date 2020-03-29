using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CountryData : MonoBehaviour
{
    private string uri = "https://coronavirus-monitor.p.rapidapi.com/coronavirus/cases_by_country.php";
    private string countryData;

    public void GetCountryData()
    {
        StartCoroutine(CountryStat());
    }

    private IEnumerator CountryStat()
    {
        UnityWebRequest req = UnityWebRequest.Get(uri);

        req.SetRequestHeader("X-RapidAPI-Key", "a0d088d060mshb48474326ba8efcp1c9494jsn93e66f94ae53");

        yield return req.SendWebRequest();

        if (!req.isNetworkError)
        {
            Debug.Log(req.responseCode);
            countryData = req.downloadHandler.text;

            Debug.Log(countryData);
        }
        else
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
        }
    }
}
