using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GlowObject))]
public class Liane : Target {

    public override void OnShot()
    {
        Destroy(gameObject);
    }
}
