using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Transform cameraTransform;
    public float interactDistance;
    public GameObject centerPoint;
    public GameObject pressE;

    private RaycastHit hit;
    private GameObject currentGameObject;
    
    private Transform initialCameraTransform;
    private Transform endCameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cameraTransform.position,cameraTransform.forward);
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            currentGameObject = hit.collider.gameObject;
            if (currentGameObject.tag == "Interactable")
            {
                //中心圆点变成'Press E'
                centerPoint.SetActive(false);
                pressE.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //相机聚焦在物体上
                    initialCameraTransform = cameraTransform;
                    endCameraTransform = currentGameObject.transform.root.transform.GetChild(0).transform;
                    while (cameraTransform.position != endCameraTransform.position)
                    {
                        cameraTransform.position = Vector3.Lerp(cameraTransform.position, endCameraTransform.position, Time.deltaTime);
                    }
                    //冻结player controller
                    //显示光标
                    //中心圆点消失
                    //显示Fungus对话
                }
            }
            else
            {
                //Camera移走后再把中心圆点打开
                centerPoint.SetActive(true);
                pressE.SetActive(false);
            }
        }
    }
}
