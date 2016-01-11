using UnityEngine;
using System;
using System.Text;

public static class MyExtensionMethods
{
    public static Vector3 vec3 = Vector3.zero;

    public static void Identity(this Transform trans)
    {
        trans.localScale = Vector3.one;
        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;    
    }

    /*到.net4.0 stringbuild 会有Clear 函数，到时可以删掉这个函数*/
    public static void Clear(this StringBuilder sb)
    {
        sb.Length = 0;
    }

    public static void AppendLineEx(this StringBuilder sb, string str = "")
    {
        sb.Append(str + "\r\n");
    }
}


