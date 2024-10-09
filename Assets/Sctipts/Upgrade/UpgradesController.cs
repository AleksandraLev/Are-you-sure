using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
    [SerializeField]
    TMP_Text priceText;

    [SerializeField]
    float inetMultiplier;
    [SerializeField]
    float politicMultiplier;
    [SerializeField]
    float classicMultiplier;

    [SerializeField]
    float inetCost;
    [SerializeField]
    float politicCost;
    [SerializeField]
    float classicCost;

    [SerializeField]
    float inetM0;
    [SerializeField]
    float politicM0;
    [SerializeField]
    float classicM0;

    [SerializeField]
    float inetK;
    [SerializeField]
    float politicK;
    [SerializeField]
    float classicK;

    [SerializeField]
    float inetX0;
    [SerializeField]
    float politicX0;
    [SerializeField]
    float classicX0;

    [SerializeField]
    float inetP;
    [SerializeField]
    float politicP;
    [SerializeField]
    float classicP;

    float moneyFactor = 0.05f;
    float followersFactor = 0;
    int level = 0;
    float multiplier = 0f;
    float baseCost = 0f;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("moneyFactor"))
        {
            moneyFactor = PlayerPrefs.GetFloat("moneyFactor");
        }

        if (PlayerPrefs.HasKey("followersFactor"))
        {
            followersFactor = PlayerPrefs.GetFloat("followersFactor");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("path"))
        {
            string tag = "";
            var path = PlayerPrefs.GetInt("path");

            if (path == 0)
            {
                tag = "internet";
                multiplier = inetMultiplier;
                baseCost = inetCost;
            }
            if (path == 1)
            {
                tag = "politic";
                multiplier = politicMultiplier;
                baseCost = politicCost;
            }
            if (path == 2)
            {
                tag = "classic";
                multiplier = classicMultiplier;
                baseCost = classicCost;
            }

            if (PlayerPrefs.HasKey(tag))
            {
                level = PlayerPrefs.GetInt(tag);
            }

            var price = Mathf.RoundToInt(baseCost * Mathf.Pow(multiplier, level));
            priceText.text = price.ToString();
        }
    }

    public void FactorsCalculate()
    {
        string tag = "";
        var path = PlayerPrefs.GetInt("path");

        float m0 = 0;
        float k = 0;
        float x0 = 0;
        float p = 0;

        if (path == 0)
        {
            tag = "internet";
            m0 = inetM0;
            k = inetK;
            x0 = inetX0;
            p = inetP;
        }
        if (path == 1)
        {
            tag = "politic";
            m0 = politicM0;
            k = politicK;
            x0 = politicX0;
            p = politicP;
        }
        if (path == 2)
        {
            tag = "classic";
            m0 = classicM0;
            k = classicK;
            x0 = classicX0;
            p = classicP;
        }

        if (PlayerPrefs.HasKey(tag))
        {
            level = PlayerPrefs.GetInt(tag);
        }

        var m = m0 * Mathf.Pow((1 + k), level);
        var x = x0 * Mathf.Pow((1 + p), level);

        PlayerPrefs.SetFloat("moneyFactor", m);
        PlayerPrefs.SetFloat("followersFactor", x);

        Debug.Log($"{m} {x}");
    }
}
