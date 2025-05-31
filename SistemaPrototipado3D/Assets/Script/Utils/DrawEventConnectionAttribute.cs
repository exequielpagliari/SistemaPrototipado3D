using UnityEngine;

public class DrawEventConnection : PropertyAttribute
{
    public string fieldName;

    public DrawEventConnection(string fieldName)
    {
        this.fieldName = fieldName;
    }
}
