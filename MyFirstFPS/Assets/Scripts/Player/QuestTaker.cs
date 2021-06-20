using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTaker : MonoBehaviour
{
    [SerializeField]
    private float takeDistance = 5f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit, takeDistance))
            {
                Debug.Log("dd");
                IInteractible interactible = raycastHit.transform.GetComponent<IInteractible>();
                Debug.Log(interactible);
                if (interactible == null) return;
                interactible.Interact();
            }
        }
    }
}
