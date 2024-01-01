using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PesticideScript : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;
    public Image Object;
    public Transform homePosition;
    public Transform hittingPoint;

    public bool isOnHand = false;

    private void Update()
    {
        if(isOnHand)
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Object.transform.position = mouseWorldPosition;
        }
        else
        {
            Object.transform.position = homePosition.position;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            isOnHand = false;
        }
    }

    public void PickUp()
    {
        isOnHand = true;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.gameObject.tag == "Bug")
        {
            Debug.Log("Bug");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Destroy");
                Destroy(collision);
            }
        }
    }
}
