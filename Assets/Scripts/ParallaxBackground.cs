using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public static ParallaxBackground instance;

    private void Awake()
    {
        instance = this;
    }

    private Transform theCam;
    public Transform bG, farTree, midTree, closeTree;
    [Range(0f, 1f)]
    public float parallaxSpeed;


    void Start()
    {
        theCam = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*bG.position = new Vector3(theCam.position.x, theCam.position.y, bG.position.z);
        farTree.position = new Vector3(theCam.position.x * parallaxSpeed, theCam.position.y, farTree.position.z);
        midTree.position = new Vector3(theCam.position.x * parallaxSpeed, theCam.position.y, farTree.position.z);
        closeTree.position = new Vector3(theCam.position.x * parallaxSpeed, theCam.position.y, farTree.position.z);*/
    }

    public void MoveBackground()
    {
        bG.position = new Vector3(theCam.position.x, theCam.position.y, bG.position.z);
        farTree.position = new Vector3(theCam.position.x * parallaxSpeed, theCam.position.y, farTree.position.z);
        midTree.position = new Vector3(theCam.position.x * parallaxSpeed, theCam.position.y, farTree.position.z);
        closeTree.position = new Vector3(theCam.position.x * parallaxSpeed, theCam.position.y, farTree.position.z);
    }
}
