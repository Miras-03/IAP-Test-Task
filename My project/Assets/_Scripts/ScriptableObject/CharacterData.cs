using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Character", fileName = "Character")]
public class CharacterData : ScriptableObject
{
    public int buttonId;
    public int price;
    public int requiredLevel;
}