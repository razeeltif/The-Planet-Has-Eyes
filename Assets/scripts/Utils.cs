using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {


    public static bool checkNull(string objName, Object obj)
    {
        if (obj == null)
            Debug.LogError(objName + " is null");

        return obj == null;
    }



}
