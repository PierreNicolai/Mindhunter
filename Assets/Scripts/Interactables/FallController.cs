using System.Linq;
using UnityEngine;

public class FallController : MonoBehaviour
{
    public GameObject[] Woots;

    public void KillWoots()
    {
        Woots.ToList().ForEach(go => Destroy(go));
    }
}
