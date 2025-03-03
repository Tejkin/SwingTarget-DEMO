using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

public class SliceObject : MonoBehaviour
{
    [SerializeField] private TargetsDestroyed linkedTargetControl;
    [SerializeField] private ScoreManager linkedScoreManager;
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;

    public Material crossSectionMaterial;
    public float cutForce = 100;

    [Header("Debug")]
    public bool debugSlice = false;
    public Transform planeDebug;
    public GameObject debugTarget;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (debugSlice && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Slice(debugTarget);
            Debug.Log("space key pressed");
        }
    }

    void FixedUpdate()
    {
        

        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            Debug.Log("has hit");
            GameObject target = hit.transform.gameObject;
            Slice(target);
            if (target.tag == "LevelExit")
            {
                int activeScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(activeScene + 1);
                Debug.Log("Loading Scene: " + SceneManager.GetSceneByBuildIndex(activeScene + 1));
                return;
            }

            linkedTargetControl.DestroyTarget();
            linkedScoreManager.Score();
        }
    }

    public void Slice(GameObject target)
    {
        
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();
        if (debugSlice)
        {
            SlicedHull debugHull = target.Slice(planeDebug.position, planeDebug.up);

            if (debugHull != null)
            {
                GameObject debugUpperHull = debugHull.CreateUpperHull(target, crossSectionMaterial);

                GameObject debugLowerHull = debugHull.CreateLowerHull(target, crossSectionMaterial);

                Destroy(target);
            }
        }

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);
        Debug.Log("Sliced object");

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            

            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            

            Destroy(target);
            SetUpSlicedComponent(upperHull);
            SetUpSlicedComponent(lowerHull);
            Debug.Log("destroyed object");
        }
    }

    public void SetUpSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        //rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);

        Debug.Log("Created hull");
    }
}
