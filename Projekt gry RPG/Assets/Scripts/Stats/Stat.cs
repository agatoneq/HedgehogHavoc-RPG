using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

[System.Serializable]

public class Stat 
{
    [SerializeField]
    private double baseValue;
    //List of modifiers from equipment
    private List<double> modifiers = new List<double>();

    public double getValue () 
    { 
        double finalValue = baseValue;
        modifiers.ForEach(modifier => { finalValue += modifier; });
        return finalValue;
    }
    //adding modifiers from equipment
    public void addModifier (double modifier) 
    {
        if (modifier != 0) modifiers.Add (modifier);
        
    }
    //removing modifiers from equipment
    public void removeModifier (double modifier) 
    {
        if (modifier != 0) modifiers.Remove(modifier);
    }
}
