using UnityEngine;

public class StatueController : Target {

    public GameObject Lustre;
    
    public override void OnShot()
    {
        Lustre.GetComponent<Animator>().Play("Fall");
    }
}
