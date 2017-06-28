using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public Units.Weapons type;

    public void SetItemType(Units.Weapons iType) {
        type = iType;
    }
}
