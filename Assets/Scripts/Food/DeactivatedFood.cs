using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Food
{
    public class DeactivatedFood : MonoBehaviour
    {
        private void Deactivated() => gameObject.SetActive(false);
    }
}
