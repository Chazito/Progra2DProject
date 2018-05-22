using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    // Se inicia una nueva lista de oraciones que seran mostradas.
    void Start()
    {
        sentences = new Queue<string>();
    }

    //Abre el dialogo y lo llena con las oraciones entregadas
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
    }

    //Muestra la siguiente oracion.
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }


        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //Cierra la ventana de dialogo sin importar si termino de pasar los contenidos.
    public void ForceEndDialogue()
    {
        if (animator.GetBool("isOpen"))
        {
            StopAllCoroutines();
            EndDialogue();
        }

    }

    //Retorna el estado actual de la ventana de dialogo, true = abierta. False = cerrada.
    public bool getWindowOpen()
    {
        return animator.GetBool("isOpen");
    }

    //Cierra la ventana de dialogo al terminar con todo el texto disponible
    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }
}
