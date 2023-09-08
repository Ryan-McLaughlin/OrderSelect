using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    public GameObject customerPrefab;
    public Sprite[] backhairSprites;
    public Sprite[] faceSprites;
    public Sprite[] bodySprites;
    public Sprite[] shoeSprites;
    public Sprite[] fronthairSprites;

    //private void Start()
    //{
    //    // Initialize your sprite arrays with appropriate sprites
    //    // You can do this either in the Inspector or programmatically here

    //    // Call a method to generate a random customer
    //    //GenerateRandomCustomer();
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        GenerateRandomCustomer();
    //    }
    //}

    public GameObject GenerateRandomCustomer()
    {
        // Create a new instance of the customer prefab
        GameObject customer = Instantiate(customerPrefab, transform.position, Quaternion.identity);

        // Get references to the sprite renderers on the customer
        SpriteRenderer backhairRenderer  = customer.transform.Find("backhair" ).GetComponent<SpriteRenderer>();
        SpriteRenderer fronthairRenderer = customer.transform.Find("fronthair").GetComponent<SpriteRenderer>();
        SpriteRenderer faceRenderer      = customer.transform.Find("face"     ).GetComponent<SpriteRenderer>();
        SpriteRenderer bodyRenderer      = customer.transform.Find("body"     ).GetComponent<SpriteRenderer>();
        SpriteRenderer shoeRenderer      = customer.transform.Find("shoe"     ).GetComponent<SpriteRenderer>();

        // Randomly select sprites for each part from the arrays

        //backhairRenderer.sprite = GetRandomSprite(backhairSprites);
        //fronthairRenderer.sprite = GetRandomSprite(fronthairSprites);
        faceRenderer.sprite = GetRandomSprite(faceSprites);
        bodyRenderer.sprite = GetRandomSprite(bodySprites);
        shoeRenderer.sprite = GetRandomSprite(shoeSprites);

        
        int randomHairIndex = Random.Range(0, backhairSprites.Length);
        backhairRenderer.sprite = backhairSprites[randomHairIndex];
        fronthairRenderer.sprite = fronthairSprites[randomHairIndex];

        return customer;
    }

    private Sprite GetRandomSprite(Sprite[] spriteArray)
    {
        // Generate a random index within the bounds of the sprite array
        int randomIndex = Random.Range(0, spriteArray.Length);

        // Return the randomly selected sprite
        return spriteArray[randomIndex];
    }    
}
