using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBlock : Block
{
    [SerializeField]
    Sprite sprite1;
    [SerializeField]
    Sprite sprite2;
    [SerializeField]
    Sprite sprite3;

    // Start is called before the first frame update
    void Start()
    {
        blockPoint = ConfigurationUtils.StandartBlockPoints;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = sprite1;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
