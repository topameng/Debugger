using UnityEngine;
using System;
using System.Text;

public static class Debugger
{
    public static bool useLog = true;
    public static string threadStack = string.Empty;
    public static ILogger logger = null;

    //减少gc alloc
    static string GetLogFormat(string str)
    {
        StringBuilder sb = StringBuilderCache.Acquire();
        DateTime time = DateTime.Now;        
        sb.Append(time.Hour);
        sb.Append(":");
        sb.Append(time.Minute);
        sb.Append(":");
        sb.Append(time.Second);
        sb.Append(".");
        sb.Append(time.Millisecond);
        sb.Append("-");
        sb.Append(Time.frameCount % 999);        
        sb.Append(": ");
        sb.Append(str);
        return StringBuilderCache.GetStringAndRelease(sb);
    }

    public static void Log(string str)
    {
        str = GetLogFormat(str); 

        if (useLog)
        {
            Debug.Log(str);
        }
        else if (logger != null)
        {
            //普通log节省一点记录堆栈性能和避免调用手机系统log函数
            logger.Log(str, string.Empty, LogType.Log);
        }
    }

    public static void Log(object message)
    {
        Log(message.ToString());
    }

    public static void Log(string str, object arg0)
    {
        string s = string.Format(str, arg0);
        Log(s);
    }

    public static void Log(string str, object arg0, object arg1)
    {
        string s = string.Format(str, arg0, arg1);
        Log(s);
    }

    public static void Log(string str, object arg0, object arg1, object arg2)
    {
        string s = string.Format(str, arg0, arg1, arg2);
        Log(s);
    }

    public static void Log(string str, params object[] param)
    {
        string s = string.Format(str, param);
        Log(s);
    }

    public static void LogWarning(string str)
    {
        str = GetLogFormat(str);

        if (useLog)
        {
            Debug.LogWarning(str);
        }
        else if (logger != null)
        {
            string stack = StackTraceUtility.ExtractStackTrace();
            logger.Log(str, stack, LogType.Warning);
        }        
    }

    public static void LogWarning(object message)
    {
        LogWarning(message.ToString());
    }

    public static void LogWarning(string str, object arg0)
    {
        string s = string.Format(str, arg0);
        LogWarning(s);
    }

    public static void LogWarning(string str, object arg0, object arg1)
    {
        string s = string.Format(str, arg0, arg1);
        LogWarning(s);
    }

    public static void LogWarning(string str, object arg0, object arg1, object arg2)
    {
        string s = string.Format(str, arg0, arg1, arg2);
        LogWarning(s);
    }

    public static void LogWarning(string str, params object[] param)
    {
        string s = string.Format(str, param);
        LogWarning(s);
    }

    public static void LogError(string str)
    {
        str = GetLogFormat(str);

        if (useLog)
        {
            Debug.LogError(str);
        }
        else if (logger != null)
        {
            string stack = StackTraceUtility.ExtractStackTrace();
            logger.Log(str, stack, LogType.Error);
        }         
    }

    public static void LogError(object message)
    {
        LogError(message.ToString());
    }

    public static void LogError(string str, object arg0)
    {
        string s = string.Format(str, arg0);
        LogError(s);
    }

    public static void LogError(string str, object arg0, object arg1)
    {
        string s = string.Format(str, arg0, arg1);
        LogError(s);
    }

    public static void LogError(string str, object arg0, object arg1, object arg2)
    {
        string s = string.Format(str, arg0, arg1, arg2);
        LogError(s);
    }

    public static void LogError(string str, params object[] param)
    {
        string s = string.Format(str, param);
        LogError(s);
    }


    public static void LogException(Exception e)
    {
        threadStack = e.StackTrace;
        string str = GetLogFormat(e.Message);

        if (useLog)
        {
            Debug.LogError(str);
        }
        else if (logger != null)
        {            
            logger.Log(str, threadStack, LogType.Exception);
        }
    }

    public static void LogException(string str, Exception e)
    {
        threadStack = e.StackTrace;        
        str = GetLogFormat(str + e.Message);

        if (useLog)
        {
            Debug.LogError(str);
        }
        else if (logger != null)
        {
            logger.Log(str, threadStack, LogType.Exception);
        }
    }
}
