using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerFallDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RunnerController runner = other.GetComponent<RunnerController>();

        if (runner != null)
        {
            runner.SetIsFallingThroughGlass(true);
            runner.Die();
        }
    }
}
