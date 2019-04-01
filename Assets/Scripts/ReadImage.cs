using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadImage : MonoBehaviour
{
    [SerializeField] private Texture2D[] images;
    private Texture2D image;

    [SerializeField] private GameObject wallObject;
    [SerializeField] private GameObject groundObject;

    // For rezising images:
    // https://resizeimage.net/
    // TODO for tomorrow: create prefabs to instantiate and follow along video at 18:00 at https://www.youtube.com/watch?v=ae6mW74FZSU
    // Start is called before the first frame update
    void Start()
    {
        System.DateTime before = System.DateTime.Now;
        image = images[5];
        Color[] pix = image.GetPixels();

        int worldX = image.width;
        int worldZ = image.height;

        Vector3[] spawnPositions = new Vector3[pix.Length];
        Vector3 startingSpawnPosition = new Vector3(-Mathf.Round(worldX / 2), 0, -Mathf.Round(worldZ / 2));
        Vector3 currentSpawnPosition = startingSpawnPosition;

        int counter = 0;

        for (int z = 0; z < worldZ; z++)
        {
            for (int x = 0; x < worldX; x++)
            {
                spawnPositions[counter] = currentSpawnPosition;
                counter++;
                currentSpawnPosition.x++;
            }

            currentSpawnPosition.x = startingSpawnPosition.x;
            currentSpawnPosition.z++;
        }

        counter = 0;
        //int whitePix = 0;
        //int notWhitePix = 0;
        Color white = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        foreach (Vector3 pos in spawnPositions)
        {
            Color c = pix[counter];
             
            // First check for certain colors that would signify a certain object
            if(c != white)
            {
                //Debug.Log("Not white");
                Instantiate(wallObject, pos, Quaternion.identity);
                //notWhitePix++;
            }
            else
            {
                //Debug.Log("White");
                //whitePix++;
                // Not instantiating groundObject for performance purposes
                //Instantiate(groundObject, pos, Quaternion.identity);


            }
            counter++;
        }
        System.TimeSpan duration = System.DateTime.Now.Subtract(before);
        Debug.Log("Generation of map took " + duration.Milliseconds + " milliseconds");
        //Debug.Log("Found " + whitePix + " white pixels");
        //Debug.Log("Found " + notWhitePix + " non-white pixels");

        //foreach (Color c in pix)
        //{

        //}
        //Color white = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        //for (int i = 0; i < pix.Length; i++)
        //{
        //    //Debug.Log("i == " + i);
        //    if (pix[i] == Color.white)
        //    {
        //        Debug.Log("Pixel is white!");
        //    }
        //    else
        //    {

        //        if (pix[i] != white)
        //        {
        //            Debug.Log("!!pix[i] == " + pix[i]);
        //        }
        //    }
        //}
        //Debug.Log("pix.Length == " + pix.Length);
    }
}
