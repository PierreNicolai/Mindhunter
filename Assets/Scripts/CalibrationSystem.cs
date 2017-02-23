using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MindHunter.Managers;

public class CalibrationSystem : MonoBehaviour
{
    void Update()
    {
        print("Value : " + MindwaveInterface.Instance.attentionValue);
    }
}
