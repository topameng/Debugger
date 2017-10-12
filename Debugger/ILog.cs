﻿using UnityEngine;

namespace LuaInterface
{
    public interface ICmd
    {
        void Log(string msg);
        void LogWarning(string msg);
        void LogError(string msg);
        void Show(bool flag);
    }

    public interface ILogger
    {
        void Log(string msg, string stack, LogType type);
    }
}


