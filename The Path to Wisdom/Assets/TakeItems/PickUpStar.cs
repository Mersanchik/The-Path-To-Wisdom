using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStar : MonoBehaviour
{
    public GameObject camera;//������������ ������� ������

    //���������� �� ������� �� ������ ����������������� � ��������
    public float distance = 15f;

    //��� ���� ����� ������ �������� � �������� � ����� �� �����
    GameObject checkStar;

    //���������� ��� ���� ����� ��������, 
    //����� �� ����������������� � ������ ���������
    //��� ���
    public bool canPickUp;

    //��� ������ ������� ������� ����� ���������� ������
    public GameObject capsula2;
    public GameObject dialog2;

    //��� ����������� ����
    public GameObject BackgroundTeaching;
    public GameObject TextTeaching;

    public GameObject Hand;
    public GameObject Hand1;
    public GameObject Hand2;

    void Update()
    {
        /*
         * ��� ������� ������� E
         * � ��� ��������� ����� PickUp
         */
        if (Input.GetKeyDown(KeyCode.E))
        {       
            PickUp(); 
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            BackgroundTeaching.SetActive(false);
            TextTeaching.SetActive(false);
        }
    }

    void PickUp()
    {
        /*
         * ���� �� ����� �������� ����� �� ������� � ����� CheckStar
         * ������� ����� �� ��� �� ���������� �� 15 ������
         * �� �� ������ ��� ����� ����� � ������ ������� ��� ������ �����
         */
        RaycastHit hit;

        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "CheckStar")
            {
                Hand.SetActive(false);
                Hand1.SetActive(false);
                Hand2.SetActive(false);
                checkStar = hit.transform.gameObject;
                checkStar.GetComponent<Rigidbody>().isKinematic = true;
                checkStar.transform.parent = transform;
                checkStar.transform.localPosition = Vector3.zero;
                checkStar.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
                canPickUp = true;
                capsula2.SetActive(true);
                dialog2.SetActive(true);
                BackgroundTeaching.SetActive(true);
                TextTeaching.SetActive(true);
            }
        }
    }
}
