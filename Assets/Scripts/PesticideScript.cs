using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PesticideScript : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;

    public GameObject shieldWindowImage;
    public Image Object;
    public Transform homePosition;
    public Transform hittingPoint;
    public ParticleSystem hitParticle;
    public Transform parent;

    public bool isOnHand = false;
    public int destroyedNumber = 0;

    private void Update()
    {
        if(isOnHand)
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0f));
            Object.transform.position = mouseWorldPosition;
        }
        else
        {
            Object.transform.position = homePosition.position;
        }
    }

    public void PickUp()
    {
        isOnHand = true;
        shieldWindowImage.SetActive(false);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(hitParticle,hittingPoint.position, Quaternion.identity,parent);
            FindObjectOfType<AudioManager>().Play("whipping Sound");
            hitParticle.Play();

            if (collision.gameObject.tag == "Bug")
            {
                collision.gameObject.SetActive(false);
                destroyedNumber++;
            }
        }
    }
}
