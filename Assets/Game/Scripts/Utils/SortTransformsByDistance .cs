using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SortTransformsByDistance
{
    public static Transform[] Sotr(Vector3 currentPosition, Transform[] transformsToSort, bool sortAscending = true)
    {
        if (sortAscending)
        {
            transformsToSort =
                transformsToSort.OrderBy(transform => Vector3.Distance(transform.position, currentPosition)).ToArray();
        }
        else
        {
            transformsToSort =
                transformsToSort.OrderByDescending(transform => Vector3.Distance(transform.position, currentPosition)).ToArray();
        }

        return transformsToSort;
    }
}
