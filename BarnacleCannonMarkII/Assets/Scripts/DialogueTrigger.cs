using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    //Abrir ventana
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    //Cerrar ventana forzosamente
    public void EndDialogue()
    {
        FindObjectOfType<DialogueManager>().ForceEndDialogue();

    }
}
