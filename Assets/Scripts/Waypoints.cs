using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] wp;

    void Awake()
    {
        wp = new Transform[transform.childCount];
        for (int i = 0; i < wp.Length; i++)
        {
            wp[i] = transform.GetChild(i);
        }
    }
}
