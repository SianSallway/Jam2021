﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DilemmaManager : MonoBehaviour
{
    public enum DilemmaType
    {
        DILEMMA_ONE,
        DILEMMA_TWO,
        DILEMMA_THREE,
        DILEMMA_FOUR,
        DILEMMA_FIVE,
        DILEMMA_SIX,
        DILEMMA_FINAL
    };

    public DilemmaType dilemmaType;
    [SerializeField] GameObject cameraRig;
    [SerializeField] PlayerController player;
    public CheckpointManager checkpointManager;
    public bool dilemmaReached;

    [Header("UI Items")]

    [SerializeField] GameObject d1Text;
    [SerializeField] GameObject d2Text;
    [SerializeField] GameObject d3Text;
    [SerializeField] GameObject d4Text;
    [SerializeField] GameObject d5Text;
    [SerializeField] GameObject d6Text;
    [SerializeField] GameObject dFinalText;
    [SerializeField] GameObject pauseUI;

    [SerializeField] GameObject opening;

    [Header("Player Death UI")]

    [SerializeField] GameObject deathUI;
    // Start is called before the first frame update
    void Start()
    {
        DisableUI();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        checkpointManager = GameObject.Find("CheckpointManager").GetComponent<CheckpointManager>();
        dilemmaReached = true;
        cameraRig = GameObject.Find("CameraRig");
        opening.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            switch (dilemmaType)
            {
                case DilemmaType.DILEMMA_ONE:

                    d1Text.SetActive(true);
                    d2Text.SetActive(false);
                    d3Text.SetActive(false);
                    d4Text.SetActive(false);
                    d5Text.SetActive(false);
                    dFinalText.SetActive(false);
           
                    dilemmaReached = true;

                    break;

                case DilemmaType.DILEMMA_TWO:

                    d1Text.SetActive(false);
                    d2Text.SetActive(true);
                    d3Text.SetActive(false);
                    d4Text.SetActive(false);
                    d5Text.SetActive(false);
                    dFinalText.SetActive(false);
  ;
                    dilemmaReached = true;

                    break;

                case DilemmaType.DILEMMA_THREE:

                    d1Text.SetActive(false);
                    d2Text.SetActive(false);
                    d3Text.SetActive(true);
                    d4Text.SetActive(false);
                    d5Text.SetActive(false);
                    dFinalText.SetActive(false);

                    dilemmaReached = true;

                    break;

                case DilemmaType.DILEMMA_FOUR:

                    d1Text.SetActive(false);
                    d2Text.SetActive(false);
                    d3Text.SetActive(false);
                    d4Text.SetActive(true);
                    d5Text.SetActive(false);
                    dFinalText.SetActive(false);
             
                    dilemmaReached = true;

                    break;

                case DilemmaType.DILEMMA_FIVE:

                    d1Text.SetActive(false);
                    d2Text.SetActive(false);
                    d3Text.SetActive(false);
                    d4Text.SetActive(false);
                    d5Text.SetActive(true);
                    dFinalText.SetActive(false);
         
                    dilemmaReached = true;

                    break;

                case DilemmaType.DILEMMA_SIX:

                    d1Text.SetActive(false);
                    d2Text.SetActive(false);
                    d3Text.SetActive(false);
                    d4Text.SetActive(false);
                    d5Text.SetActive(false);
                    d6Text.SetActive(true);
                    dFinalText.SetActive(false);
          

                    dilemmaReached = true;


                    break;

                case DilemmaType.DILEMMA_FINAL:

                    d1Text.SetActive(false);
                    d2Text.SetActive(false);
                    d3Text.SetActive(false);
                    d4Text.SetActive(false);
                    d5Text.SetActive(false);
                    dFinalText.SetActive(true);


                    FinalDilemma();

                    break;
            }
        }        
    }

    public void UpgradeHandling()
    {
        player.handling += 0.2f;
        player.rigidbody.angularDrag -= 10f;

        if(player.rigidbody.angularDrag <= 0)
        {
            player.rigidbody.angularDrag = 0f;
        }

        if (player.handling >= 2)
        {
            player.handling = 2f;
        }

        DisableUI();
    }

    public void UpgradeArmour()
    {
        player.maxHealth += 5f;

        if (player.maxHealth >= 50f)
        {
            player.maxHealth = 50f;
        }

        DisableUI();
    }

    public void UpgradeSpeed()
    {
        player.acceleratedSpeed += 0.2f;
        //cameraRig.GetComponent<Camera>().orthographicSize += 0.4f;
        //
        //if (cameraRig.GetComponent<Camera>().orthographicSize >= 12f)
        //{
        //    cameraRig.GetComponent<Camera>().orthographicSize = 12;
        //}

        if (player.acceleratedSpeed >= 2.5f)
        {
            player.acceleratedSpeed = 2.5f;
        }

        DisableUI();
    }

    public void UpgradeWater()
    {
        player.maxWater += 5f;

        if (player.maxWater >= 90f)
        {
            player.maxWater = 90f;
        }

        DisableUI();
    }

    public void DeathDilemma()
    {
        //DisableUI();

        dilemmaReached = true;

        GameObject[] raidersInScene = GameObject.FindGameObjectsWithTag("Raider");

        foreach(GameObject raider in raidersInScene)
        {
            Destroy(raider);
        }

        deathUI.SetActive(true);
    }

    public void Continue()
    {
        DisableUI();

        checkpointManager.ActivateCheckpoint();
        Destroy(player.gameObject);
    }

    public void Resume()
    {
        DisableUI();

    }

    public void Go()
    {
        DisableUI();

    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        dilemmaReached = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void FinalDilemma()
    {
        dilemmaReached = true;
        player.health = player.maxHealth;
        player.water = player.maxWater;

    }

    void DisableUI()
    {
        d1Text.SetActive(false);
        d2Text.SetActive(false);
        d3Text.SetActive(false);
        d4Text.SetActive(false);
        d5Text.SetActive(false);
        d6Text.SetActive(false);
        dFinalText.SetActive(false);
        deathUI.SetActive(false);
        pauseUI.SetActive(false);

        opening.SetActive(false);
        dilemmaReached = false;

    }
}