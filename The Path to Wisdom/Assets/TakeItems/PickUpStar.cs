using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStar : MonoBehaviour
{
    public GameObject camera;//расположение главной камеры

    //расстояние на котором мы сможем взаимодействовать с объектом
    public float distance = 15f;

    //для того чтобы смогли обращать к объектам с таким же тэгом
    GameObject checkStar;

    //переменная для того чтобы понимать, 
    //можем мы взаимодействовать с данным предметом
    //или нет
    public bool canPickUp;

    //для работы второго диалога после нахождения звезды
    public GameObject capsula2;
    public GameObject dialog2;

    //для отображения кода
    public GameObject BackgroundTeaching;
    public GameObject TextTeaching;

    public GameObject Hand;
    public GameObject Hand1;
    public GameObject Hand2;

    void Update()
    {
        /*
         * При нажатие клавиши E
         * У нас сработает метод PickUp
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
         * Если мы будем смотреть прямо на предмет с тэгом CheckStar
         * Который будет от нас на расстоянии до 15 единиц
         * То мы сможем его взять взять в нужную позицию под нужным углом
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
