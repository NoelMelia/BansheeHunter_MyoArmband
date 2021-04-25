using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private float gizmoRadius = 0.25f;
    // Just used for Debugging
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }
}
