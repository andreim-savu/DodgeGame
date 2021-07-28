using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] BoxCollider trigger;
    [SerializeField] Material c1;
    [SerializeField] Material c2;
    [SerializeField] Renderer screen;
    [SerializeField] Material baseScreen;
    [SerializeField] Material damageScreen;

    [SerializeField] List<GameObject> cubeBody = new List<GameObject>();

    [SerializeField] Image actionImage;

    bool actionInProgress;

    float maxTimer;
    float timer;

    float maxScreenTimer = 0.15f;
    float screenTimer;

    void Start()
    {
        maxTimer = Random.Range(2.0f, 12.0f);
        timer = maxTimer;
        actionInProgress = true;
        SetupCube();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.i.playerAlive) { return; }

        if (!actionInProgress)
        {
            StartAction();
            return;
        }

        if (timer > 0)
        {
            actionImage.fillAmount = timer / maxTimer;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                screenTimer = maxScreenTimer;
                screen.material = damageScreen;
                trigger.enabled = true;
                GameController.i.AddScore(1);
            }
            return;
        }


        if (screenTimer > 0)
        {
            screenTimer -= Time.deltaTime;

            if (screenTimer <= 0.1f && trigger.enabled)
            {
                trigger.enabled = false;
            }
            if (screenTimer <= 0)
            {
                actionInProgress = false;
                screen.material = baseScreen;
            }
        }
    }

    void StartAction()
    {
        float tt = Mathf.Max(2.5f, 12.0f - GameController.i.score * 0.1f);
        maxTimer = Random.Range(2.0f, tt);
        timer = maxTimer;
        actionInProgress = true;
    }



    void SetupCube()
    {
        foreach (GameObject bodyPart in cubeBody)
        {
            if (transform.GetSiblingIndex() % 2 == 0) { bodyPart.GetComponent<Renderer>().material = c1; }
            else { bodyPart.GetComponent<Renderer>().material = c2; }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(1);
        }
    }
}
