using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Stat 
{
    [SerializeField]
    private double baseValue;

    //List of modifiers from equipment
    private List<Modifier> modifiers = new List<Modifier>();
    public Stat() { }
    public Stat(double baseValue)
    {
        this.baseValue = baseValue;
    }
    public double getValue () 
    { 
        double finalValue = baseValue;
        modifiers.ForEach(modifier => { finalValue = modifier.Apply(finalValue); });
        return finalValue;
    }
    //adding modifiers from equipment
    public void addModifier (Modifier modifier) 
    {
        if (modifier != null) modifiers.Add (modifier);
        
    }
    //removing modifiers from equipment
    public void removeModifier (Modifier modifier) 
    {
        if (modifier != null) modifiers.Remove(modifier);
    }
}


