using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SetParent(gameObject.transform);

    }
    private void OnCollisionExit(Collision collision)
    {
        collision.transform.SetParent(null);
    }
}
