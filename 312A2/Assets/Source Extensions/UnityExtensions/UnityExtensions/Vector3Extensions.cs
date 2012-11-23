using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source_Extensions.UnityExtensions.UnityExtensions
{
    public struct WorkingVector
    {
        public static WorkingVector Zero
        {
            get
            {
                return new WorkingVector();
            }
        }

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public static WorkingVector operator +(WorkingVector left, Vector3 right)
        {
            return new WorkingVector()
            {
                x = left.x + right.x,
                y = left.y + right.y,
                z = left.z + right.z
            };
        }

        public Vector3 ToVector3()
        {
            return new Vector3(x, y, z);
        }
    }

    public static class Vector3Extensions
    {
        public static Vector3 AsInverted(this Vector3 original)
        {
            return new Vector3(-original.x, -original.y, -original.z);
        }

        public static Vector3 Average(this IEnumerable<Vector3> vectors)
        {
            return vectors.Aggregate(WorkingVector.Zero, (workingVector, next) => workingVector + next).ToVector3();
        }
    }

}
