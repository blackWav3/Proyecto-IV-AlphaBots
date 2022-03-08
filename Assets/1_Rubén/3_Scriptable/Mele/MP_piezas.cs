using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PIEZAS", menuName = "Mele")]
public class MP_piezas : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite image;
    public float damage;
    public float cooldown;
}
