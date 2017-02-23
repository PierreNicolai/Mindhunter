using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MindHunter.Managers;

public class CalibrationSystem : MonoBehaviour
{
    private int CalibrationValue;

    private List<int> mindwaveValues;

    void Start()
    {
        CalibrationValue = 75;
        mindwaveValues = new List<int>();

        StartCoroutine(ReadMindwaveValues());
    }

    private IEnumerator ReadMindwaveValues()
    {
        List<int> inferiorList = new List<int>();
        List<int> superiorList = new List<int>();

        for(int i = 0; i < 10; i++)
        {
            int value = MindwaveInterface.Instance.attentionValue;
            if (value < CalibrationValue)
                inferiorList.Add(value);
            else
                superiorList.Add(value);
            yield return new WaitForSeconds(1f);
        }
        float infAverage = CalibrationValue;
        float supAverage = CalibrationValue;
        if (inferiorList.Any())
             infAverage = (float)inferiorList.Average();
        if(superiorList.Any())
            supAverage = (float)superiorList.Average();
        CalibrationValue = Mathf.CeilToInt((infAverage + CalibrationValue * 2 + supAverage) / 4);
        Player.Instance.GetComponent<PowerController>().attentionTrigger = CalibrationValue;

        print("NEW CALIBRATION VALUE : " + CalibrationValue);

        StartCoroutine(ReadMindwaveValues());
    }
}
