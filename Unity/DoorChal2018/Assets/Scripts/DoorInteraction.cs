using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour {

    //TEMPNOTES
    //IA = Interaction


    public bool openCondition = true;
    private string seenObjectName;
    RaycastHit userRayHit;
    float userRayReach = 1.0f;
    private Animator anim;

    private int hashTrigger = Animator.StringToHash("doorTrigger");

    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update () {
        userIA();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenDoor();
        }
    }


    private void userIA()
    {
        //Create Ray
        Ray userRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        if (Input.GetKeyDown("e"))
        {
            if (Physics.Raycast(userRay, out userRayHit, userRayReach))
            {
                seenObjectName = userRayHit.collider.gameObject.transform.parent.name;
                Debug.Log(seenObjectName);

                IAHandling(seenObjectName);
            }
            else
                Debug.Log("Nothing Hit");          
        }
    }

    private void IAHandling(string objName)
    {
        switch (objName)
        {
            case "DoorFrame":
                OpenDoor();
                break;
            case "DoorBlades":
                OpenDoor();
                break;
        }
    }

    private void OpenDoor()
    {
        if (openCondition)
        {
            anim.SetTrigger(hashTrigger);
        }

    }
}
