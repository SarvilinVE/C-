using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVVM.Model
{
    internal interface IScore
    {
        float MaxScore { get; }
        float CurrentScore { get; set; }
    }
}
