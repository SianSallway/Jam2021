using System.Collections;
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
        DILEMMA_FIFTH,
        DILEMMA_FINAL
    };

    public DilemmaType dilemmaType;
    [SerializeField] PlayerController player;
    public CheckpointManager checkpointManager;
    public bool finalReached;

    [Header("UI Items")]

    [SerializeField] GameObject d1Text;
    [SerializeField] GameObject d2Text;
    [SerializeField] GameObject d3Text;
    [SerializeField] GameObject d4Text;
    [SerializeField] GameObject d5Text;
    [SerializeField] GameObject dFinalText;
    [SerializeField] GameObject handlingBtn;
    [SerializeField] GameObject speedBtn;
    [SerializeField] GameObject armourBtn;
    [SerializeField] GameObject waterBtn;
    [SerializeField] GameObject continueBtn;
    [SerializeField] GameObject backgroundImg;

    [Header("Player Death UI")]

    [SerializeField] GameObject deathText;
    [SerializeField] GameObject deathBtn;
    // Start is called before the first frame update
    void Start()
    {
        DisableUI();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        checkpointManager = GameObject.Find("CheckpointManager").GetComponent<CheckpointManager>();
        finalReached = false;
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
                    backgroundImg.SetActive(true);

                    handlingBtn.SetActive(true);
                    speedBtn.SetActive(true);
                    armourBtn.SetActive(false);
                    waterBtn.SetActive(false);

                    break;

                case DilemmaType.DILEMMA_TWO:

                    d1Text.SetActive(false);
                    d2Text.SetActive(true);
                    d3Text.SetActive(false);
                    d4Text.SetActive(false);
                    d5Text.SetActive(false);
                    dFinalText.SetActive(false);
                    backgroundImg.SetActive(true);

                    handlingBtn.SetActive(false);
                    speedBtn.SetActive(false);
                    armourBtn.SetActive(true);
                    waterBtn.SetActive(true);

                    break;

                case DilemmaType.DILEMMA_THREE:

                    d1Text.SetActive(false);
                    d2Text.SetActive(false);
                    d3Text.SetActive(true);
                    d4Text.SetActive(false);
                    d5Text.SetActive(false);
                    dFinalText.SetActive(false);
                    backgroundImg.SetActive(true);


                    handlingBtn.SetActive(false);
                    speedBtn.SetActive(true);
                    armourBtn.SetActive(true);
                    waterBtn.SetActive(false);

                    break;

                case DilemmaType.DILEMMA_FOUR:

                    d1Text.SetActive(false);
                    d2Text.SetActive(false);
                    d3Text.SetActive(false);
                    d4Text.SetActive(true);
                    d5Text.SetActive(false);
                    dFinalText.SetActive(false);
                    backgroundImg.SetActive(true);

                    handlingBtn.SetActive(false);
                    speedBtn.SetActive(false);
                    armourBtn.SetActive(true);
                    waterBtn.SetActive(true);

                    break;

                case DilemmaType.DILEMMA_FIFTH:

                    d1Text.SetActive(false);
                    d2Text.SetActive(false);
                    d3Text.SetActive(false);
                    d4Text.SetActive(false);
                    d5Text.SetActive(true);
                    dFinalText.SetActive(false);
                    backgroundImg.SetActive(true);

                    handlingBtn.SetActive(true);
                    speedBtn.SetActive(true);
                    armourBtn.SetActive(false);
                    waterBtn.SetActive(false);

                    break;

                case DilemmaType.DILEMMA_FINAL:

                    d1Text.SetActive(false);
                    d2Text.SetActive(false);
                    d3Text.SetActive(false);
                    d4Text.SetActive(false);
                    d5Text.SetActive(false);
                    dFinalText.SetActive(true);
                    backgroundImg.SetActive(true);

                    handlingBtn.SetActive(true);
                    speedBtn.SetActive(true);
                    armourBtn.SetActive(false);
                    waterBtn.SetActive(false);
                    continueBtn.SetActive(true);

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
        //player.defaultSpeed += 1.0f;

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
        DisableUI();

        GameObject[] raidersInScene = GameObject.FindGameObjectsWithTag("Raider");

        foreach(GameObject raider in raidersInScene)
        {
            Destroy(raider);
        }

        deathBtn.SetActive(true);
        deathText.SetActive(true);
    }

    public void Continue()
    {
        deathBtn.SetActive(false);
        deathText.SetActive(false);
        checkpointManager.ActivateCheckpoint();
        Destroy(player.gameObject);
    }

    void FinalDilemma()
    {
        finalReached = true;
        player.health = player.maxHealth;
        player.water = player.maxWater;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name + 1);
    }

    void DisableUI()
    {
        d1Text.SetActive(false);
        d2Text.SetActive(false);
        d3Text.SetActive(false);
        d4Text.SetActive(false);
        d5Text.SetActive(false);
        dFinalText.SetActive(false);
        backgroundImg.SetActive(false);

        handlingBtn.SetActive(false);
        speedBtn.SetActive(false);
        armourBtn.SetActive(false);
        waterBtn.SetActive(false);
        continueBtn.SetActive(false); 
    }
}