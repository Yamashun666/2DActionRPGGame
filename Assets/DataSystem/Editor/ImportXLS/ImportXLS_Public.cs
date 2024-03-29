﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NPOI.SS.UserModel;
using UnityEditor;
using UnityEngine;

public partial class ImportXLS : EditorWindow
{
    static Assembly asm = null;

    public static void GetGameAssembly()
    {
        try
        {
#if UNITY_EDITOR_WIN
            asm = Assembly.LoadFile("Library\\ScriptAssemblies\\Assembly-CSharp.dll");
#else
            asm = Assembly.LoadFile("Library/ScriptAssemblies/Assembly-CSharp.dll");
#endif
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed Assembly LoadFile: " + ex.Message);
            asm = null;
        }
    }

    /// <summary>
    /// グリッドデータを取得
    /// </summary>
    /// <param name="sheet">シート</param>
    /// <param name="posList">ポジションリスト</param>
    /// <returns>グリッドデータ</returns>
    public static string[,] GetGrid(ISheet sheet, Dictionary<string, PosIndex> posList)
    {
        // シートの最大行数と最大列数を確認
        if (getRowAndColumnMax(sheet, out int rowMax, out int colMax) == false)
        {
            return null;
        }

        string[,] grid = new string[rowMax, colMax];
        int       marginrow_between_category = 0;
        for (int r = 0; r <= sheet.LastRowNum; r++)
        {
            if (getCells(sheet, grid, posList, r, ref marginrow_between_category) == false)
            {
                return null;
            }
        }

        return grid;
    }

    /// <summary>
    /// 指定ディレクトリが存在しない場合、上から辿って作成する
    /// </summary>
    /// <param name="dir">指定ディレクトリ</param>
    /// <returns>true..作成した</returns>
    public static bool CompleteDirectory(string dir)
    {
        if (string.IsNullOrEmpty(dir) == true)
        {
            return false;
        }
        if (Directory.Exists(dir) == false)
        {
            CompleteDirectory(Path.GetDirectoryName(dir));
            Directory.CreateDirectory(dir);
            return true;
        }
        
        return false;
    }

    public static bool GetNull()
    {
        return true;
    }

    /// <summary>
    /// int 値を取得。空欄は 0
    /// </summary>
    public static bool GetInt(string sval, out int val)
    {
        if (string.IsNullOrEmpty(sval) == true)
        {
            val = 0;
        }
        else
        {
            if (int.TryParse(sval, out val) == false)
            {
                object o = getConstValue(sval);
                if (o == null)
                {
                    Debug.LogError($"{sval} is not value.");
                    return false;
                }
                int.TryParse(o.ToString(), out val);
            }
        }
        return true;
    }

    /// <summary>
    /// bool 値を取得。空欄は false
    /// </summary>
    public static bool GetBool(string sval, out bool val)
    {
        if (string.IsNullOrEmpty(sval) == true)
        {
            val = false;
        }
        else
        {
            if (bool.TryParse(sval, out val) == false)
            {
                // bool はなにか入っていたら true
                val = true;
                return true;
            }
        }
        return true;
    }
    
    /// <summary>
    /// float 値を取得。空欄は 0
    /// </summary>
    public static bool GetFloat(string sval, out float val)
    {
        if (string.IsNullOrEmpty(sval) == true)
        {
            val = 0;
        }
        else
        {
            if (float.TryParse(sval, out val) == false)
            {
                object o = getConstValue(sval);
                if (o == null)
                {
                    Debug.LogError($"{sval} is not value.");
                    return false;
                }
                float.TryParse(o.ToString(), out val);
            }
        }
        return true;
    }

    /// <summary>
    /// 文字列を取得
    /// </summary>
    public static bool GetString(string sval, out string val)
    {
        if (string.IsNullOrEmpty(sval) == true)
        {
            val = null;
        }
        else
        {
            object o = getConstValue(sval);
            if (o != null)
            {
                val = o.ToString();
            }
            else
            {
                val = sval;
            }
        }
        return true;
    }

    /// <summary>
    /// enum 値を取得
    /// </summary>
    public static bool GetEnum<T>(string sval, out T val) where T : struct
    {
        if (string.IsNullOrEmpty(sval) == true)
        {
            val = (T)Enum.ToObject(typeof(T), 0);
        }
        else
        {
            if (Enum.TryParse<T>(sval, out val) == false)
            {
                return false;
            }
        }
        return true;
    }
    
    /// <summary>
    /// コメント文字列かどうか確認
    /// </summary>
    /// <returns>true..コメント文字列（のようだ）</returns>
    public static bool CheckSignComment(string str)
    {
        if (str == null)
        {
            return false;
        }
        foreach (string sign in SIGN_COMMENTS)
        {
            if (str.IndexOf(sign) == 0)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// (0, 0) -> (1, A) のようにエクセルの表示列・行と同じ表示を返します
    /// </summary>
    /// <param name="r">行 (0～)</param>
    /// <param name="c">列 (0～)</param>
    public static string GetXLS_RC(int r, int c)
    {
        // 数値をエクセルの列 A～ZZZ に変換
        int[]  cs  = new int[] { c / 26 / 26, (c / 26) % 26, c % 26 };
        string col = "";
        if (cs[0] != 0) col += colTexts[cs[0]-1];
        if (cs[1] != 0) col += colTexts[cs[1]-1];
        col += colTexts[cs[2]];
        
        return $"{r+1}, {col}";
    }
    
    /// <summary>
    /// AClass.BValue のような値を取得。事前に GetGameAssembly() で asm を取得しておく必要があります
    /// リフレクションとして存在しない場合は null を返します
    /// </summary>
    static object getConstValue(string sval)
    {
        string[]	cells = sval.Split('.');
        if (cells.Length == 2)
        {
            if (asm != null)
            {
                object ov = asm.GetType(cells[0])?.GetField(cells[1])?.GetValue(null);
                return ov;
            }
        }
        return null;
    }

}
