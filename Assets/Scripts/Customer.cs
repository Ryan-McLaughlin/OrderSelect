using UnityEngine;
using System.Collections.Generic;

public class Customer : MonoBehaviour
{
    // todo?: Customer types ie: impatient, patient ~ affects how long they will wait per item ordered

    // Collider
    public GameObject collider;

    // Patience
    [SerializeField] FloatingSlider patienceSlider;
    [SerializeField] FloatingTMP patienceText;
    public float maxPatience = 10f;
    public float patience;

    // Order status
    private bool hasOrdered = true;
    private MenuItem myOrder;

    // Place in line
    private int customerNumber;

    // Movement
    public float moveSpeed = 1f;
    private Vector3 currentPosition;
    private Quaternion currentRotation;


    private void Awake()
    {
        patienceSlider = GetComponentInChildren<FloatingSlider>();
        patienceText = GetComponentInChildren<FloatingTMP>();
    }

    private void Start()
    {
        patience = maxPatience;
    }

    private void Update()
    {
        // update patience
        if (hasOrdered)
        {
            patience -= Time.deltaTime;
            patienceSlider.UpdateSlider(patience, maxPatience);            
            patienceText.UpdateText(System.Math.Round(patience, 1).ToString("0.0"));

            // check if still patient
            if (patience <= 0)
            {
                CancelOrder();
            }
        }

        // basic movement
        MoveRight();

        // check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse pointer
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the Collider of the assigned child object
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == collider)
            {
                // The assigned child object was clicked
                // Handle the click on the childObject here
                Debug.Log($"Clicked on: {transform.name}");
            }

        }


    }

    /// <summary>
    /// Moves the GameObject to the right along the X-axis while maintaining its current Y and Z positions.
    /// The GameObject's rotation is adjusted to face right during the movement.
    /// </summary>
    private void MoveRight()
    {

        // get current position / rotation
        currentPosition = transform.position;
        currentRotation = transform.rotation;

        // modify Y rotation
        currentRotation.eulerAngles = new Vector3(0f, 180f, 0f);

        // update position, apply rotation
        transform.position = new Vector3(currentPosition.x + moveSpeed * Time.deltaTime, currentPosition.y, currentPosition.z);
        transform.rotation = currentRotation;
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
        // remove game object
        Destroy(gameObject);
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

