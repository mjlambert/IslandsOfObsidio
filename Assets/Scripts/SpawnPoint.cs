﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "spawnPoint.png");
    }

}
