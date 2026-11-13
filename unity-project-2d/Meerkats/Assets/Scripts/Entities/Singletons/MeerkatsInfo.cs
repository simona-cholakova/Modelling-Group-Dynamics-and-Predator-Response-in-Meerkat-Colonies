using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeerkatsInfo", menuName = "Info Singletons/Meerkats Info", order = 0)]
public class MeerkatsInfo : ScriptableObject {
    

    private List<Meerkat> _meerkats;
    public IReadOnlyList<Meerkat> meerkats {get {return _meerkats;}}

    void OnEnable()
    {
        _meerkats = new List<Meerkat>();
    }

    public void Add(Meerkat m)
    {
        _meerkats.Add(m);
    }

    public void Remove(Meerkat m)
    {
        _meerkats.Remove(m);
    }

    
}