﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptacleTrigger : MonoBehaviour
{
    public DataUI DataUi;
    public Transform SnapPoint;

    private Collider obj = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (obj != null) return;
        var bookController = other.GetComponent<BookController>();
        if (bookController == null)
        {
            Debug.Log("Could not find controller");
            return;
        }
        
        other.GetComponent<GrabbableBook>().ForceEnd();
        other.GetComponent<Rigidbody>().isKinematic = true;
        bookController.transform.parent = transform;
        bookController.transform.position = SnapPoint.position;
        bookController.transform.rotation = SnapPoint.rotation;

        DataUi.SetData(bookController.Meta);
        obj = other;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == obj)
        {
            obj = null;
            DataUi.Clear();
        }
    }
}