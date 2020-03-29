using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HtmlAgilityPack;

public class WebScrap : MonoBehaviour
{
    private List<HtmlNode> dataHeader = new List<HtmlNode>();
    private List<HtmlNode> stateData = new List<HtmlNode>();
    private List<string> dataHeaderText = new List<string>();
    private List<string> stateDataText = new List<string>();

    private List<string> andhraPradesh = new List<string>();
    private List<string> andaman = new List<string>();
    private List<string> bihar = new List<string>();
    private List<string> chandigarh = new List<string>();
    private List<string> chhattisgarh = new List<string>();
    private List<string> delhi = new List<string>();
    private List<string> goa = new List<string>();
    private List<string> gujarat = new List<string>();
    private List<string> haryana = new List<string>();
    private List<string> himachalPradesh = new List<string>();
    private List<string> jammuKashmir = new List<string>();
    private List<string> karnataka = new List<string>();
    private List<string> kerala = new List<string>();
    private List<string> ladakh = new List<string>();
    private List<string> madhyaPradesh = new List<string>();
    private List<string> maharashtra = new List<string>();
    private List<string> manipur = new List<string>();
    private List<string> mizoram = new List<string>();
    private List<string> odisha = new List<string>();
    private List<string> puducherry = new List<string>();
    private List<string> punjab = new List<string>();
    private List<string> rajasthan = new List<string>();
    private List<string> tamilNadu = new List<string>();
    private List<string> telengana = new List<string>();
    private List<string> uttarakhand = new List<string>();
    private List<string> uttarPradesh = new List<string>();
    private List<string> westBengal = new List<string>();

    private List<string> totalIndia = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        HtmlWeb test = new HtmlWeb();
        HtmlDocument doc = test.Load("https://www.mohfw.gov.in/");

        dataHeader = doc.DocumentNode.SelectNodes("//div[@id='cases']/div/div/table/thead/tr/th").ToList();
        stateData = doc.DocumentNode.SelectNodes("//div[@id='cases']/div/div/table/tbody/tr/td").ToList();
        //headerText = headerName.Select(i => i.ToString()).ToList();

        foreach (var item in dataHeader)
        {
            dataHeaderText.Add(item.InnerText);
        }

        foreach (var item in stateData)
        {
            stateDataText.Add(item.InnerText);
        }

        StateData();
    }

    public void StateData()
    {
        var selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        andhraPradesh.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        andaman.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        bihar.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        chandigarh.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        chhattisgarh.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        delhi.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        goa.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        gujarat.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        haryana.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        himachalPradesh.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        jammuKashmir.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        karnataka.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        kerala.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        ladakh.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        madhyaPradesh.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        maharashtra.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        manipur.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        mizoram.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        odisha.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        puducherry.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        punjab.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        rajasthan.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        tamilNadu.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        telengana.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        uttarakhand.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        uttarPradesh.AddRange(selected);

        selected = stateDataText.Take(6).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        westBengal.AddRange(selected);

        selected = stateDataText.Take(5).ToList();
        selected.ForEach(i => stateDataText.Remove(i));
        totalIndia.AddRange(selected);

        foreach (string item in westBengal)
        {
            Debug.Log(item);
        }
    }
}
