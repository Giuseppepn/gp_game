using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MicController : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private PlayerController playerController;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    void Start()
    {
        playerController = GetComponent<PlayerController>();

        if (playerController != null)
        {
            Debug.Log("playerController component found!");
        }
        else
        {
            Debug.LogError("playerController component not found!");
        }

        actions.Add("apri", Apri);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += triggerEvent;
        keywordRecognizer.Start();
        Debug.Log("In ascolto...");


    }

    private void triggerEvent(PhraseRecognizedEventArgs e)
    {
        Debug.Log(e);
        actions[e.text].Invoke();
    }

    private void Apri()
    {

        playerController.checkChestCollision();
    }
}
