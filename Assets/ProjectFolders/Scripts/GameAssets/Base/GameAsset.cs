using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary> Bu class oyundaki yardımcı olan bütün ScriptableObject olan assetleri atasıdır.
/// İçerisinde bu assetin infosunu tutmaktadır. </Summary>
public abstract class GameAsset : ScriptableObject
{
    [HideInInspector] public string eventInfo;
}
