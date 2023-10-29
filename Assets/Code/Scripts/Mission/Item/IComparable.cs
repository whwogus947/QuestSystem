using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Quest
{
    //public interface IComparable<T> where T : IQuestComparable<T>
    //{
    //    T CompareTarget { get; }
    //    bool Equals(IComparable<T> other);
    //}

    public interface IComparable<T>
    {
        T CompareTarget { get; }
        bool Equals(IComparable<T> other);
    }

    //public interface IQuestComparable<T>
    //{
        
    //}


    //public interface ICompareObject : IQuestComparable<GameObject>
    //{
    //    GameObject CompareObject { get; }
    //}

    //public interface ICompareCount : IQuestComparable<int>
    //{
    //    int CompareCount { get; }
    //}
    
    //public interface ICompareObject : IQuestComparable
    //{
    //    GameObject CompareObject { get; }
    //}

    //public interface ICompareCount : IQuestComparable
    //{
    //    int CompareCount { get; }
    //}
}
