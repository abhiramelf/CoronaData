using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class CountryCase
{
    public string country_name;
    public string cases;
    public string deaths;
    public string total_recovered;
    public string new_deaths;
    public string new_cases;
    public string serious_critical;
    public string active_cases;
    public string total_cases_per_1m_population;
}

[System.Serializable]
public class RootCountryClass
{
    public CountryCase[] countries_stat;
}

public class CountryData : MonoBehaviour
{
    public RootCountryClass rootCountryClass;

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

            rootCountryClass = JsonUtility.FromJson<RootCountryClass>(countryData);

            Debug.Log(rootCountryClass.countries_stat[0].country_name);
        }
        else
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
        }
    }
}
