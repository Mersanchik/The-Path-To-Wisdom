using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject checkBox;
    GameObject checkBox1;
    GameObject checkBox2;
    GameObject checkBox3;
    GameObject checkBox4;
    public GameObject Hand;
    public bool canPickUp;

    public GameObject capsula2;
    public GameObject dialog2;

    int countBox = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
        if (countBox == 5)
        {
            capsula2.SetActive(true);
            dialog2.SetActive(true);
            Hand.SetActive(false);
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "CheckBox")
            {
                checkBox = hit.transform.gameObject;
                checkBox.GetComponent<Rigidbody>().isKinematic = true;
                checkBox.transform.parent = transform;
                checkBox.transform.localPosition = Vector3.zero;
                checkBox.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
                canPickUp = true;
                countBox++;
                checkBox.SetActive(false);
                
            }

            if (hit.transform.tag == "CheckBox1")
            {
                checkBox1 = hit.transform.gameObject;
                checkBox1.GetComponent<Rigidbody>().isKinematic = true;
                checkBox1.transform.parent = transform;
                checkBox1.transform.localPosition = Vector3.zero;
                checkBox1.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
                canPickUp = true;
                countBox++;
                checkBox1.SetActive(false);

            }

            if (hit.transform.tag == "CheckBox2")
            {
                checkBox2 = hit.transform.gameObject;
                checkBox2.GetComponent<Rigidbody>().isKinematic = true;
                checkBox2.transform.parent = transform;
                checkBox2.transform.localPosition = Vector3.zero;
                checkBox2.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
                canPickUp = true;
                countBox++;
                checkBox2.SetActive(false);

            }

            if (hit.transform.tag == "CheckBox3")
            {
                checkBox3 = hit.transform.gameObject;
                checkBox3.GetComponent<Rigidbody>().isKinematic = true;
                checkBox3.transform.parent = transform;
                checkBox3.transform.localPosition = Vector3.zero;
                checkBox3.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
                canPickUp = true;
                countBox++;
                checkBox3.SetActive(false);

            }

            if (hit.transform.tag == "CheckBox4")
            {
                checkBox4 = hit.transform.gameObject;
                checkBox4.GetComponent<Rigidbody>().isKinematic = true;
                checkBox4.transform.parent = transform;
                checkBox4.transform.localPosition = Vector3.zero;
                checkBox4.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
                canPickUp = true;
                countBox++;
                checkBox4.SetActive(false);

            }

            
        }
    }
}
