using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Factions
{

    public string factionName;
    [SerializeField, Range(-1, 1)]
    public float _approval;
    public float approval
    {
        set
        {
            _approval = Mathf.Clamp(value, -1, 1);
        }
        get
        {
            return _approval;
        }
    }
    public Factions(float initalApproval)
    {
        _approval = initalApproval;
    }

}

public class FactionsManager : MonoBehaviour
{
    //[SerializeField]
    Dictionary<string, Factions> factions;
    [SerializeField]
    List<Factions> CreateTheseFactions;
    public static FactionsManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        factions = new Dictionary<string, Factions>();
        foreach (Factions faction in CreateTheseFactions)
        {
            factions.Add(faction.factionName, new Factions(faction.approval));
        }
        //factions.Add("Combine", new Factions(0));
        //factions.Add("Zen", new Factions(1));
    }
    public float? FactionsAproval(string factionName, float value)
    {
        if (factions.ContainsKey(factionName))
        {
            factions[factionName]._approval += value;
            return factions[factionName]._approval;
        }
        return null;
    }
    public float? FactionsApproval(string factionName)
    {
        if (factions.ContainsKey(factionName))
        {
            return factions[factionName]._approval;
        }
        return null;
    }
}