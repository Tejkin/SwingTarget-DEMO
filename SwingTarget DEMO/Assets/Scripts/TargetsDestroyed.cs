using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetsDestroyed : MonoBehaviour
{
    [SerializeField] private int numberOfTargetsToDestroy;
    [SerializeField] private int currentlyDestroyedTargets = 0;

    [Header("Completion Events")]
    public UnityEvent onTargetsDestroyed;

    private void Start()
    {

    }

    public void DestroyTarget()
    {
        currentlyDestroyedTargets++;
        CheckIfTargetsDestroyed();

    }

    private void CheckIfTargetsDestroyed()
    {
        if (currentlyDestroyedTargets >= numberOfTargetsToDestroy)
        {
            onTargetsDestroyed.Invoke();
        }
    }
}


