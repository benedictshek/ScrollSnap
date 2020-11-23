using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class AutoCreateContents : MonoBehaviour
{
    public GameObject Contents_Prefab;

    [Header("Years")]
    public Transform Contents_Year;
    public int Years;
    public int EarliestYear;
    public SimpleScrollSnap SimpleScrollSnap_Year;
    private int _selectedYear = 2020;
    public int NumOfYears;

    [Header("Months")]
    public Transform Contents_Month;
    public int Months;
    public int LastMonth;
    public SimpleScrollSnap SimpleScrollSnap_Month;
    private int _selectedMonth = 1;

    [Header("Days")]
    public Transform Contents_Day;
    public int Days;
    public int LastDay;
    public SimpleScrollSnap SimpleScrollSnap_Day;
    private int _selectedDay = 1;

    [Header("Birthday")]
    public Text SelectedBirthdayTxt;

    void Start()
    {
        //for years from 2020 to 1900
        for (int i = Years; i >= EarliestYear; i--)
        {
            //instantiate content for each year
            GameObject contentChild = Instantiate(Contents_Prefab);
            //set all the spawned contents to the child of the Content
            contentChild.transform.SetParent(Contents_Year, false);

            //get the text from each child content
            Text year = contentChild.GetComponentInChildren<Text>();
            //set the text for each year
            year.text = Years.ToString() + " 年";

            //set each child content name corresponding to each year
            contentChild.name = Years.ToString();
            //update the years
            Years--;
        }

        //for months from Jan to Dec
        for (int i = Months; i <= LastMonth; i++)
        {
            GameObject contentChild = Instantiate(Contents_Prefab);
            contentChild.transform.SetParent(Contents_Month, false);

            Text month = contentChild.GetComponentInChildren<Text>();
            month.text = Months.ToString() + " 月";

            contentChild.name = Months.ToString();
            Months++;
        }

        //for days from 1 to 31
        for (int i = Days; i <= LastDay; i++)
        {
            GameObject contentChild = Instantiate(Contents_Prefab);
            contentChild.transform.SetParent(Contents_Day, false);

            Text day = contentChild.GetComponentInChildren<Text>();
            day.text = Days.ToString() + " 日";

            contentChild.name = Days.ToString();
            Days++;
        }
    }

    //Update the selected year
    public void OnSelectYear()
    {
        _selectedYear = NumOfYears - SimpleScrollSnap_Year.CurrentPanel;
    }

    //Update the selected month
    public void OnSelectMonth()
    {
        _selectedMonth = SimpleScrollSnap_Month.CurrentPanel + 1;
    }

    //Update the selected day
    public void OnSelectDay()
    {
        _selectedDay = SimpleScrollSnap_Day.CurrentPanel + 1;
    }

    //Update the selected birthday
    void Update()
    {
        SelectedBirthdayTxt.text = _selectedYear.ToString() + " / " + _selectedMonth.ToString() + " / " + _selectedDay.ToString();
    }
}
