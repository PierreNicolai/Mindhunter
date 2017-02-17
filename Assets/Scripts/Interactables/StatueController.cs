using UnityEngine;

public class StatueController : Target {

    public GameObject Lustre;
    public GameObject chaine;
        
    public override void OnShot()
    {
        Lustre.GetComponent<Animator>().Play("Fall");
        Destroy(chaine);
    }
}
