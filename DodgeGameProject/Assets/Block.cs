using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] Material c1;
    [SerializeField] Material c2;
    [SerializeField] Renderer screen;
    [SerializeField] Material baseScreen;
    [SerializeField] Material damageScreen;

    [SerializeField] Sprite damageSprite;
    [SerializeField] Sprite pushSprite;
    [SerializeField] Sprite pushDamageSprite;
    [SerializeField] Sprite attackSprite;

    enum blockAction {INACTIVE, DAMAGE, PUSH, PUSHDAMAGE, ATTACK};
    blockAction state = blockAction.INACTIVE;

    [SerializeField] List<GameObject> cubeBody = new List<GameObject>();

    [SerializeField] Image actionImage;

    Vector3 pushDirection;

    bool actionInProgress;

    float maxTimer;
    float timer;

    float maxScreenTimer = 0.15f;
    float screenTimer;

    bool playerOn;

    void Start()
    {
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
                TriggerAction();
            }
            return;
        }


        if (screenTimer > 0)
        {
            screenTimer -= Time.deltaTime;

            state = blockAction.INACTIVE;
            
            if (screenTimer <= 0)
            {
                actionInProgress = false;
                screen.material = baseScreen;
            }
        }
    }

    void TriggerAction()
    {
        if (playerOn)
        {
            switch (state)
            {
                case blockAction.DAMAGE:
                    PlayerStats.i.TakeDamage(1);
                    break;
                case blockAction.PUSH:
                    PlayerStats.i.playerMovement.StartPush(pushDirection);
                    break;
                case blockAction.PUSHDAMAGE:
                    PlayerStats.i.TakeDamage(1);
                    PlayerStats.i.playerMovement.StartPush(pushDirection);
                    break;
            }
        }
    }

    public void SetAction(string action, float duration, string direction = "")
    {
        if (actionInProgress) { return; }
        switch (direction)
        {
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
            default:
                pushDirection = Vector3.forward;
                actionImage.transform.localEulerAngles = new Vector3(0, 0, 0);
                break;
        }

        switch (action)
        {
            case "damage":
                state = blockAction.DAMAGE;
                actionImage.sprite = damageSprite;
                break;
            case "push":
                state = blockAction.PUSH;
                actionImage.sprite = pushSprite;
                break;
            case "pushdamage":
                state = blockAction.PUSHDAMAGE;
                actionImage.sprite = pushDamageSprite;
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

    public Block OccupyCube(bool occupy)
    {
        if (occupy)
        {
            foreach (GameObject bodyPart in cubeBody)
            {
                bodyPart.GetComponent<Renderer>().material = c2; 
            }
            playerOn = true;
        }
        else
        {
            foreach (GameObject bodyPart in cubeBody)
            {
                bodyPart.GetComponent<Renderer>().material = c1;
            }
            playerOn = false;
        }
        return this;
    }
}
