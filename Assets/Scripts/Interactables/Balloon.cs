using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : Pickupable, Usable
{
    public AnimationCurve inflationCurve;
    public float inflationSpeed = .2f;
    public float deflationSpeed = .1f;

    Vector3 initialScale;
    Vector3 initialPosition;
    float inflationProgess;

    PlayerCharacter currentUser;

    bool Usable.Use(PlayerCharacter user)
    {
        currentUser = user;
        inflationProgess += inflationSpeed;

        if (inflationProgess > 1)
        {
            Pop();
            user.objectToUse = null;
            ((Usable) this).StopUsing();
            return false;
        } else
        {
            //Inflate(inflationCurve.Evaluate(inflationProgess));
        }
        return true;
    }

    bool Usable.StopUsing() {
        if (currentUser) {
            currentUser.moveDisabled = false;
        }
        Debug.Log("Stop using!");
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        inflationProgess -= Time.deltaTime * deflationSpeed;
        if (inflationProgess < 0)
        {
            inflationProgess = 0;
        }
        Inflate(inflationCurve.Evaluate(inflationProgess));
    }

    void Pop()
    {
        Destroy(this.gameObject);
    }

    void Inflate(float progress)
    {
        this.transform.localScale = initialScale + new Vector3(initialScale.x * progress, initialScale.y * progress, 0);
    }
}
