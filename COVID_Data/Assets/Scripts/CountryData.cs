using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
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

    public AutoCompleteComboBox autoDropbox;
    public InputField inpCountryName;

    public TMP_Text countryName;
    public TMP_Text countryCases;
    public TMP_Text countryRecovered;
    public TMP_Text countryDeaths;

    private string uri = "https://coronavirus-monitor.p.rapidapi.com/coronavirus/cases_by_country.php";
    private string countryData;

    public void Start()
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

            for (int i = 0; i < rootCountryClass.countries_stat.Length; i++)
            {
                if (rootCountryClass.countries_stat[i].country_name == "India")
                {
                    countryName.text = rootCountryClass.countries_stat[i].country_name;
                    countryCases.text = rootCountryClass.countries_stat[i].cases;
                    countryRecovered.text = rootCountryClass.countries_stat[i].total_recovered;
                    countryDeaths.text = rootCountryClass.countries_stat[i].deaths;
                }
            }

            for (int i = 0; i < rootCountryClass.countries_stat.Length; i ++)
            {
                autoDropbox.AvailableOptions.Add(rootCountryClass.countries_stat[i].country_name);
            }
        }
        else
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
        }
    }

    public void CountryCases()
    {
        StartCoroutine(PopulateData());
    }

    private IEnumerator PopulateData()
    {
        for (int i = 0; i < rootCountryClass.countries_stat.Length; i++)
        {
            if (inpCountryName.text == rootCountryClass.countries_stat[i].country_name.ToLower())
            {
                countryName.text = rootCountryClass.countries_stat[i].country_name;
                countryCases.text = rootCountryClass.countries_stat[i].cases;
                countryRecovered.text = rootCountryClass.countries_stat[i].total_recovered;
                countryDeaths.text = rootCountryClass.countries_stat[i].deaths;
            }
        }
        yield return null;
    }
}
