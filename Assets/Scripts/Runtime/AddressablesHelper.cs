using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MyVampireSurvior
{

    public static class AddressablesHelper 
    {
        public static AsyncOperationHandle<T> LoadAsync<T>(AssetReference reference) where T  : UnityEngine.Object
        {
            if (reference.OperationHandle.IsValid())
            {
                return reference.OperationHandle.Convert<T>();
            }
            else
            {
                return reference.LoadAssetAsync<T>();
            }
        }
    }
}