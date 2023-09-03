using UnityEngine;
using System.Collections.Generic;

public class Customer : MonoBehaviour
{
    // todo?: Customer types ie: impatient, patient ~ affects how long they will wait per item ordered

    // Patience
    [SerializeField] FloatingPatienceBar patienceBar;
    [SerializeField] FloatingTMP patienceText;
    public float maxPatience = 10f;
    public float patience;

    private bool hasOrdered = true;

    // Similar to grabbing a paper number slip at the deli
    private int customerNumber;


    private MenuItem myOrder;

    private void Awake()
    {
        patienceBar = GetComponentInChildren<FloatingPatienceBar>();
        patienceText = GetComponentInChildren<FloatingTMP>();
    }

    private void Start()
    {
        patience = maxPatience;
    }

    private void Update()
    {
        if (hasOrdered)
        {
            // update patience
            patience -= Time.deltaTime;
            patienceBar.UpdatePatienceBar(patience, maxPatience);            
            patienceText.UpdateText(System.Math.Round(patience, 1).ToString("0.0"));

            // check if still patient
            if (patience <= 0)
            {
                CancelOrder();
            }
        }
    }

    /// <summary>
    /// Sets the order for this customer by randomly selecting a menu item from the given food list.
    /// </summary>
    /// <param name="foodList">The list of available menu items to choose from.</param>
    /// <returns>The menu item selected for the customer's order.</returns>
    public MenuItem SetOrder(List<MenuItem> foodList)
    {
        // Customer only orderes one food item at a time

        int foodItem = UnityEngine.Random.Range(0, foodList.Count);

        myOrder = foodList[foodItem];

        hasOrdered = true;

        return myOrder;
    }

    /// <summary>
    /// Gets the menu item that the customer has ordered.
    /// </summary>
    /// <returns>The menu item that the customer has ordered.</returns>
    public MenuItem GetOrder()
    {
        return myOrder;
    }

    /// <summary>
    /// Sets the customer's unique identification number.
    /// </summary>
    /// <param name="number">The unique customer number to assign.</param>
    public void SetCustomerNumber(int number)
    {
        customerNumber = number;
    }

    /// <summary>
    /// Gets the customer's unique identification number.
    /// </summary>
    /// <returns>The unique customer number.</returns>
    public int GetCustomerNumber()
    {
        Debug.Log("Customer.GetCustomerNumber() move this to constructor");
        return customerNumber;
    }

    /// <summary>
    /// Cancels the customer's order and handles the customer leaving the game.
    /// </summary>
    private void CancelOrder()
    {
        // TODO: cancel order
        // TODO: leave
    }
}



//public static Customer Instance { get; private set; }
//public Food orderedFood;


//private void Awake()
//{
//    Console.WriteLine("Customer.Awake");
//    Instance = this;
//}

//public void SetupCustomer(Food food)
//{
//    Console.WriteLine("Customer.SetupCustomer");
//    orderedFood = food;
//    // You can set up the customer appearance here
//}

//public void RecievedFood(Food food)
//{
//    Console.WriteLine("Customer.RecievedFood");

//    if (food == orderedFood)
//    {
//        Console.WriteLine("food == orderedFood");
//    }
//    else
//    {            
//        Console.WriteLine("food != orderedFood");
//    }
//}

