using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddlePrefab;

    [SerializeField]
    GameObject standartBlockPrefab;

    [SerializeField]
    GameObject bonusBlockPrefab;

    [SerializeField]
    GameObject pickupBlockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(paddlePrefab);

        // Get block sizes
        GameObject tempBlock = Instantiate<GameObject>(standartBlockPrefab);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        float blockWidth = collider.size.x;
        float blockHeight = collider.size.y;
        Destroy(tempBlock);

        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        
        int blocksPerRow = (int)(screenWidth / blockWidth);

        float totalBlockWidth = blocksPerRow * blockWidth;
        float leftBlockOffset = ScreenUtils.ScreenLeft +
            (screenWidth - totalBlockWidth) / 2 +
            blockWidth / 2;

        float topRowOffset = ScreenUtils.ScreenTop -
            (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 5 -
            blockHeight / 2;

        Vector2 currentPosition = new Vector2(leftBlockOffset, topRowOffset);

        for(int row=0; row<3; row++)
        {
            for(int column=0; column<blocksPerRow; column++)
            {
                //GameObject pickupBlock = Instantiate(pickupBlockPrefab, currentPosition, Quaternion.identity);
                //PickupBlock pickupBlockScript = pickupBlock.GetComponent<PickupBlock>();
                //pickupBlockScript.Effect = PickupEffect.Speedup;
                buildBlock(currentPosition);
                currentPosition.x += blockWidth;
            }
            currentPosition.x = leftBlockOffset;
            currentPosition.y += blockHeight;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void buildBlock(Vector2 position)
    {
        float randomValue = Random.value;
        print(randomValue);

        if(randomValue < ConfigurationUtils.StandartBlockProbability)
        {
            Instantiate<GameObject>(standartBlockPrefab, position, Quaternion.identity);
        }
        else if(randomValue < ConfigurationUtils.StandartBlockProbability + ConfigurationUtils.BonusBlockProbability)
        {
            Instantiate<GameObject>(bonusBlockPrefab, position, Quaternion.identity);
        }
        else
        {
            // pickup block selected
            GameObject pickupBlock = Instantiate(pickupBlockPrefab, position, Quaternion.identity);
            PickupBlock pickupBlockScript = pickupBlock.GetComponent<PickupBlock>();

            // set pickup effect
            float freezerThreshold = ConfigurationUtils.StandartBlockProbability +
                ConfigurationUtils.BonusBlockProbability +
                ConfigurationUtils.FreezerBlockProbability;
            if (randomValue < freezerThreshold)
            {
                pickupBlockScript.Effect = PickupEffect.Freezer;
            }
            else
            {
                pickupBlockScript.Effect = PickupEffect.Speedup;
            }
        }
    }
}
