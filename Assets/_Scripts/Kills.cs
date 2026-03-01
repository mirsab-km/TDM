using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kills : IComparable<Kills> //Sortable class
{
    public string playerName;
    public int playerKills;

    public Kills(string newPlayerName, int newPlayerScore) //Constructor
    {
        playerName = newPlayerName;
        playerKills = newPlayerScore;
    }
    public int CompareTo(Kills other)
    {
        return other.playerKills - playerKills;  //Sorts in descending order (highest kills first)
    }
}
