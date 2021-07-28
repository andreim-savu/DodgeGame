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

    [SerializeField] Sprite damageSprite;
    [SerializeField] Sprite pushSprite;
    [SerializeField] Sprite attackSprite;

    enum blockAction {INACTIVE, DAMAGE, PUSH, ATTACK};
    blockAction state = blockAction.INACTIVE;

    [SerializeField] List<GameObject> cubeBody = new List<GameObject>();

    [SerializeField] Image actionImage;

    Vector3 pushDirection;

    bool actionInProgress;

    float maxTimer;
    float timer;

    float maxScreenTimer = 0.15f;
    float screenTimer;

    void Start()
    {
        SetupCube();
    }

    void Update()
    {
        if (!GameController.i.playerAlive) { return; }

        if (!actionInProgress)
        {
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
                actionImage.enabled = false;
                trigger.enabled = true;
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

    public void SetAction(string action, float duration, string direction = "")
    {
        actionImage.transform.localEulerAngles = new Vector3(0, 0, 0);
        switch (action)
        {
            case "damage":
                state = blockAction.DAMAGE;
                actionImage.sprite = damageSprite;
                break;
            case "push":
                state = blockAction.PUSH;
                actionImage.sprite = pushSprite;
                switch (direction)
                {
                    case "up":
                        pushDirection = Vector3.forward;
                        actionImage.transform.localEulerAngles = new Vector3(0, 0, 0);
                        break;
                    case "right":
                        pushDirection = Vector3.right;
                        actionImage.transform.localEulerAngles = new Vector3(0, 0, 270);
                        break;
                    case "down":
                        pushDirection = Vector3.back;
                        actionImage.transform.localEulerAngles = new Vector3(0, 0, 180);
                        break;
                    case "left":
                        pushDirection = Vector3.left;
                        actionImage.transform.localEulerAngles = new Vector3(0, 0, 90);
                        break;
                }
                break;
            case "attack":
                state = blockAction.ATTACK;
                actionImage.sprite = attackSprite;
                break;
        }

        actionImage.enabled = true;

        maxTimer = duration;
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
            print(state);
            switch (state)
            {
                case blockAction.DAMAGE:
                    other.GetComponent<PlayerStats>().TakeDamage(1);
                    break;
                case blockAction.PUSH:
                    other.GetComponent<PlayerMovement>().StartPush(pushDirection);
                    break;
            }
        }
    }
}
