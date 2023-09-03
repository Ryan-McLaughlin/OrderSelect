using System;
using UnityEngine;

/// <summary>
/// Represents a menu item with a name, production cost, and selling price.
/// </summary>
public class MenuItem
{
    private string itemName;
    private float itemCost;
    private float itemPrice;

    /// <summary>
    /// Initializes a new instance of the MenuItem class with the specified name, cost, and price.
    /// </summary>
    /// <param name="_name">The name of the menu item.</param>
    /// <param name="_cost">The cost of producing the menu item.</param>
    /// <param name="_price">The price at which the menu item is sold.</param>
    public MenuItem(string _name, float _cost, float _price)
    {
        itemName = _name;
        itemCost = _cost;
        itemPrice = _price;

        //Debug.Log($"MenuItem.MenuItem() name: {miName},   cost:{imCost},  price:{miPrice}");
    }

    /// <summary>
    /// Get the name of the menu item.
    /// </summary>
    /// <returns>The name of the menu item.</returns>
    public string GetName()
    {
        return itemName;
    }

    /// <summary>
    /// Get the cost of producing the menu item.
    /// </summary>
    /// <returns>The cost of producing the menu item.</returns>
    public float GetCost()
    {
        return itemCost;
    }

    /// <summary>
    /// Get the price at which the menu item is sold.
    /// </summary>
    /// <returns>The price at which the menu item is sold.</returns>
    public float GetPrice()
    {
        return itemPrice;
    }
}
