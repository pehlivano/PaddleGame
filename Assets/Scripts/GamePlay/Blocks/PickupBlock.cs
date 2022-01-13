using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedupSprite;

    PickupEffect pickupEffect;

    float effectDuration;
    FreezerEffectActivated freezerEffectActivated;
    float speedupFactor;
    SpeedupEffectActivated speedupEffectActivated;

    // Start is called before the first frame update
    void Start()
    {
        blockPoint = ConfigurationUtils.PickupBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// Sets the effect for the pickup
    /// </summary>
    /// <value>pickup effect</value>
    public PickupEffect Effect
    {
        set
        {
            pickupEffect = value;

            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (pickupEffect == PickupEffect.Freezer)
            {                
                spriteRenderer.sprite = freezerSprite;
                effectDuration = ConfigurationUtils.FreezerEffectDuration;
                freezerEffectActivated = new FreezerEffectActivated();
                EventManager.AddFreezerEffectInvoker(this);
            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
                effectDuration = ConfigurationUtils.SpeedupEffectDuration;
                speedupFactor = ConfigurationUtils.SpeedupFactor;
                speedupEffectActivated = new SpeedupEffectActivated();
                EventManager.AddSpeedupEffectInvoker(this);
            }
        }
    }

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    public void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        speedupEffectActivated.AddListener(listener);
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (pickupEffect == PickupEffect.Freezer)
            {
                freezerEffectActivated.Invoke(effectDuration);
            }
            else if (pickupEffect == PickupEffect.Speedup)
            {
                speedupEffectActivated.Invoke(effectDuration, speedupFactor);
            }
            base.OnCollisionEnter2D(collision);
        }
    }
}
