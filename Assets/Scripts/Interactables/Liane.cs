using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liane : Target {

    public override void OnShot()
    {
        Destroy(this.gameObject);
    }
}
