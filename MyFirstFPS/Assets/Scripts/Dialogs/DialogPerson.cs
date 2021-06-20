using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPerson : MonoBehaviour
{
    public Text messageText;
    [SerializeField]
    private GameObject messagePanel;
    [SerializeField]
    private float maxDist = 5f;
    [Header("Dialogs")]
    public Dialog[] dialogs;

    private Transform player;
    private bool isDialogNow = false;

    private void Start()
    {
        messagePanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isDialogNow)
        {
            if (Vector3.Distance(transform.position,player.position) < maxDist)
            {

                Chat();
            }
        }
    }



    private void Chat()
    {
        Toggle(true);

        for (int i = 0; i < dialogs.Length; i++)
        {
            if (!dialogs[i].isEnded)
            {
                StartCoroutine(BeginDialog(dialogs[i]));
                return;
            }
        }
        Toggle(false);
    }

    private IEnumerator BeginDialog(Dialog dia)
    {
        
        int index = 0;
        while(index < dia.msg.Length)
        {
            messageText.text = dia.msg[index];
            yield return new WaitUntil(() => (Input.GetMouseButtonUp(0)));
            yield return null;
            index++;
        }
        dia.isEnded = true;

        Toggle(false);
    }
    private void Toggle(bool state) //Toggles state of dialog and disables/enables player control
    {

        isDialogNow = state;
        messagePanel.SetActive(state);
        player.GetComponent<playerController>().enabled = !state;
        player.GetComponent<Shooting>().enabled = !state;
    }

}
