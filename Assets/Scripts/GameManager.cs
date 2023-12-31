using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    // Customer
    private int nextCustomerNumber;
    public CustomerGenerator customerGenerator;
    private GameObject customer;
    private GameObject customerList;
    //private Vector3 customerSpawnPosition;
    //public GameObject customerPrefab;

    // User Interface
    public TextMeshProUGUI satisfiedCounterText;
    public TextMeshProUGUI unsatisfiedCounterText;
    public TextMeshProUGUI fundsText;

    // Counters
    private int satisfiedCounter = 0;
    private int unsatisfiedCounter = 0;
    private float funds = 0f;

    // Menu Item Lists
    private List<MenuItem> drinkList = new List<MenuItem>();
    private List<MenuItem> foodList = new List<MenuItem>();

    /// <summary>
    /// This method is called when the script is initialized. Use it to perform one-time setup tasks.
    /// </summary>
    private void Start()
    {
        Debug.Log("GameManager.Start()");

        // set starting customer number
        nextCustomerNumber = 1;

        customerList = new GameObject("Customer_List");

        CreateMenu();
    }

    private void Update()
    {
        Debug.Log("GameManager.Update()");

        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnCustomer();
        }

        funds += Time.deltaTime;

        UpdateUI();
    }

    /// <summary>
    /// Updates the User Interface (UI) elements to display game statistics.
    /// </summary>
    private void UpdateUI()
    {
        Debug.Log("GameManager.UpdateUI()");

        satisfiedCounterText.text = "Satisfied: " + satisfiedCounter;
        unsatisfiedCounterText.text = "Unsatisfied: " + unsatisfiedCounter;
        fundsText.text = "Funds: $" + System.Math.Round(funds, 2).ToString("0.00");
    }

    // TODO: move menu items to SQLite database
    /// <summary>
    /// Creates and populates the menu with food and drink items.
    /// </summary>
    private void CreateMenu()
    {
        Debug.Log("GameManager.CreateMenu()");

        // Create Drink Menu
        MenuItem drink_0 = new MenuItem("Drink 0", 0.49f, 1.49f);
        MenuItem drink_1 = new MenuItem("Drink 1", 0.49f, 1.49f);
        MenuItem drink_2 = new MenuItem("Drink 2", 0.49f, 1.49f);
        MenuItem drink_3 = new MenuItem("Drink 3", 0.99f, 1.99f);
        MenuItem drink_4 = new MenuItem("Drink 4", 0.99f, 1.99f);

        drinkList.Add(drink_0);
        drinkList.Add(drink_1);
        drinkList.Add(drink_2);
        drinkList.Add(drink_3);
        drinkList.Add(drink_4);

        // Create Food Menu
        MenuItem food_0 = new MenuItem("Food 0", 1.49f, 2.99f);
        MenuItem food_1 = new MenuItem("Food 1", 1.49f, 2.99f);
        MenuItem food_2 = new MenuItem("Food 2", 1.49f, 2.99f);
        MenuItem food_3 = new MenuItem("Food 3", 2.49f, 4.49f);
        MenuItem food_4 = new MenuItem("Food 4", 2.49f, 4.49f);

        foodList.Add(food_0);
        foodList.Add(food_1);
        foodList.Add(food_2);
        foodList.Add(food_3);
        foodList.Add(food_4);

        Debug.Log("--- Drink List ---");
        foreach (MenuItem drink in drinkList)
        {
            Debug.Log($"    Name: {drink.GetName()},   Cost: {drink.GetCost()},   Price: {drink.GetPrice()}");
        }

        Debug.Log("--- Food List ---");
        foreach (MenuItem food in foodList)
        {
            Debug.Log($"    Name: {food.GetName()},   Cost: {food.GetCost()},   Price: {food.GetPrice()}");
        }
    }

    /// <summary>
    /// Spawns a new customer in the game world.
    /// </summary>
    private void SpawnCustomer()
    {
        Debug.Log("GameManager.SpawnCustomer()");

        //customerSpawnPosition = new Vector3(-5, 0, 0);
        customer = customerGenerator.GenerateRandomCustomer();
        customer.name = $"Customer_{nextCustomerNumber}";
        customer.transform.parent = customerList.transform;

        nextCustomerNumber++;
    }

    /// <summary>
    /// Handles the event when a customer is satisfied.
    /// </summary>
    /// <param name="customer">The name of the satisfied customer.</param>
    public void CustomerSatisfied(string customerName)
    {
        Debug.Log($"{customerName} is Satisfied!");
        satisfiedCounter++;
    }

    /// <summary>
    /// Handles the event when a customer is unsatisfied and issues a refund.
    /// </summary>
    /// <param name="customer">The name of the unsatisfied customer.</param>
    /// <param name="refund">The refund amount issued to the customer.</param>
    public void CustomerUnsatisfied(string customerName, float refund)
    {
        Debug.Log($"{ customerName } is Unsatisfied! Issued refund of ${ refund.ToString("0.00") }");
        
        unsatisfiedCounter++;

        // apply refund to current funds
        funds -= refund;
    }
}

//// Check for prefab
//if (customerPrefab != null)
//{
//    // Instantiate prefab
//    GameObject customerInstance = Instantiate(customerPrefab);

//    // Set position and rotation
//    customerInstance.transform.position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f);
//    customerInstance.transform.rotation = Quaternion.identity;

//    // Set customer cube color
//    //Transform customerCube = customerInstance.transform.Find("CustomerCube");
//    //if (customerCube != null)
//    //{
//    //    Renderer cubeRenderer = customerCube.GetComponent<Renderer>();
//    //    if (cubeRenderer != null)
//    //    {
//    //        // Generate a random color.
//    //        Color randomColor = new Color(Random.value, Random.value, Random.value);

//    //        cubeRenderer.material.color = randomColor;
//    //    }
//    //    else { Debug.LogError("GameManager.SpawnCustomer(): cubeRenderer not found"); }
//    //}
//    //else { Debug.LogError("GameManager.SpawnCustomer(): CustomerCube not found"); }

//    // Add customer to customer list in scene
//    customerInstance.transform.parent = customerList.transform;

//    // TODO: give customer number to customer script

//    // Name the customer
//    customerInstance.name = $"Customer_{nextCustomerNumber}";            

//}
//else
//{
//    Debug.LogError("customerPrefab == null");
//}


//TODO: create customer constructor, put assigning of customer number there

//currentCustomer.SetCustomerNumber(nextCustomerNumber);

//currentCustomer.GetOrder(foodList);


// Reset timer
//TODO: move to customer TimeTillUnsatisfied()
//currentTimeRemaining = initialTimeRemaining - satisfiedCounter; // (satisfiedCounter * timeDecreasePerSatisfied);

// Customer food selection
// TODO: move to Customer
//Food requestedFood = FoodManager.GetRandomFood();
//Customer.Instance.SetupCustomer(requestedFood);


//public void HandleCorrectFoodSelection()
//{
//    funds += 10; // Adjust the amount as needed
//    satisfiedCounter++;

//    UpdateUI();
//    NewCustomer();
//}

//public void HandleWrongFoodSelection()
//{
//    unsatisfiedCounter++;

//    UpdateUI();
//    NewCustomer();
//}

//private void HandleUnsatisfiedCustomer()
//{
//    unsatisfiedCounter++;

//    UpdateUI();
//    NewCustomer();
//}

