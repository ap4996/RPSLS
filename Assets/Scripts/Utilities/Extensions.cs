using UnityEngine;

public static class Extensions 
{
    public static T GetRandomValue<T>() where T : System.Enum
    {
        System.Array values = System.Enum.GetValues(typeof(T));
        int randomIndex = Random.Range(1, values.Length);
        return (T)values.GetValue(randomIndex);
    }
}
