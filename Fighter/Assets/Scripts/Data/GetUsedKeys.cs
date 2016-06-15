using UnityEngine;
using System.Collections;

public static class GetUsedKeys{

    public static void AnyUsedKey(this Input t, string[] keycodes)
    {
        int i = 0;
        foreach(string s in keycodes)
        {
            i++;
            if(Input.GetKey(keycodes[i]))
            {
                Debug.Log(keycodes[i]);
            }
        }
    }
}
