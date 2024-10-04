using UnityEngine;

public class LightBonus : MonoBehaviour, IItem
{
    public Sprite Icon => throw new System.NotImplementedException();

    public void Collect()
    {
        Debug.Log("boonus");
        Destroy(gameObject);
    }
}
